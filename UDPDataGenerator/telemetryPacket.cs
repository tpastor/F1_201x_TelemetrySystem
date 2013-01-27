using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace UDPDataGenerator
{
        // This is the telemetry packet definition. My thanks to "korrea" for posting
        // these details on the CM forums
        [Serializable]
        public struct telemetryPacket
        {
            public static IEnumerable<String> GetFields()
            {
                FieldInfo[] infos = typeof(telemetryPacket).GetFields();
                return infos.Select<FieldInfo, String>((a) => a.Name);
            }


            public float GetFieldValue(String fieldName)
            {
                return (float) this.GetType().GetField(fieldName).GetValue(this);   
            }


            public float time;
            public float lapTime;
            public float lapDistance;
            public float distance;
            public float x;
            public float y;
            public float z;
            public float speed;
            public float xv;
            public float yv;
            public float zv;
            public float xr;
            public float yr;
            public float zr;
            public float xd;
            public float yd;
            public float zd;
            public float susp_pos_bl;
            public float susp_pos_br;
            public float susp_pos_fl;
            public float susp_pos_fr;
            public float susp_vel_bl;
            public float susp_vel_br;
            public float susp_vel_fl;
            public float susp_vel_fr;
            public float wheel_speed_bl;
            public float wheel_speed_br;
            public float wheel_speed_fl;
            public float wheel_speed_fr;
            public float throttle;
            public float steer;
            public float brake;
            public float clutch;
            public float gear;
            public float gforce_lat;
            public float gforce_lon;
            public float lap;
            public float engineRate;

            public override string ToString()
            {
                return "Lap: " + lap + " Speed: " + speed + " Time: " + time;
            }
        }    
}
