using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace F1Speed.Core.Repositories
{
    public class BinaryTelemetryLapRepository : TelemetryLapRepository, ITelemetryLapRepository
    {        
        public override void Save(TelemetryLap lap)
        {
            Save(lap, GetFileName(lap.CircuitName, lap.LapType));
        }

        public void Save(TelemetryLap lap, string fileName)
        {
            try
            {

                if (lap == null)
                    return;


                if (File.Exists(fileName))
                    File.Delete(fileName);

                using (Stream stream = File.Open(fileName, FileMode.Create))
                {
                    var binFormatter = new BinaryFormatter();
                    binFormatter.Serialize(stream, lap);
                    stream.Close();
                }
            } catch (Exception ex)
            {
                #if DEBUG
                logger.Error("Count not save binary telemetry lap", ex);
#endif
                throw ex;
            }
        }

        public override TelemetryLap Get(string circuitName, string lapType)
        {
            return Get(GetFileName(circuitName, lapType));
        }

        public TelemetryLap Get(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                    return null;

                using (var stream = File.Open(fileName, FileMode.Open))
                {
                    try
                    {
                        var binFormatter = new BinaryFormatter();
                        var lap = (TelemetryLap) binFormatter.Deserialize(stream);                        
                        return lap;
                    }
                    catch (SerializationException dex)
                    {
                        #if DEBUG
                        logger.Error("Could not retreive binary telemetry lap", dex);
#endif
                        throw dex;                        
                    }
                    catch (Exception ex)
                    {
                        #if DEBUG
                        logger.Error("Could not retreive binary telemetry lap", ex);
#endif
                        throw ex;
                    }
                    finally
                    {
                        stream.Close();
                    }
                    return null;
                }
            } catch (Exception ex)
            {
                #if DEBUG
                logger.Error("Could not retreive binary telemetry lap", ex);
#endif
                throw ex;
            }
        }

        public override string GetFileExtension()
        {
            return "f1s";
        }
    }
}
