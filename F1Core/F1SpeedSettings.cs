﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace F1Speed.Core
{
    public static class F1SpeedSettings
    {
        private const string RefreshRateKey = "RefreshRateData";
        private const string LogPacketDataKey = "LogPacketData";
        private const string SaveAllLapsKey = "SaveAllLaps";
        private const string SendFastestLapToServerKey = "SendFastestLapToServer";
        private const string AllowConnectionsFromOtherMachinesKey = "AllowConnectionsFromOtherMachines";
        private const string APIKeyKey = "APIKey";
        
        static F1SpeedSettings()
        {
            if (File.Exists(FilePath))
            {

                // Load from files.            
                using (var reader = new XmlTextReader(FilePath))
                {
                    var settingsDoc = XDocument.Load(reader);

                    var data = (from setting in settingsDoc.Descendants("Settings")
                                select new
                                           {
                                               RefreshRate = (setting.Element(RefreshRateKey) == null ? "100" : setting.Element(RefreshRateKey).Value),
                                               SendFastestLapToServer = (setting.Element(SendFastestLapToServerKey) == null ? "false" : setting.Element(SendFastestLapToServerKey).Value),
                                               SaveAllLaps = (setting.Element(SaveAllLapsKey) == null ? "false" : setting.Element(SaveAllLapsKey).Value),
                                               AllowConnectionsFromOtherMachines = (setting.Element(AllowConnectionsFromOtherMachinesKey) == null ? "false" : setting.Element(AllowConnectionsFromOtherMachinesKey).Value),
                                               APIKey = (setting.Element(APIKeyKey) == null ? "" : setting.Element(APIKeyKey).Value),
                                               LogPacketData = (setting.Element(LogPacketDataKey) == null ? "false" : setting.Element(LogPacketDataKey).Value)
                                           }).First();

                    RefreshRate = Int32.Parse(data.RefreshRate);
                    SendFastestLapToServer = bool.Parse(data.SendFastestLapToServer);
                    AllowConnectionsFromOtherMachines = bool.Parse(data.AllowConnectionsFromOtherMachines);
                    LogPacketData = bool.Parse(data.LogPacketData);
                    APIKey = data.APIKey;
                    SaveAllLaps = bool.Parse(data.SaveAllLaps);                    
                }
            }
            else
            {
                RefreshRate = 100;
                AllowConnectionsFromOtherMachines = false;
                APIKey = "";
                SendFastestLapToServer = false;
                SaveAllLaps = false;
            }
        }

        public static int RefreshRate { get; set; }

        public static bool LogPacketData { get; set; }

        public static bool SendFastestLapToServer { get; set; }

        public static string APIKey { get; set; }

        public static bool AllowConnectionsFromOtherMachines { get; set; }

        public static bool SaveAllLaps { get; set; }

        public static void Save()
        {
            if (File.Exists(FilePath))
                File.Delete(FilePath);

            using (var writer = new XmlTextWriter(FilePath, Encoding.UTF8))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Settings");

                writer.WriteElementString(RefreshRateKey, RefreshRate.ToString());
                writer.WriteElementString(AllowConnectionsFromOtherMachinesKey, AllowConnectionsFromOtherMachines.ToString());
                writer.WriteElementString(SendFastestLapToServerKey, SendFastestLapToServer.ToString());
                writer.WriteElementString(APIKeyKey, APIKey);
                writer.WriteElementString(LogPacketDataKey, LogPacketData.ToString());
                writer.WriteElementString(SaveAllLapsKey, SaveAllLaps.ToString());
                
                
                writer.WriteEndElement();
                writer.WriteEndDocument();
                
                writer.Flush();
            }
        }

        private static string FilePath
        {
            get
            {
                var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var userFilePath = Path.Combine(localAppData, "F1Speed", "Settings");

                if (!Directory.Exists(userFilePath))
                    Directory.CreateDirectory(userFilePath);

                return userFilePath + @"\f1speed_settings.xml";
            }
        }    
    }
}
