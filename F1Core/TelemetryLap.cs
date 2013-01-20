using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace F1Speed.Core
{
    [Serializable]
    public class TelemetryLap : ISerializable
    {
        public TelemetryLap()
        {
            
        }

        public TelemetryLap(string circuitName, string lapType)
        {
            Packets = new List<TelemetryPacket>();
            CircuitName = circuitName;
            LapType = lapType;
        }

        public TelemetryLap(SerializationInfo info, StreamingContext context) 
        {
            Packets = info.GetValue<List<TelemetryPacket>>("Packets");
            CircuitName = info.GetValue<string>("CircuitName");
            LapType = info.GetValue<string>("LapType");
            try
            {
                _hasFinished = info.GetValue<bool>("HasFinished");
            }
            catch
            {
                _hasFinished = true;
            }

            try
            {
                _timeBraking = info.GetValue<float>("TimeBraking");
                _gearChanges = info.GetValue<float>("GearChanges");
                _topSpeed = info.GetValue<float>("TopSpeed");
            }
            catch
            {
            }
        }

        private List<TelemetryPacket> _packets;

        [XmlArray("Packets"), XmlArrayItem("Packet", typeof (TelemetryPacket))] 
        public List<TelemetryPacket> Packets 
        {
            get { return _packets; }
            set { _packets = value; }
        }

        private string _circuitName;
        public string CircuitName 
        {
            get { return _circuitName; }
            set { _circuitName = value; }
        }

        private string _lapType;
        public string LapType 
        {
            get { return _lapType;  }
            set { _lapType = value; }
        }

        private float _topSpeed;
        public float TopSpeed
        {
            get { return _topSpeed; }
            set { _topSpeed = value; }
        }

        private float _gearChanges;
        public float GearChanges
        {
            get { return _gearChanges; }
            set { _gearChanges = value; }
        }

        private float _timeBraking;
        public float TimeBraking
        {
            get { return _timeBraking; }
            set { _timeBraking = value; }
        }

        public float CurrentSpeedKMh
        {
            get { return _packets.Last().SpeedInKmPerHour; }            
        }

        public void AddPacket(TelemetryPacket packet)
        {
            Packets.Add(packet);

            if (packet.SpeedInKmPerHour > _topSpeed)
                _topSpeed = packet.SpeedInKmPerHour;

            if (packet.Gear > 0)
                _gearChanges++;

            if (packet.Brake > 0)
                _timeBraking++;

            //while (_packets.Any() && _packets.First().Distance < 0)
            //    _packets.Remove(_packets.First());
        }

        public int LapNumber
        {
            get
            {
                if (!Packets.Any())
                    return 0;

                return (int)Packets.Last().Lap;
            }
        }

        public float LapTime
        {
            get
            {
                return !Packets.Any() ? 0f : Packets.Last().LapTime;
            }
        }

        public bool IsFirstPacketStartLine 
        {
            get
            {
                const float cutoff = (1000 / 60000f) + 0.001f;

                if (!Packets.Any())
                    return false;
                return true;
                //var first = Packets.First();
                //return first.LapTime >= 0f && first.LapTime < cutoff;                
            }
        }

        private bool _hasFinished;
        public bool HasLapFinished
        {
            get { return _hasFinished;  }            
        }
        
        public TelemetryPacket GetPacketClosestTo(TelemetryPacket packet)
        {
            if (!Packets.Any())
                return packet;

            var closestPackets = Packets.OrderBy(p => Math.Abs(p.LapDistance - packet.LapDistance)).Take(10);

            return closestPackets.First();
        }
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CircuitName", _circuitName);
            info.AddValue("LapType", _lapType);
            info.AddValue("Packets", _packets);
            info.AddValue("HasFinished", _hasFinished);

            info.AddValue("TimeBraking", _timeBraking);
            info.AddValue("GearChanges", _gearChanges);
            info.AddValue("TopSpeed", _topSpeed);            

        }

        public bool IsOutLap
        {
            // An outlap can either be less than 0 or less than 1
            get { return Packets.All(c => c.Distance < 1 && Math.Abs(c.LapTime - 0) < Constants.Epsilon); }          
        }

        public bool IsCompleteLap
        {
            get { return IsFirstPacketStartLine && HasLapFinished; } 
        }

        public void MarkLapCompleted()
        {
            _hasFinished = true;
        }

        public float Distance 
        { 
            get
            {
                if (!Packets.Any())
                    return 0f;
                return Packets.Last().Distance;
            }
        }
    }
}
