namespace Speedtest
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.selectedPortElement = new DevExpress.XtraBars.BarEditItem();
            this.selectedPortRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.baudRateElement = new DevExpress.XtraBars.BarEditItem();
            this.baudRateRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.channelsElement = new DevExpress.XtraBars.BarEditItem();
            this.numberOfChannelsRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.displayModeElement = new DevExpress.XtraBars.BarEditItem();
            this.displayModeRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.connectButton = new DevExpress.XtraBars.BarButtonItem();
            this.startStopButton = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.controlPanelGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.contentPanel = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedPortRepositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baudRateRepositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfChannelsRepositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.displayModeRepositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AutoSizeItems = true;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.selectedPortElement,
            this.baudRateElement,
            this.channelsElement,
            this.displayModeElement,
            this.connectButton,
            this.startStopButton});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.baudRateRepositoryItemComboBox,
            this.selectedPortRepositoryItemComboBox,
            this.numberOfChannelsRepositoryItemComboBox,
            this.displayModeRepositoryItemComboBox});
            this.ribbonControl1.Size = new System.Drawing.Size(968, 146);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // selectedPortElement
            // 
            this.selectedPortElement.AccessibleName = "";
            this.selectedPortElement.Caption = "Selected Port:";
            this.selectedPortElement.Edit = this.selectedPortRepositoryItemComboBox;
            this.selectedPortElement.EditHeight = 20;
            this.selectedPortElement.EditWidth = 100;
            this.selectedPortElement.Id = 1;
            this.selectedPortElement.Name = "selectedPortElement";
            // 
            // selectedPortRepositoryItemComboBox
            // 
            this.selectedPortRepositoryItemComboBox.AutoHeight = false;
            this.selectedPortRepositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.selectedPortRepositoryItemComboBox.Name = "selectedPortRepositoryItemComboBox";
            // 
            // baudRateElement
            // 
            this.baudRateElement.Caption = "Baud Rate:";
            this.baudRateElement.Edit = this.baudRateRepositoryItemComboBox;
            this.baudRateElement.EditHeight = 20;
            this.baudRateElement.EditWidth = 100;
            this.baudRateElement.Id = 2;
            this.baudRateElement.Name = "baudRateElement";
            // 
            // baudRateRepositoryItemComboBox
            // 
            this.baudRateRepositoryItemComboBox.AutoHeight = false;
            this.baudRateRepositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.baudRateRepositoryItemComboBox.Name = "baudRateRepositoryItemComboBox";
            // 
            // channelsElement
            // 
            this.channelsElement.Caption = "Number of Channels:";
            this.channelsElement.Edit = this.numberOfChannelsRepositoryItemComboBox;
            this.channelsElement.EditHeight = 20;
            this.channelsElement.EditWidth = 100;
            this.channelsElement.Id = 3;
            this.channelsElement.Name = "channelsElement";
            // 
            // numberOfChannelsRepositoryItemComboBox
            // 
            this.numberOfChannelsRepositoryItemComboBox.AutoHeight = false;
            this.numberOfChannelsRepositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.numberOfChannelsRepositoryItemComboBox.Name = "numberOfChannelsRepositoryItemComboBox";
            // 
            // displayModeElement
            // 
            this.displayModeElement.Caption = "Display Mode:";
            this.displayModeElement.Edit = this.displayModeRepositoryItemComboBox;
            this.displayModeElement.EditWidth = 100;
            this.displayModeElement.Hint = "To select display mode, you have to connect to the selected Serial Port.";
            this.displayModeElement.Id = 5;
            this.displayModeElement.Name = "displayModeElement";
            // 
            // displayModeRepositoryItemComboBox
            // 
            this.displayModeRepositoryItemComboBox.AutoHeight = false;
            this.displayModeRepositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.displayModeRepositoryItemComboBox.Name = "displayModeRepositoryItemComboBox";
            // 
            // connectButton
            // 
            this.connectButton.Caption = "Connect";
            this.connectButton.Id = 6;
            this.connectButton.ImageOptions.SvgImage = global::Speedtest.Properties.Resources.connect;
            this.connectButton.Name = "connectButton";
            this.connectButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.connectButton_ItemClick);
            // 
            // startStopButton
            // 
            this.startStopButton.Caption = "Start";
            this.startStopButton.Id = 7;
            this.startStopButton.ImageOptions.SvgImage = global::Speedtest.Properties.Resources.start;
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.startStopButton_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.controlPanelGroup});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Measure";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.selectedPortElement);
            this.ribbonPageGroup1.ItemLinks.Add(this.baudRateElement);
            this.ribbonPageGroup1.ItemLinks.Add(this.channelsElement);
            this.ribbonPageGroup1.ItemLinks.Add(this.connectButton, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Port Options";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.displayModeElement);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Display";
            // 
            // controlPanelGroup
            // 
            this.controlPanelGroup.AllowTextClipping = false;
            this.controlPanelGroup.ItemLinks.Add(this.startStopButton);
            this.controlPanelGroup.Name = "controlPanelGroup";
            this.controlPanelGroup.Text = "Control Panel";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 460);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(968, 21);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // contentPanel
            // 
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 146);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(968, 314);
            this.contentPanel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 481);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedPortRepositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baudRateRepositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfChannelsRepositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.displayModeRepositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarEditItem selectedPortElement;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox baudRateRepositoryItemComboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox selectedPortRepositoryItemComboBox;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarEditItem channelsElement;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox numberOfChannelsRepositoryItemComboBox;
        private DevExpress.XtraBars.BarEditItem displayModeElement;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox displayModeRepositoryItemComboBox;
        private DevExpress.XtraBars.BarButtonItem connectButton;
        private DevExpress.XtraBars.BarButtonItem startStopButton;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup controlPanelGroup;
        private DevExpress.XtraBars.BarEditItem baudRateElement;
        private DevExpress.XtraEditors.PanelControl contentPanel;
    }
}