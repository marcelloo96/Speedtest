﻿namespace Speedtest.View.MeasureWindow
{
    partial class ChartSettingsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.propertyGridControl = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // propertyGridControl
            // 
            this.propertyGridControl.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.propertyGridControl.ActiveViewType = DevExpress.XtraVerticalGrid.PropertyGridView.Office;
            this.propertyGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridControl.Location = new System.Drawing.Point(0, 0);
            this.propertyGridControl.Name = "propertyGridControl";
            this.propertyGridControl.Size = new System.Drawing.Size(548, 437);
            this.propertyGridControl.TabIndex = 0;
            // 
            // ChartSettingsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propertyGridControl);
            this.Name = "ChartSettingsUserControl";
            this.Size = new System.Drawing.Size(548, 437);
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl;
    }
}
