using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using F1Speed.Core.Repositories;
#if DEBUG
using log4net;
#endif

namespace F1Speed.Core
{
    public enum ComparisonModeEnum
    {
        FastestLap,
        Reference
    };

    [Serializable]
    public class SessionLaps
    {
        public IList<TelemetryLap> Laps;
        public String CircuitName;
        public String Type;
    }

    public delegate void CompletedFullLapEventHandler(object sender, CompletedFullLapEventArgs e);
    public delegate void LapEventHandler(object sender, LapEventArgs e);
    public delegate void PacketEventHandler(object sender, PacketEventArgs e);
    
    public class TelemetryLapManager
    {
#if DEBUG
        private readonly static ILog logger = Logger.Create();
#endif

        private string _circuitName;
        private string _lapType;      

        
        private readonly ITelemetryLapRepository _fastestLapRepository;
        private readonly IEnumerable<ITelemetryLapRepository> _currentLapExporters;
        private readonly IList<TelemetryLap> _laps;

        public event CompletedFullLapEventHandler CompletedFullLap;
        public event LapEventHandler ReturnedToGarage;
        public event LapEventHandler SetFastestLap;
        public event LapEventHandler StartedOutLap;
        public event LapEventHandler FinishedOutLap;
        public event LapEventHandler RemovedLap;
        public event PacketEventHandler DebugPacketProcessed;
        public event PacketEventHandler PacketProcessed;
        
        public TelemetryLap ReferenceLap { get; private set; }
        public TelemetryLap FastestLap { get; set; }

        private bool _hasDataBeenReceived;

        protected void OnDebugPacketProcessed(TelemetryPacket packet)
        {
#if DEBUG
            logger.Debug(packet.ToString());
#endif


            if (DebugPacketProcessed != null)
                DebugPacketProcessed(this, new PacketEventArgs { Packet = packet });
        }

        protected void OnPacketProcessed(TelemetryPacket packet)
        {            
            if (PacketProcessed != null)
                PacketProcessed(this, new PacketEventArgs { Packet = packet });
        }

        protected void OnRemovedLap(TelemetryLap lap)
        {
            if (RemovedLap != null)
                RemovedLap(this, new LapEventArgs{ Lap = lap });
        }

        protected void OnStartedOutLap(TelemetryLap lap)
        {
            if (StartedOutLap != null)
                StartedOutLap(this, new LapEventArgs { Lap = lap});
        }

        protected void OnFinishedOutLap(TelemetryLap lap)
        {
            if (FinishedOutLap != null)
                FinishedOutLap(this, new LapEventArgs { Lap = lap });
        }

        protected void OnCompletedFullLap(CompletedFullLapEventArgs e)
        {
            if (CompletedFullLap != null)
                CompletedFullLap(this, e);
        }

        protected void OnReturnedToGarage(TelemetryLap lap)
        {
            if (ReturnedToGarage != null)
                ReturnedToGarage(this, new LapEventArgs { Lap = lap });
        }

        protected void OnSetFastestLap(LapEventArgs e, TelemetryLap oldFastestLap)
        {
            #if DEBUG
            logger.Info(string.Format("Set new Fastest Lap.  (old={0}.  new={1})",
                           oldFastestLap != null ? oldFastestLap.LapTime.AsTimeString() : "Nothing",
                           e.Lap.LapTime.AsTimeString()));
            #endif

            if (SetFastestLap != null)
                SetFastestLap(this, e);
        }

        public TelemetryLapManager(List<ITelemetryLapRepository> repos = null)
        {
            _laps = new List<TelemetryLap>();
            _fastestLapRepository = new BinaryTelemetryLapRepository();

            if (repos == null)
            {
                _currentLapExporters = new List<ITelemetryLapRepository>
                                      {
                                          new BinaryTelemetryLapRepository()                                         
                                      };
            }
            else
            {
                this._currentLapExporters = repos;
            }

            _hasDataBeenReceived = false;
        }

        public ComparisonModeEnum ComparisonMode { get; private set; } 

        public void SetReferenceLap(TelemetryLap referenceLap)
        {
            ReferenceLap = referenceLap;
            if (referenceLap != null)
            {
                #if DEBUG
                logger.Info("Reference lap loaded for " + referenceLap.CircuitName + " '" + referenceLap.LapType + "'");
#endif
                ComparisonMode = ComparisonModeEnum.Reference;
            }
            else
            {
                #if DEBUG
                logger.Info("Reference lap cleared");
#endif
            }
        }

        public void SetFastest(TelemetryLap FastestLap)
        {
            this.FastestLap = FastestLap;
            if (FastestLap != null)
            {
#if DEBUG
                logger.Info("FastestLap loaded for " + FastestLap.CircuitName + " '" + FastestLap.LapType + "'");
#endif
                ComparisonMode = ComparisonModeEnum.FastestLap;
            }
            else
            {
#if DEBUG
                logger.Info("FastestLap cleared");
#endif
            }
        }

        public float CurrentThrottle
        {
            get
            {

                return LatestPacket.Throttle;
            }
        }

        public TelemetryPacket LatestPacket
        {
            get
            {
                if (CurrentLap == null || !CurrentLap.Packets.Any())
                    return new TelemetryPacket();

                return CurrentLap.Packets.Last();
            }
        }

        public float CurrentBrake
        {
            get { return LatestPacket.Brake; }
        }

        public float CurrentWheelSpin(int wheel)
        {
            switch (wheel)
            {
                case 0:
                    return LatestPacket.WheelSpeedFrontLeft - LatestPacket.Speed;
                case 1:
                    return LatestPacket.WheelSpeedFrontRight - LatestPacket.Speed;
                case 2:
                    return LatestPacket.WheelSpeedBackLeft - LatestPacket.Speed;
                case 3:
                    return LatestPacket.WheelSpeedBackRight - LatestPacket.Speed;
                default:
                    return 0.0f;
            }
        }

        public void ChangeCircuit(string circuitName, string lapType)
        {
            _laps.Clear();
#if DEBUG
            logger.Info("Current circuit changed to " + circuitName + " '" + lapType + "'");
#endif
            ReferenceLap = null;                        
            ComparisonMode = ComparisonModeEnum.FastestLap;
            this._circuitName = circuitName;
            this._lapType = lapType;
            LoadFastestLap();
        }

        public bool HasDataBeenReceived
        {
            get { return _hasDataBeenReceived; }
            set
            {
                if (value == _hasDataBeenReceived)
                    return;

                _hasDataBeenReceived = value;
                #if DEBUG
                if (_hasDataBeenReceived)
                    logger.Info("Data connection established");
#endif
            }
        }

        public void ProcessIncomingPacket(TelemetryPacket packet)
        {
            HasDataBeenReceived = true;
            if (F1SpeedSettings.LogPacketData)
                OnDebugPacketProcessed(packet);            

            if (HasLapChanged(packet))
            {                                
                if (!packet.IsInPitLane) 
                    CurrentLap.MarkLapCompleted();
                else 
                    OnReturnedToGarage(CurrentLap);
                
                if (CurrentLap.IsCompleteLap)
                {                    
                    if (string.IsNullOrEmpty(CurrentLap.CircuitName))
                        CurrentLap.CircuitName = _circuitName;
                    if (string.IsNullOrEmpty(CurrentLap.LapType))
                        CurrentLap.LapType = _lapType;

                    if (F1SpeedSettings.SaveAllLaps)
                    {
                        foreach (var exporter in _currentLapExporters) exporter.Save(CurrentLap);
                    }
                    
                    if (FastestLap == null || CurrentLap.LapTime < FastestLap.LapTime)
                    {                                                
                        OnSetFastestLap(new LapEventArgs { Lap = CurrentLap }, FastestLap);
                        
                        FastestLap = CurrentLap;
                        SaveFastestLap();                       
                    }

                    OnCompletedFullLap(new CompletedFullLapEventArgs { CompletedLap = CurrentLap, CurrentLapNumber = (int)packet.Lap, PreviousLapNumber = CurrentLap.LapNumber });
                } 
                else
                {                    
                    if (CurrentLap.IsOutLap)                    
                        OnFinishedOutLap(CurrentLap);                    

                    // Lap is invalid
                    _laps.Remove(CurrentLap);

                    OnRemovedLap(CurrentLap);
                }

                // Start new current lap
                _laps.Add(new TelemetryLap(_circuitName, _lapType));                                         
            }           
            
            CurrentLap.AddPacket(packet);

            OnPacketProcessed(packet);                                                     
        }

        protected bool HasLapChanged(TelemetryPacket packet)
        {
            if (CurrentLap == null)
            {
                #if DEBUG
                logger.Info("Lap has changed.  No previous lap");
#endif
                return true;
            }

            if (packet.Lap > CurrentLap.LapNumber || packet.Lap < CurrentLap.LapNumber || 
                (Math.Abs(packet.Lap - CurrentLap.LapNumber) < Constants.Epsilon && CurrentLap.Distance < 0 && packet.Distance > 0))
            {
                #if DEBUG
                logger.Info("Lap has changed - current lap number changed");
#endif
                return true;
            }

            return packet.LapTime <= 0 && LatestPacket.LapTime > 0;
        }

        protected TelemetryLap CurrentLap
        {
            get
            {
                if (_laps.Count == 0)
                    _laps.Add(new TelemetryLap(_circuitName, _lapType));

                return _laps.Last();
            }
        }

        public void SaveFastestLap()
        {
            _fastestLapRepository.Save(FastestLap);
        }

        public void LoadFastestLap()
        {
            MigrateXmlLapsToBinary();

            var fastestLap = _fastestLapRepository.Get(_circuitName, _lapType);            
            FastestLap = fastestLap;
        }

        private void MigrateXmlLapsToBinary()
        {
            var xmlRepo = new XmlTelemetryLapRepository();
            var xmlFastestLap = xmlRepo.Get(_circuitName, _lapType);
            if (xmlFastestLap == null) return;
            xmlFastestLap.CircuitName = _circuitName;
            xmlFastestLap.LapType = _lapType;
            _fastestLapRepository.Save(xmlFastestLap);
            xmlRepo.Delete(xmlFastestLap);
        }

        public string GetSpeedDelta()
        {
            if (ComparisonLap == null || CurrentLap == null || !CurrentLap.Packets.Any())
                return "--";

            var comparisonLapPacket = ComparisonLap.GetPacketClosestTo(LatestPacket);

            var difference = LatestPacket.SpeedInKmPerHour - comparisonLapPacket.SpeedInKmPerHour;
            return string.Format("{0}{1:0.0}",
                                 difference > 0 ? "+" : "", difference);
        }

        public float GetSpeedDeltaValue()
        {
            if (ComparisonLap == null || CurrentLap == null || !CurrentLap.Packets.Any())
                return 0;

            var comparisonLapPacket = ComparisonLap.GetPacketClosestTo(LatestPacket);

            return LatestPacket.SpeedInKmPerHour - comparisonLapPacket.SpeedInKmPerHour;            
        }

        public TelemetryLap ComparisonLap
        {
            get
            {
                return ComparisonMode == ComparisonModeEnum.Reference ? ReferenceLap : FastestLap;
            }
        }

        public float GetTimeDelta()
        {
            if (ComparisonLap == null || CurrentLap == null || !CurrentLap.Packets.Any())
                return 0f;

            var currentPacket = LatestPacket;
            var comparisonLapPacket = ComparisonLap.GetPacketClosestTo(currentPacket);

            var difference = currentPacket.LapTime - comparisonLapPacket.LapTime;
            return -difference;
        }

    
        public string ComparisonLapTime
        {
            get
            {
                return ComparisonLap == null ? "" : ComparisonLap.LapTime.AsTimeString();
            }
        }

        public string ExpectedLapTime
        {
            get
            {
                return !CurrentLap.IsFirstPacketStartLine ? "" : (ComparisonLap.LapTime + GetTimeDelta()).AsTimeString();
            }
        }

        public string CurrentLapTime
        {
            get
            {
                return !CurrentLap.IsFirstPacketStartLine ? "" : CurrentLap.LapTime.AsTimeString();
            }
        }

        public string AverageLapTime
        {
            get
            {
                return _laps.Any(lap => lap.HasLapFinished) ? _laps.Where(lap => lap.HasLapFinished).Average(lap => lap.LapTime).AsTimeString() : "";
            }
        }

        public IList<TelemetryLap> Laps
        {
            get
            {
                return _laps;
            }
        }

        public String CircuitName
        {
            get
            {
                return _circuitName;
            }
        }

        public String lapType
        {
            get
            {
                return _lapType;
            }
        }

        public SessionLaps GetAllLaps()
        {
            SessionLaps AllLaps = new SessionLaps();
            AllLaps.CircuitName = _circuitName;
            AllLaps.Type = _lapType;
            AllLaps.Laps = _laps;
            return AllLaps;
        }

        public void SetAllLaps(SessionLaps AllLaps)
        {
            ChangeCircuit(AllLaps.CircuitName, AllLaps.Type);
            this._laps.Clear();
            foreach (var item in AllLaps.Laps)
	        {
                this._laps.Add(item);
	        }           
        }
    }
}
