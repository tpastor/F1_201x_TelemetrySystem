﻿namespace F1Speed
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DeltaLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExpectedLapLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AverageLapLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CurrentLapLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ComparisonLapLabel = new System.Windows.Forms.Label();
            this.ComparisonModeLabel = new System.Windows.Forms.Label();
            this.BarGroup = new System.Windows.Forms.GroupBox();
            this.TimeDeltaLabel = new System.Windows.Forms.Label();
            this.SlowerBarLabel = new System.Windows.Forms.Label();
            this.FasterBarLabel = new System.Windows.Forms.Label();
            this.ControlsGroup = new System.Windows.Forms.GroupBox();
            this.TransmissionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LapTypeDropDown = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CircuitDropDown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ThrottleBar = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BrakeBar = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCompareLapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearReferenceLapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFastestLapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportFastestLapToF1PerfViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genericToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeDeltaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedDeltaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allLapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogBox = new System.Windows.Forms.ListBox();
            this.BackRightWheelSpin = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.FrontRightWheelSpin = new System.Windows.Forms.Label();
            this.FrontLeftWheelSpin = new System.Windows.Forms.Label();
            this.BackLeftWheelSpin = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.BarGroup.SuspendLayout();
            this.ControlsGroup.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeltaLabel
            // 
            this.DeltaLabel.AutoSize = true;
            this.DeltaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 96F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeltaLabel.ForeColor = System.Drawing.Color.White;
            this.DeltaLabel.Location = new System.Drawing.Point(6, 53);
            this.DeltaLabel.Name = "DeltaLabel";
            this.DeltaLabel.Size = new System.Drawing.Size(227, 147);
            this.DeltaLabel.TabIndex = 2;
            this.DeltaLabel.Text = "--.-";
            this.DeltaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.UpdateDisplay);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Speed Delta km/hr";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DeltaLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 271);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.ExpectedLapLabel);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.AverageLapLabel);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.CurrentLapLabel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.ComparisonLapLabel);
            this.groupBox2.Controls.Add(this.ComparisonModeLabel);
            this.groupBox2.Location = new System.Drawing.Point(524, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 272);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // ExpectedLapLabel
            // 
            this.ExpectedLapLabel.AutoSize = true;
            this.ExpectedLapLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpectedLapLabel.ForeColor = System.Drawing.Color.White;
            this.ExpectedLapLabel.Location = new System.Drawing.Point(171, 177);
            this.ExpectedLapLabel.Name = "ExpectedLapLabel";
            this.ExpectedLapLabel.Size = new System.Drawing.Size(214, 51);
            this.ExpectedLapLabel.TabIndex = 11;
            this.ExpectedLapLabel.Text = "1:55.5555";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(6, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 26);
            this.label8.TabIndex = 10;
            this.label8.Text = "Expected Lap";
            // 
            // AverageLapLabel
            // 
            this.AverageLapLabel.AutoSize = true;
            this.AverageLapLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AverageLapLabel.ForeColor = System.Drawing.Color.White;
            this.AverageLapLabel.Location = new System.Drawing.Point(171, 71);
            this.AverageLapLabel.Name = "AverageLapLabel";
            this.AverageLapLabel.Size = new System.Drawing.Size(214, 51);
            this.AverageLapLabel.TabIndex = 9;
            this.AverageLapLabel.Text = "1:55.5555";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(6, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 26);
            this.label7.TabIndex = 8;
            this.label7.Text = "Average Lap";
            // 
            // CurrentLapLabel
            // 
            this.CurrentLapLabel.AutoSize = true;
            this.CurrentLapLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentLapLabel.ForeColor = System.Drawing.Color.White;
            this.CurrentLapLabel.Location = new System.Drawing.Point(171, 126);
            this.CurrentLapLabel.Name = "CurrentLapLabel";
            this.CurrentLapLabel.Size = new System.Drawing.Size(214, 51);
            this.CurrentLapLabel.TabIndex = 7;
            this.CurrentLapLabel.Text = "1:55.5555";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(6, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 26);
            this.label5.TabIndex = 6;
            this.label5.Text = "Current Lap";
            // 
            // ComparisonLapLabel
            // 
            this.ComparisonLapLabel.AutoSize = true;
            this.ComparisonLapLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComparisonLapLabel.ForeColor = System.Drawing.Color.White;
            this.ComparisonLapLabel.Location = new System.Drawing.Point(171, 17);
            this.ComparisonLapLabel.Name = "ComparisonLapLabel";
            this.ComparisonLapLabel.Size = new System.Drawing.Size(214, 51);
            this.ComparisonLapLabel.TabIndex = 5;
            this.ComparisonLapLabel.Text = "1:55.5555";
            // 
            // ComparisonModeLabel
            // 
            this.ComparisonModeLabel.AutoSize = true;
            this.ComparisonModeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComparisonModeLabel.ForeColor = System.Drawing.Color.White;
            this.ComparisonModeLabel.Location = new System.Drawing.Point(6, 28);
            this.ComparisonModeLabel.Name = "ComparisonModeLabel";
            this.ComparisonModeLabel.Size = new System.Drawing.Size(125, 26);
            this.ComparisonModeLabel.TabIndex = 4;
            this.ComparisonModeLabel.Text = "Fastest Lap";
            // 
            // BarGroup
            // 
            this.BarGroup.BackColor = System.Drawing.Color.Transparent;
            this.BarGroup.Controls.Add(this.label12);
            this.BarGroup.Controls.Add(this.TimeDeltaLabel);
            this.BarGroup.Controls.Add(this.SlowerBarLabel);
            this.BarGroup.Controls.Add(this.FasterBarLabel);
            this.BarGroup.Location = new System.Drawing.Point(215, 380);
            this.BarGroup.Name = "BarGroup";
            this.BarGroup.Size = new System.Drawing.Size(707, 141);
            this.BarGroup.TabIndex = 7;
            this.BarGroup.TabStop = false;
            // 
            // TimeDeltaLabel
            // 
            this.TimeDeltaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeDeltaLabel.ForeColor = System.Drawing.Color.White;
            this.TimeDeltaLabel.Location = new System.Drawing.Point(271, 65);
            this.TimeDeltaLabel.Name = "TimeDeltaLabel";
            this.TimeDeltaLabel.Size = new System.Drawing.Size(171, 40);
            this.TimeDeltaLabel.TabIndex = 2;
            this.TimeDeltaLabel.Text = "0.0";
            this.TimeDeltaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SlowerBarLabel
            // 
            this.SlowerBarLabel.BackColor = System.Drawing.Color.Red;
            this.SlowerBarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlowerBarLabel.ForeColor = System.Drawing.Color.White;
            this.SlowerBarLabel.Location = new System.Drawing.Point(22, 19);
            this.SlowerBarLabel.Name = "SlowerBarLabel";
            this.SlowerBarLabel.Size = new System.Drawing.Size(333, 37);
            this.SlowerBarLabel.TabIndex = 1;
            // 
            // FasterBarLabel
            // 
            this.FasterBarLabel.BackColor = System.Drawing.Color.Green;
            this.FasterBarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FasterBarLabel.ForeColor = System.Drawing.Color.White;
            this.FasterBarLabel.Location = new System.Drawing.Point(361, 19);
            this.FasterBarLabel.Name = "FasterBarLabel";
            this.FasterBarLabel.Size = new System.Drawing.Size(333, 37);
            this.FasterBarLabel.TabIndex = 0;
            // 
            // ControlsGroup
            // 
            this.ControlsGroup.Controls.Add(this.TransmissionLabel);
            this.ControlsGroup.Controls.Add(this.label2);
            this.ControlsGroup.Controls.Add(this.LapTypeDropDown);
            this.ControlsGroup.Controls.Add(this.label4);
            this.ControlsGroup.Controls.Add(this.CircuitDropDown);
            this.ControlsGroup.Controls.Add(this.label3);
            this.ControlsGroup.Location = new System.Drawing.Point(12, 33);
            this.ControlsGroup.Name = "ControlsGroup";
            this.ControlsGroup.Size = new System.Drawing.Size(911, 62);
            this.ControlsGroup.TabIndex = 8;
            this.ControlsGroup.TabStop = false;
            // 
            // TransmissionLabel
            // 
            this.TransmissionLabel.BackColor = System.Drawing.Color.Green;
            this.TransmissionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransmissionLabel.ForeColor = System.Drawing.Color.White;
            this.TransmissionLabel.Location = new System.Drawing.Point(883, 13);
            this.TransmissionLabel.Name = "TransmissionLabel";
            this.TransmissionLabel.Size = new System.Drawing.Size(22, 35);
            this.TransmissionLabel.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(842, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tx";
            // 
            // LapTypeDropDown
            // 
            this.LapTypeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LapTypeDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LapTypeDropDown.FormattingEnabled = true;
            this.LapTypeDropDown.Items.AddRange(new object[] {
            "Practice",
            "Qualifying",
            "Race",
            "Time Trial",
            "On-line Qualifying",
            "On-line Race"});
            this.LapTypeDropDown.Location = new System.Drawing.Point(473, 16);
            this.LapTypeDropDown.Name = "LapTypeDropDown";
            this.LapTypeDropDown.Size = new System.Drawing.Size(351, 37);
            this.LapTypeDropDown.TabIndex = 7;
            this.LapTypeDropDown.SelectedIndexChanged += new System.EventHandler(this.LapTypeDropDown_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(408, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "Type";
            // 
            // CircuitDropDown
            // 
            this.CircuitDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CircuitDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircuitDropDown.FormattingEnabled = true;
            this.CircuitDropDown.Location = new System.Drawing.Point(93, 16);
            this.CircuitDropDown.Name = "CircuitDropDown";
            this.CircuitDropDown.Size = new System.Drawing.Size(289, 37);
            this.CircuitDropDown.TabIndex = 5;
            this.CircuitDropDown.SelectedIndexChanged += new System.EventHandler(this.CircuitDropDown_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Circuit";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox5.Controls.Add(this.ThrottleBar);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.BrakeBar);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(13, 381);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(164, 140);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            // 
            // ThrottleBar
            // 
            this.ThrottleBar.BackColor = System.Drawing.Color.Green;
            this.ThrottleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThrottleBar.ForeColor = System.Drawing.Color.White;
            this.ThrottleBar.Location = new System.Drawing.Point(84, 23);
            this.ThrottleBar.Name = "ThrottleBar";
            this.ThrottleBar.Size = new System.Drawing.Size(51, 74);
            this.ThrottleBar.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(89, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Throttle";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrakeBar
            // 
            this.BrakeBar.BackColor = System.Drawing.Color.Red;
            this.BrakeBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrakeBar.ForeColor = System.Drawing.Color.White;
            this.BrakeBar.Location = new System.Drawing.Point(18, 22);
            this.BrakeBar.Name = "BrakeBar";
            this.BrakeBar.Size = new System.Drawing.Size(51, 74);
            this.BrakeBar.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(22, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Brake";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.graphToolStripMenuItem,
            this.allLapsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(935, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importCompareLapToolStripMenuItem,
            this.clearReferenceLapToolStripMenuItem,
            this.exportFastestLapToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exportFastestLapToF1PerfViewToolStripMenuItem,
            this.toolStripMenuItem1,
            this.optionsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // importCompareLapToolStripMenuItem
            // 
            this.importCompareLapToolStripMenuItem.Name = "importCompareLapToolStripMenuItem";
            this.importCompareLapToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.importCompareLapToolStripMenuItem.Text = "Load Reference Lap";
            this.importCompareLapToolStripMenuItem.Click += new System.EventHandler(this.importCompareLapToolStripMenuItem_Click);
            // 
            // clearReferenceLapToolStripMenuItem
            // 
            this.clearReferenceLapToolStripMenuItem.Enabled = false;
            this.clearReferenceLapToolStripMenuItem.Name = "clearReferenceLapToolStripMenuItem";
            this.clearReferenceLapToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.clearReferenceLapToolStripMenuItem.Text = "Clear Reference Lap";
            this.clearReferenceLapToolStripMenuItem.Click += new System.EventHandler(this.clearReferenceLapToolStripMenuItem_Click);
            // 
            // exportFastestLapToolStripMenuItem
            // 
            this.exportFastestLapToolStripMenuItem.Name = "exportFastestLapToolStripMenuItem";
            this.exportFastestLapToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.exportFastestLapToolStripMenuItem.Text = "Save Fastest Lap";
            this.exportFastestLapToolStripMenuItem.Click += new System.EventHandler(this.exportFastestLapToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(240, 6);
            // 
            // exportFastestLapToF1PerfViewToolStripMenuItem
            // 
            this.exportFastestLapToF1PerfViewToolStripMenuItem.Name = "exportFastestLapToF1PerfViewToolStripMenuItem";
            this.exportFastestLapToF1PerfViewToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.exportFastestLapToF1PerfViewToolStripMenuItem.Text = "Export Fastest Lap to F1PerfView";
            this.exportFastestLapToF1PerfViewToolStripMenuItem.Click += new System.EventHandler(this.exportFastestLapToF1PerfViewToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(240, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(240, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // graphToolStripMenuItem
            // 
            this.graphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genericToolStripMenuItem,
            this.timeDeltaToolStripMenuItem,
            this.speedDeltaToolStripMenuItem});
            this.graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            this.graphToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.graphToolStripMenuItem.Text = "Graph";
            // 
            // genericToolStripMenuItem
            // 
            this.genericToolStripMenuItem.Name = "genericToolStripMenuItem";
            this.genericToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.genericToolStripMenuItem.Text = "Generic";
            this.genericToolStripMenuItem.Click += new System.EventHandler(this.genericToolStripMenuItem_Click);
            // 
            // timeDeltaToolStripMenuItem
            // 
            this.timeDeltaToolStripMenuItem.Name = "timeDeltaToolStripMenuItem";
            this.timeDeltaToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.timeDeltaToolStripMenuItem.Text = "Time Delta";
            this.timeDeltaToolStripMenuItem.Click += new System.EventHandler(this.timeDeltaToolStripMenuItem_Click);
            // 
            // speedDeltaToolStripMenuItem
            // 
            this.speedDeltaToolStripMenuItem.Name = "speedDeltaToolStripMenuItem";
            this.speedDeltaToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.speedDeltaToolStripMenuItem.Text = "Speed Delta";
            this.speedDeltaToolStripMenuItem.Click += new System.EventHandler(this.speedDeltaToolStripMenuItem_Click);
            // 
            // allLapsToolStripMenuItem
            // 
            this.allLapsToolStripMenuItem.Name = "allLapsToolStripMenuItem";
            this.allLapsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.allLapsToolStripMenuItem.Text = "All Laps";
            this.allLapsToolStripMenuItem.Click += new System.EventHandler(this.allLapsToolStripMenuItem_Click);
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.Color.Black;
            this.LogBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogBox.ForeColor = System.Drawing.Color.DarkGray;
            this.LogBox.FormattingEnabled = true;
            this.LogBox.ItemHeight = 20;
            this.LogBox.Location = new System.Drawing.Point(13, 527);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(909, 384);
            this.LogBox.TabIndex = 11;
            // 
            // BackRightWheelSpin
            // 
            this.BackRightWheelSpin.BackColor = System.Drawing.Color.Yellow;
            this.BackRightWheelSpin.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackRightWheelSpin.ForeColor = System.Drawing.Color.White;
            this.BackRightWheelSpin.Location = new System.Drawing.Point(488, 250);
            this.BackRightWheelSpin.Name = "BackRightWheelSpin";
            this.BackRightWheelSpin.Size = new System.Drawing.Size(30, 74);
            this.BackRightWheelSpin.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(431, 210);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 23);
            this.label13.TabIndex = 16;
            this.label13.Text = "Wheelspin";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrontRightWheelSpin
            // 
            this.FrontRightWheelSpin.BackColor = System.Drawing.Color.Yellow;
            this.FrontRightWheelSpin.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrontRightWheelSpin.ForeColor = System.Drawing.Color.White;
            this.FrontRightWheelSpin.Location = new System.Drawing.Point(488, 131);
            this.FrontRightWheelSpin.Name = "FrontRightWheelSpin";
            this.FrontRightWheelSpin.Size = new System.Drawing.Size(30, 74);
            this.FrontRightWheelSpin.TabIndex = 13;
            // 
            // FrontLeftWheelSpin
            // 
            this.FrontLeftWheelSpin.BackColor = System.Drawing.Color.Yellow;
            this.FrontLeftWheelSpin.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrontLeftWheelSpin.ForeColor = System.Drawing.Color.White;
            this.FrontLeftWheelSpin.Location = new System.Drawing.Point(427, 131);
            this.FrontLeftWheelSpin.Name = "FrontLeftWheelSpin";
            this.FrontLeftWheelSpin.Size = new System.Drawing.Size(30, 74);
            this.FrontLeftWheelSpin.TabIndex = 12;
            // 
            // BackLeftWheelSpin
            // 
            this.BackLeftWheelSpin.BackColor = System.Drawing.Color.Yellow;
            this.BackLeftWheelSpin.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackLeftWheelSpin.ForeColor = System.Drawing.Color.White;
            this.BackLeftWheelSpin.Location = new System.Drawing.Point(427, 250);
            this.BackLeftWheelSpin.Name = "BackLeftWheelSpin";
            this.BackLeftWheelSpin.Size = new System.Drawing.Size(30, 74);
            this.BackLeftWheelSpin.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(271, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(171, 40);
            this.label12.TabIndex = 3;
            this.label12.Text = "0.0";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(6, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 26);
            this.label10.TabIndex = 12;
            this.label10.Text = "Speed";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(88, 242);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 26);
            this.label11.TabIndex = 13;
            this.label11.Text = "0000";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(198, 242);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(122, 26);
            this.label14.TabIndex = 14;
            this.label14.Text = "Max Speed";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(326, 242);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 26);
            this.label15.TabIndex = 15;
            this.label15.Text = "0000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(935, 781);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.BackRightWheelSpin);
            this.Controls.Add(this.BackLeftWheelSpin);
            this.Controls.Add(this.FrontRightWheelSpin);
            this.Controls.Add(this.FrontLeftWheelSpin);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ControlsGroup);
            this.Controls.Add(this.BarGroup);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.BarGroup.ResumeLayout(false);
            this.ControlsGroup.ResumeLayout(false);
            this.ControlsGroup.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DeltaLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label ComparisonModeLabel;
        private System.Windows.Forms.Label ComparisonLapLabel;
        private System.Windows.Forms.GroupBox BarGroup;
        private System.Windows.Forms.Label FasterBarLabel;
        private System.Windows.Forms.Label SlowerBarLabel;
        private System.Windows.Forms.Label TimeDeltaLabel;
        private System.Windows.Forms.GroupBox ControlsGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CircuitDropDown;
        private System.Windows.Forms.ComboBox LapTypeDropDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label ThrottleBar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label BrakeBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label CurrentLapLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCompareLapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportFastestLapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearReferenceLapToolStripMenuItem;
        private System.Windows.Forms.Label AverageLapLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportFastestLapToF1PerfViewToolStripMenuItem;
        private System.Windows.Forms.Label TransmissionLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ListBox LogBox;
        private System.Windows.Forms.Label BackRightWheelSpin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label FrontRightWheelSpin;
        private System.Windows.Forms.Label FrontLeftWheelSpin;
        private System.Windows.Forms.Label BackLeftWheelSpin;
        private System.Windows.Forms.ToolStripMenuItem graphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genericToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allLapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeDeltaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speedDeltaToolStripMenuItem;
        private System.Windows.Forms.Label ExpectedLapLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}