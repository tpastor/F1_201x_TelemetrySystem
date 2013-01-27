using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Xml.Serialization;
using System.Threading;
using System.Net;
using System.Runtime.InteropServices;

namespace UDPDataGenerator
{
    /// <summary>
    /// replay a stored file of telemetry data
    /// </summary>
    class Program
    {
        // Constants
        private static int PORTNUM = 20777;
        private static string IP = "127.0.0.1";

        // This is the IP endpoint we are connecting to (i.e. the IP and Port F1 2011 is sending to)
        private static IPEndPoint remoteIP = new IPEndPoint(IPAddress.Parse(IP), PORTNUM);
        // This is the IP endpoint for capturing who actually sent the data
        private static IPEndPoint senderIP = new IPEndPoint(IPAddress.Any, 0);
        
        static IPEndPoint groupEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), PORTNUM);


        static void Main(string[] args)
        {

            List<telemetryPacket> latestData = new List<telemetryPacket>();

            UdpClient udpSocket = new UdpClient();
            udpSocket.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            FileStream FileStream = File.Open("captura.xml", FileMode.Open);
            XmlSerializer XmlSerializer = new System.Xml.Serialization.XmlSerializer(latestData.GetType());
            latestData = (List<telemetryPacket>)XmlSerializer.Deserialize(FileStream);
            FileStream.Close();


            foreach (var item in latestData)
            {
                byte[] bts = StructureToByteArray(item);
                udpSocket.Send(bts, bts.Length, groupEP);
                Console.WriteLine(item);
                Thread.Sleep(TimeSpan.FromSeconds(1.0 / 60.0));
            }            
        }

        static byte[] StructureToByteArray(object obj)
        {
            int len = Marshal.SizeOf(obj);
            byte[] arr = new byte[len];
            IntPtr ptr = Marshal.AllocHGlobal(len);
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, arr, 0, len);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }
    }
}
