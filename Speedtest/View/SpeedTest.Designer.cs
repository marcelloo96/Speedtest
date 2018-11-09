namespace Speedtest
{
    partial class SpeedTest
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
            this.clearButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.closeButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.spCombobox = new System.Windows.Forms.ComboBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.trackBarControl1 = new DevExpress.XtraEditors.TrackBarControl();
            this.totalPoints = new System.Windows.Forms.Label();
            this.numberOfPorts = new DevExpress.XtraEditors.SpinEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPorts.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(713, 12);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearOnClick);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(632, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopOnClik);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(551, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartOnClick);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColorTransparent = true;
            this.cartesianChart1.Location = new System.Drawing.Point(12, 111);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(776, 397);
            this.cartesianChart1.TabIndex = 4;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(330, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(249, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 9;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // spCombobox
            // 
            this.spCombobox.FormattingEnabled = true;
            this.spCombobox.Location = new System.Drawing.Point(104, 12);
            this.spCombobox.Name = "spCombobox";
            this.spCombobox.Size = new System.Drawing.Size(121, 21);
            this.spCombobox.TabIndex = 8;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(411, 12);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 9;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshPortsList_Click);
            // 
            // trackBarControl1
            // 
            this.trackBarControl1.EditValue = 200;
            this.trackBarControl1.Location = new System.Drawing.Point(551, 60);
            this.trackBarControl1.Name = "trackBarControl1";
            this.trackBarControl1.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.trackBarControl1.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.trackBarControl1.Properties.Maximum = 20000;
            this.trackBarControl1.Size = new System.Drawing.Size(237, 45);
            this.trackBarControl1.TabIndex = 11;
            this.trackBarControl1.Value = 200;
            this.trackBarControl1.EditValueChanged += new System.EventHandler(this.trackBarControl1_EditValueChanged);
            // 
            // totalPoints
            // 
            this.totalPoints.AutoSize = true;
            this.totalPoints.Location = new System.Drawing.Point(437, 62);
            this.totalPoints.Name = "totalPoints";
            this.totalPoints.Size = new System.Drawing.Size(108, 13);
            this.totalPoints.TabIndex = 12;
            this.totalPoints.Text = "Megjelenített pontok:";
            // 
            // numberOfPorts
            // 
            this.numberOfPorts.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfPorts.Location = new System.Drawing.Point(104, 55);
            this.numberOfPorts.Margin = new System.Windows.Forms.Padding(2);
            this.numberOfPorts.Name = "numberOfPorts";
            this.numberOfPorts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.numberOfPorts.Size = new System.Drawing.Size(75, 20);
            this.numberOfPorts.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Number of Ports:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Select The Port:";
            // 
            // SpeedTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 517);
            this.Controls.Add(this.numberOfPorts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalPoints);
            this.Controls.Add(this.trackBarControl1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.spCombobox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "SpeedTest";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPorts.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.ComboBox spCombobox;
        private System.Windows.Forms.Button refreshButton;
        private DevExpress.XtraEditors.TrackBarControl trackBarControl1;
        private System.Windows.Forms.Label totalPoints;
        private DevExpress.XtraEditors.SpinEdit numberOfPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

