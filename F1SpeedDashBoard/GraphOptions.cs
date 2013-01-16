using F1Speed.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace F1Speed
{
    public partial class GraphOptions : Form
    {
        TelemetryLapManager manager;
        IList<TelemetryLap> laps;
        public GraphOptions(TelemetryLapManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        public GraphOptions(IList<TelemetryLap> laps)
        {
            InitializeComponent();
            this.laps = laps;
            this.LapTypeDropDown.Enabled = false;
            this.comboBox1.Enabled = false;
        }

        private void GraphOptions_Load(object sender, EventArgs e)
        {
            LapTypeDropDown.Items.Add(TelemetryPacket.NormalizedDistance);
            comboBox1.Items.Add(TelemetryPacket.SpeedKM);
            
            foreach (var item in TelemetryPacket.GetFields())
	        {
                LapTypeDropDown.Items.Add(item);
                comboBox1.Items.Add(item);
	        }

            LapTypeDropDown.SelectedItem = TelemetryPacket.NormalizedDistance;
            comboBox1.SelectedItem = TelemetryPacket.SpeedKM;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (manager != null)
            {
                RTGraph rt = new RTGraph(manager, checkBox1.Checked, checkBox2.Checked, LapTypeDropDown.SelectedItem as String, comboBox1.SelectedItem as String);
                rt.Show();
            }
            else
            {
                RTGraph rt = new RTGraph(laps, false, false, LapTypeDropDown.SelectedItem as String, comboBox1.SelectedItem as String);
                rt.Show();                
            }
            this.Close();
        }
    }
}
