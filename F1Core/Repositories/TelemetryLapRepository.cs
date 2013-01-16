using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
#if DEBUG
using log4net;
#endif

namespace F1Speed.Core.Repositories
{
    public abstract class TelemetryLapRepository
    {
#if DEBUG
        protected static ILog logger = Logger.Create();
#endif

        protected string DataFolder()
        {
            var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var userFilePath = Path.Combine(localAppData, "F1Speed", "Data");

            try
            {
                if (!Directory.Exists(userFilePath))
                    Directory.CreateDirectory(userFilePath);
            }
            catch (Exception ex)
            {
#if DEBUG
                logger.Error("Count not create directory for data", ex);
#endif
                throw ex;
            }

            return userFilePath;
        }

        public abstract void Save(TelemetryLap lap);

        public abstract TelemetryLap Get(string circuitName, string lapType);

        public abstract string GetFileExtension();

        protected virtual string GetFileName(TelemetryLap lap)
        {
            return GetFileName(lap.CircuitName, lap.LapType);
        }

        protected virtual string GetFileName(string circuitName, string lapType)
        {                        
            return string.Format(@"{0}\{1}_FL_{2}.{3}", DataFolder(), circuitName, lapType, GetFileExtension());
        }

        public void Delete(TelemetryLap lap)
        {
            try
            {
                var filename = GetFileName(lap);
                if (File.Exists(filename))
                    File.Delete(filename);
            }
            catch (Exception ex)
            {
#if DEBUG
                logger.Error("Count not delete Telemetry Lap", ex);
#endif
                throw ex;
            }
        }
    }
}
