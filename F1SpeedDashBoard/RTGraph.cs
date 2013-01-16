using F1Speed.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;

namespace F1Speed
{
    public partial class RTGraph : Form
    {        
        TelemetryLapManager telemetryLapManager;
        bool cbest;
        bool clast;
        String Xlabel;
        String Ylabel;
        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();

        public RTGraph(IList<TelemetryLap> laps, bool cbest, bool clast, String xlabel, String YLabel)
        {
            this.cbest = cbest;
            this.clast = clast;
            this.Xlabel = xlabel;
            this.Ylabel = YLabel;
            InitializeComponent();
            foreach (var item in laps)
            {
                LoadLap(item, item.LapNumber.ToString(), RandomColor());
            }
        }        

        public RTGraph(TelemetryLapManager telemetryLapManager, bool cbest, bool clast, String xlabel, String YLabel)
        {
            this.cbest = cbest;
            this.clast = clast;
            this.Xlabel = xlabel;
            this.Ylabel = YLabel;

            InitializeComponent();

            this.telemetryLapManager = telemetryLapManager;
            GraphPane myPane = zedGraphControl1.GraphPane;

            if (cbest && telemetryLapManager.ComparisonLap != null)
            {
                var fastestLap = telemetryLapManager.ComparisonLap;
                LoadLap(fastestLap, "FastLap", Color.Green);
            }
            

            PointPairList pl = new PointPairList();
            var myCurve = myPane.AddCurve("RealTime", pl, Color.Red, SymbolType.None);            
            myPane.Title.Text = Xlabel + " " + Ylabel;
            myPane.XAxis.Title.Text = Xlabel;
            myPane.YAxis.Title.Text = Ylabel;
            myCurve.Line.Width = 3.0F;

            telemetryLapManager.PacketProcessed += telemetryLapManager_PacketProcessed;
            telemetryLapManager.CompletedFullLap += telemetryLapManager_CompletedFullLap;
            telemetryLapManager.SetFastestLap += telemetryLapManager_SetFastestLap;
            telemetryLapManager.FinishedOutLap += telemetryLapManager_FinishedOutLap;

            t1.Interval = F1SpeedSettings.RefreshRate;
            t1.Tick += t1_Tick;
            t1.Start();
        }

        void t1_Tick(object sender, EventArgs e)
        {
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            
        }

        void telemetryLapManager_FinishedOutLap(object sender, LapEventArgs e)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            var curve = myPane.CurveList.First(
                (a) =>
                    a.Label.Text == "RealTime"
                );
            curve.Clear();

            if (clast)
            {
                curve = myPane.CurveList.First(
                (a) =>
                    a.Label.Text == "LastLap"
                );
                curve.Clear();

                LoadLap(e.Lap, "LastLap", Color.Blue);
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        
        void telemetryLapManager_SetFastestLap(object sender, LapEventArgs e)
        {
            if (!cbest)
                return;

            GraphPane myPane = zedGraphControl1.GraphPane;

            var curve = myPane.CurveList.Find(
                (a) =>
                    a.Label.Text == "FastLap"
                );
            
            if(curve !=null)
                myPane.CurveList.Remove(curve);

            LoadLap(e.Lap, "FastLap", Color.Blue);
            
        }

        private void LoadLap(TelemetryLap lap,String lapTypeName, Color color)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            var fastestLap = lap;
            var packets = fastestLap.Packets;

            double[] x = new double[packets.Count];
            double[] y = new double[packets.Count];

            for (int i = 0; i < packets.Count; i++)
            {
                x[i] = packets[i].GetFieldValue(Xlabel);
                y[i] = packets[i].GetFieldValue(Ylabel);
            }

            // PointPairList holds the data for plotting, X and Y arrays 
            PointPairList spl1 = new PointPairList(x, y);

            // Add curves to myPane object
            LineItem myCurve1 = null;
            myCurve1 = myPane.AddCurve(lapTypeName, spl1, color, SymbolType.None);
            myCurve1.Line.Width = 3.0F;

            // Set the Titles
            myPane.Title.Text = Xlabel + " " + Ylabel;
            myPane.XAxis.Title.Text = Xlabel;
            myPane.YAxis.Title.Text = Ylabel;            

            // I add all three functions just to be sure it refeshes the plot.   
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();            
        }

        void telemetryLapManager_CompletedFullLap(object sender, CompletedFullLapEventArgs e)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            var curve = myPane.CurveList.First(
                (a) =>
                    a.Label.Text == "RealTime"
                );
            curve.Clear();

            if (clast)
            {
                curve = myPane.CurveList.First(
                (a) =>
                    a.Label.Text == "LastLap"
                );
                curve.Clear();

                LoadLap(e.CompletedLap, "LastLap", Color.Blue);                
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        void telemetryLapManager_PacketProcessed(object sender, PacketEventArgs e)
        {
            var lastPacket = e.Packet;
            GraphPane myPane = zedGraphControl1.GraphPane;
            var curve = myPane.CurveList.First(
                (a) =>
                    a.Label.Text == "RealTime"
                );
         
            IPointListEdit list = curve.Points as IPointListEdit;
            if (list == null)
                return;

            list.Add(lastPacket.GetFieldValue(Xlabel), lastPacket.GetFieldValue(Ylabel));            
        }

        private void RTGraph_Load(object sender, EventArgs e)
        {

        }
        // Set the size and location of the ZedGraphControl
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

        private void RTGraph_Resize(object sender, EventArgs e)
        {
            SetSize();
        }
            
        private void RTGraph_FormClosing(object sender, FormClosedEventArgs e)
        {
            if(telemetryLapManager!=null)
            {
                telemetryLapManager.PacketProcessed -= telemetryLapManager_PacketProcessed;
                telemetryLapManager.CompletedFullLap -= telemetryLapManager_CompletedFullLap;
                telemetryLapManager.SetFastestLap -= telemetryLapManager_SetFastestLap;
                telemetryLapManager.FinishedOutLap -= telemetryLapManager_FinishedOutLap;               
            }
                GraphPane myPane = zedGraphControl1.GraphPane;
                myPane.CurveList.Clear();            

        }

        private bool zedGraphControl1_MouseMoveEvent(ZedGraphControl sender, MouseEventArgs e)
        {            
            // Save the mouse location
            PointF mousePt = new PointF(e.X, e.Y);

            // Find the Chart rect that contains the current mouse location
            GraphPane pane = sender.MasterPane.FindChartRect(mousePt);

            // If pane is non-null, we have a valid location.  Otherwise, the mouse is not
            // within any chart rect.
            if (pane != null)
            {
                double x, y;
                // Convert the mouse location to X, and Y scale values
                pane.ReverseTransform(mousePt, out x, out y);
                // Format the status label text
                label1.Text = "(" + x.ToString("f2") + ", " + y.ToString("f2") + ")";
                label1.Visible = true;
            }
            else
            {
                // If there is no valid data, then clear the status label text
                label1.Text = string.Empty;
                label1.Visible = false;
            }

            // Return false to indicate we have not processed the MouseMoveEvent
            // ZedGraphControl should still go ahead and handle it
            return false;
        }

        Random Random = new Random();
        private Color RandomColor()
        {
            return Color.FromArgb(Random.Next(255), Random.Next(255), Random.Next(255));
        }
        
    }
}
