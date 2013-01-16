using F1Speed.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace F1Speed
{
    public partial class AllLaps : Form
    {
        TelemetryLapManager telemetryLapManager;
        Timer t1 = new Timer();
        bool refreshEnabled = true;

        public AllLaps(TelemetryLapManager telemetryLapManager)
        {
            this.telemetryLapManager = telemetryLapManager;
            InitializeComponent();
            LoadDataTable();
            t1 = new Timer();
            t1.Interval = 500;
            t1.Tick += new EventHandler(t1_Tick);
            t1.Start();
        }

        void t1_Tick(object sender, EventArgs e)
        {
            LoadDataTable();
            this.dataGridView1.Invalidate();
            this.dataGridView1.Refresh();
        }

        private void LoadDataTable()
        {
            DataTable dt = new DataTable("Laps");
            CreateColumn(dt, "LapNumber", typeof(String));
            CreateColumn(dt, "LapTime", typeof(String));
            CreateColumn(dt, "LapFinished", typeof(String));
            CreateColumn(dt, "CircuitName", typeof(String));
            CreateColumn(dt, "LapType", typeof(String));
            CreateColumn(dt, "IsOutLap", typeof(String));

            foreach (var item in telemetryLapManager.Laps)
            {
                DataRow dr = CreateRow(dt);
                dr[0] = item.LapNumber;
                dr[1] = item.LapTime;
                dr[2] = item.HasLapFinished;
                dr[3] = item.CircuitName;
                dr[4] = item.LapType;
                dr[5] = item.IsOutLap; 
            }

            dataGridView1.DataSource = dt;            
        }

        private void CreateColumn(DataTable table, String name, Type type)
        {
            DataColumn dc1 = new DataColumn();
            dc1.DataType = type;
            dc1.ColumnName = name;
            table.Columns.Add(dc1);
        }

        private DataRow CreateRow(DataTable table)
        {
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return row;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            List<TelemetryLap> laps = new List<TelemetryLap>();
            foreach (var item in this.dataGridView1.SelectedRows)
            {
                DataGridViewRow row = (DataGridViewRow)item;
                laps.Add(telemetryLapManager.Laps[row.Index]);
            }

            if (laps.Count == 0)
                return;

            GraphOptions GraphOptions = new GraphOptions(laps);
            GraphOptions.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                InitialDirectory = DataFolder(),
                Filter = "F1Speed|*.f1a",
                Title = "Import All Laps",
                Multiselect = false
            };
            var result = openDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrEmpty(openDialog.FileName))
            {
                if (File.Exists(openDialog.FileName))
                    File.Delete(openDialog.FileName);

                using (Stream stream = File.Open(openDialog.FileName, FileMode.Create))
                {
                    var binFormatter = new BinaryFormatter();
                    SessionLaps allLaps = (SessionLaps)binFormatter.Deserialize(stream);
                    stream.Close();
                    telemetryLapManager.SetAllLaps(allLaps);
                }       
                
            }
            LoadDataTable();
            this.dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var saveDialog = new SaveFileDialog
            {
                InitialDirectory  = DataFolder(),
                Filter = "F1Speed|*.f1a",
                Title = "Save All Laps",             
            };
            var result = saveDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrEmpty(saveDialog.FileName))
            {
                if (File.Exists(saveDialog.FileName))
                    File.Delete(saveDialog.FileName);

                using (Stream stream = File.Open(saveDialog.FileName, FileMode.Create))
                {
                    var allLaps = telemetryLapManager.GetAllLaps();
                    var binFormatter = new BinaryFormatter();
                    binFormatter.Serialize(stream, allLaps);
                    stream.Close();
                }                        
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (refreshEnabled)
            {
                this.button4.Text = "Start Refresh";
                t1.Stop();
            }
            else
            {
                this.button4.Text = "Stop Refresh";
                LoadDataTable();
                this.dataGridView1.Invalidate();
                this.dataGridView1.Refresh();
                t1.Start();
            }
            refreshEnabled = !refreshEnabled;            
        }
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
                throw ex;
            }

            return userFilePath;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = null;
            foreach (var item in this.dataGridView1.SelectedRows)
            {
                row = (DataGridViewRow)item;
                break;
            }

            if (row != null)
            {
                telemetryLapManager.SetReferenceLap(telemetryLapManager.Laps[row.Index]);
            }
            else
            {
                telemetryLapManager.SetReferenceLap(null);
            }
        }

    }
}
