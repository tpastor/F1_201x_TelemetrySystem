using F1Speed.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace F1Speed
{
    public enum DeltaType
    {
        TimeDelta, SpeedDelta
    }

    public partial class DeltaGraphcs : Form
    {

        private const String RT1 = "RT1";
        private const String RT2 = "RT2";
        TelemetryLapManager TelemetryLapManager;
        bool started = false;
        DeltaType deltatype;
        Timer timer = new Timer();
        public DeltaGraphcs(TelemetryLapManager TelemetryLapManager, DeltaType deltatype)
        {
            this.deltatype = deltatype;
            this.TelemetryLapManager = TelemetryLapManager;

            InitializeComponent();

            if (TelemetryLapManager.FastestLap != null)
                started = true;

            GraphPane myPane = zedGraphControl1.GraphPane;

            {
                PointPairList pl = new PointPairList();
                var myCurve = myPane.AddCurve(RT1, pl, Color.Red, SymbolType.None);
                myPane.Title.Text = deltatype.ToString();
                myPane.XAxis.Title.Text = "NormalizedDistance";
                myPane.YAxis.Title.Text = deltatype.ToString();
                myCurve.Line.Width = 3.0F;
            }
            {
                PointPairList pl = new PointPairList();
                var myCurve = myPane.AddCurve(RT2, pl, Color.Blue, SymbolType.None);
                myPane.Title.Text = deltatype.ToString();
                myPane.XAxis.Title.Text = "NormalizedDistance";
                myPane.YAxis.Title.Text = deltatype.ToString();
                myCurve.Line.Width = 3.0F;
            }

            atual = RT1;
            TelemetryLapManager.PacketProcessed += TelemetryLapManager_PacketProcessed;
            TelemetryLapManager.CompletedFullLap += TelemetryLapManager_CompletedFullLap;
            TelemetryLapManager.FinishedOutLap += TelemetryLapManager_FinishedOutLap;

            timer.Interval = F1SpeedSettings.RefreshRate;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void TelemetryLapManager_FinishedOutLap(object sender, LapEventArgs e)
        {           
            GraphPane myPane = zedGraphControl1.GraphPane;
            var curve = myPane.CurveList.First(
                (a) =>
                    a.Label.Text == atual
                );
            curve.Clear();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        String atual = "";
        void TelemetryLapManager_CompletedFullLap(object sender, CompletedFullLapEventArgs e)
        {
            if (atual == RT1)
                atual = RT2;
            else
                atual = RT1;

            started = true;
            GraphPane myPane = zedGraphControl1.GraphPane;
            var curve = myPane.CurveList.First(
                (a) =>
                    a.Label.Text == atual
                );
            curve.Clear();
            
        }


        void TelemetryLapManager_PacketProcessed(object sender, PacketEventArgs e)
        {
            if (started)
            {
                var lastPacket = e.Packet;
                GraphPane myPane = zedGraphControl1.GraphPane;
                var curve = myPane.CurveList.First(
                    (a) =>
                        a.Label.Text == atual
                    );

                IPointListEdit list = curve.Points as IPointListEdit;
                if (list == null)
                    return;

                if (deltatype == DeltaType.SpeedDelta)
                {
                    list.Add(lastPacket.DistanceMapped, TelemetryLapManager.GetSpeedDeltaValue());
                }
                else
                {
                    list.Add(lastPacket.DistanceMapped, TelemetryLapManager.GetTimeDelta());
                }
            }
        }

        private void DeltaGraphcs_FormClosed(object sender, FormClosedEventArgs e)
        {
            TelemetryLapManager.PacketProcessed -= TelemetryLapManager_PacketProcessed;
            TelemetryLapManager.CompletedFullLap -= TelemetryLapManager_CompletedFullLap;                        
        }

        private void DeltaGraphcs_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void SetSize()
        {
            // Control is always 10 pixels inset from the client rectangle of the form
            Rectangle formRect = this.ClientRectangle;
            formRect.Inflate(-10, -10);

            if (zedGraphControl1.Size != formRect.Size)
            {
                zedGraphControl1.Location = formRect.Location;
                zedGraphControl1.Size = formRect.Size;
            }
        }
    }
}
