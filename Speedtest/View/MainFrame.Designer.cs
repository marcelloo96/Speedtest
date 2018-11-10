namespace Speedtest
{
    partial class MainFrame
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
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewButtonItem1 = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.backstageViewButtonItem2 = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.backstageViewItemSeparator1 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewButtonItem3 = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.selectedPortElement = new DevExpress.XtraBars.BarEditItem();
            this.selectedPortRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.baudRateElement = new DevExpress.XtraBars.BarEditItem();
            this.baudRateRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.channelsElement = new DevExpress.XtraBars.BarEditItem();
            this.dataBitsRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.displayModeElement = new DevExpress.XtraBars.BarEditItem();
            this.displayModeRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.connectButton = new DevExpress.XtraBars.BarButtonItem();
            this.startStopButton = new DevExpress.XtraBars.BarButtonItem();
            this.portStatusLabel = new DevExpress.XtraBars.BarStaticItem();
            this.measurePage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.controlPanelGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.contentPanel = new DevExpress.XtraEditors.PanelControl();
            this.portOptionsPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.portBasicsGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.advancedPortOptionsGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dataBitsEditItem = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ParityEditItem = new DevExpress.XtraBars.BarEditItem();
            this.parityRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.stopBitEditItem = new DevExpress.XtraBars.BarEditItem();
            this.stopBitRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ReadBufferSizeEditItem = new DevExpress.XtraBars.BarEditItem();
            this.ReadBufferSizeRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.WriteBufferSizeBarEditItem = new DevExpress.XtraBars.BarEditItem();
            this.WriteBufferSizeRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.RtsEnableEditItem = new DevExpress.XtraBars.BarEditItem();
            this.RtsEnableRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.DtrEnablebarEditItem = new DevExpress.XtraBars.BarEditItem();
            this.DtrEnableRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.handShakebarEditItem = new DevExpress.XtraBars.BarEditItem();
            this.handShakeRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedPortRepositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baudRateRepositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBitsRepositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.displayModeRepositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentPanel)).BeginInit();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parityRepositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopBitRepositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReadBufferSizeRepositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WriteBufferSizeRepositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RtsEnableRepositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtrEnableRepositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.handShakeRepositoryItemComboBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonDropDownControl = this.backstageViewControl1;
            this.ribbonControl1.AutoSizeItems = true;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.selectedPortElement,
            this.baudRateElement,
            this.channelsElement,
            this.displayModeElement,
            this.connectButton,
            this.startStopButton,
            this.portStatusLabel,
            this.dataBitsEditItem,
            this.ParityEditItem,
            this.stopBitEditItem,
            this.ReadBufferSizeEditItem,
            this.WriteBufferSizeBarEditItem,
            this.RtsEnableEditItem,
            this.DtrEnablebarEditItem,
            this.handShakebarEditItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 19;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.measurePage,
            this.portOptionsPage});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.baudRateRepositoryItemComboBox,
            this.selectedPortRepositoryItemComboBox,
            this.dataBitsRepositoryItemComboBox,
            this.displayModeRepositoryItemComboBox,
            this.repositoryItemComboBox1,
            this.parityRepositoryItemComboBox,
            this.repositoryItemComboBox2,
            this.stopBitRepositoryItemComboBox,
            this.ReadBufferSizeRepositoryItemComboBox,
            this.WriteBufferSizeRepositoryItemComboBox,
            this.RtsEnableRepositoryItemComboBox,
            this.DtrEnableRepositoryItemComboBox,
            this.handShakeRepositoryItemComboBox});
            this.ribbonControl1.Size = new System.Drawing.Size(1198, 185);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // backstageViewControl1
            // 
            this.backstageViewControl1.Items.Add(this.backstageViewButtonItem1);
            this.backstageViewControl1.Items.Add(this.backstageViewButtonItem2);
            this.backstageViewControl1.Items.Add(this.backstageViewItemSeparator1);
            this.backstageViewControl1.Items.Add(this.backstageViewButtonItem3);
            this.backstageViewControl1.Location = new System.Drawing.Point(28, 62);
            this.backstageViewControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.OwnerControl = this.ribbonControl1;
            this.backstageViewControl1.Size = new System.Drawing.Size(953, 287);
            this.backstageViewControl1.TabIndex = 0;
            this.backstageViewControl1.Text = "backstageViewControl1";
            // 
            // backstageViewButtonItem1
            // 
            this.backstageViewButtonItem1.Caption = "backstageViewButtonItem1";
            this.backstageViewButtonItem1.Name = "backstageViewButtonItem1";
            // 
            // backstageViewButtonItem2
            // 
            this.backstageViewButtonItem2.Caption = "backstageViewButtonItem2";
            this.backstageViewButtonItem2.Name = "backstageViewButtonItem2";
            // 
            // backstageViewItemSeparator1
            // 
            this.backstageViewItemSeparator1.Name = "backstageViewItemSeparator1";
            // 
            // backstageViewButtonItem3
            // 
            this.backstageViewButtonItem3.Caption = "backstageViewButtonItem3";
            this.backstageViewButtonItem3.Name = "backstageViewButtonItem3";
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
            this.channelsElement.Edit = this.dataBitsRepositoryItemComboBox;
            this.channelsElement.EditHeight = 20;
            this.channelsElement.EditWidth = 100;
            this.channelsElement.Id = 3;
            this.channelsElement.Name = "channelsElement";
            // 
            // dataBitsRepositoryItemComboBox
            // 
            this.dataBitsRepositoryItemComboBox.AutoHeight = false;
            this.dataBitsRepositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataBitsRepositoryItemComboBox.Name = "dataBitsRepositoryItemComboBox";
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
            // portStatusLabel
            // 
            this.portStatusLabel.Id = 8;
            this.portStatusLabel.Name = "portStatusLabel";
            // 
            // measurePage
            // 
            this.measurePage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.controlPanelGroup});
            this.measurePage.Name = "measurePage";
            this.measurePage.Text = "Measure";
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
            this.ribbonStatusBar1.ItemLinks.Add(this.portStatusLabel);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 564);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1198, 28);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.backstageViewControl1);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 185);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1198, 379);
            this.contentPanel.TabIndex = 2;
            // 
            // portOptionsPage
            // 
            this.portOptionsPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.portBasicsGroup,
            this.advancedPortOptionsGroup});
            this.portOptionsPage.Name = "portOptionsPage";
            this.portOptionsPage.Text = "Port Options";
            // 
            // portBasicsGroup
            // 
            this.portBasicsGroup.ItemLinks.Add(this.selectedPortElement);
            this.portBasicsGroup.ItemLinks.Add(this.baudRateElement);
            this.portBasicsGroup.ItemLinks.Add(this.channelsElement);
            this.portBasicsGroup.Name = "portBasicsGroup";
            this.portBasicsGroup.Text = "Basics";
            // 
            // advancedPortOptionsGroup
            // 
            this.advancedPortOptionsGroup.ItemLinks.Add(this.dataBitsEditItem, true);
            this.advancedPortOptionsGroup.ItemLinks.Add(this.ParityEditItem);
            this.advancedPortOptionsGroup.ItemLinks.Add(this.stopBitEditItem);
            this.advancedPortOptionsGroup.ItemLinks.Add(this.RtsEnableEditItem, true);
            this.advancedPortOptionsGroup.ItemLinks.Add(this.DtrEnablebarEditItem);
            this.advancedPortOptionsGroup.ItemLinks.Add(this.handShakebarEditItem);
            this.advancedPortOptionsGroup.ItemLinks.Add(this.WriteBufferSizeBarEditItem, true);
            this.advancedPortOptionsGroup.ItemLinks.Add(this.ReadBufferSizeEditItem);
            this.advancedPortOptionsGroup.Name = "advancedPortOptionsGroup";
            this.advancedPortOptionsGroup.Text = "Advanced";
            // 
            // dataBitsEditItem
            // 
            this.dataBitsEditItem.Caption = "Data Bits";
            this.dataBitsEditItem.Edit = this.dataBitsRepositoryItemComboBox;
            this.dataBitsEditItem.EditHeight = 20;
            this.dataBitsEditItem.EditWidth = 100;
            this.dataBitsEditItem.Id = 9;
            this.dataBitsEditItem.Name = "dataBitsEditItem";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // ParityEditItem
            // 
            this.ParityEditItem.Caption = "Parity";
            this.ParityEditItem.Edit = this.parityRepositoryItemComboBox;
            this.ParityEditItem.EditHeight = 20;
            this.ParityEditItem.EditWidth = 100;
            this.ParityEditItem.Id = 10;
            this.ParityEditItem.Name = "ParityEditItem";
            // 
            // parityRepositoryItemComboBox
            // 
            this.parityRepositoryItemComboBox.AutoHeight = false;
            this.parityRepositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.parityRepositoryItemComboBox.Name = "parityRepositoryItemComboBox";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // stopBitEditItem
            // 
            this.stopBitEditItem.Caption = "Stop Bit";
            this.stopBitEditItem.Edit = this.stopBitRepositoryItemComboBox;
            this.stopBitEditItem.EditHeight = 20;
            this.stopBitEditItem.EditWidth = 100;
            this.stopBitEditItem.Id = 13;
            this.stopBitEditItem.Name = "stopBitEditItem";
            // 
            // stopBitRepositoryItemComboBox
            // 
            this.stopBitRepositoryItemComboBox.AutoHeight = false;
            this.stopBitRepositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.stopBitRepositoryItemComboBox.Name = "stopBitRepositoryItemComboBox";
            // 
            // ReadBufferSizeEditItem
            // 
            this.ReadBufferSizeEditItem.Caption = "Read Buffer size";
            this.ReadBufferSizeEditItem.Edit = this.ReadBufferSizeRepositoryItemComboBox;
            this.ReadBufferSizeEditItem.EditHeight = 20;
            this.ReadBufferSizeEditItem.EditWidth = 100;
            this.ReadBufferSizeEditItem.Id = 14;
            this.ReadBufferSizeEditItem.Name = "ReadBufferSizeEditItem";
            // 
            // ReadBufferSizeRepositoryItemComboBox
            // 
            this.ReadBufferSizeRepositoryItemComboBox.AutoHeight = false;
            this.ReadBufferSizeRepositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReadBufferSizeRepositoryItemComboBox.Name = "ReadBufferSizeRepositoryItemComboBox";
            // 
            // WriteBufferSizeBarEditItem
            // 
            this.WriteBufferSizeBarEditItem.Caption = "Write Buffer Size";
            this.WriteBufferSizeBarEditItem.Edit = this.WriteBufferSizeRepositoryItemComboBox;
            this.WriteBufferSizeBarEditItem.EditHeight = 20;
            this.WriteBufferSizeBarEditItem.EditWidth = 100;
            this.WriteBufferSizeBarEditItem.Id = 15;
            this.WriteBufferSizeBarEditItem.Name = "WriteBufferSizeBarEditItem";
            // 
            // WriteBufferSizeRepositoryItemComboBox
            // 
            this.WriteBufferSizeRepositoryItemComboBox.AutoHeight = false;
            this.WriteBufferSizeRepositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.WriteBufferSizeRepositoryItemComboBox.Name = "WriteBufferSizeRepositoryItemComboBox";
            // 
            // RtsEnableEditItem
            // 
            this.RtsEnableEditItem.Caption = "RTS Enable";
            this.RtsEnableEditItem.Edit = this.RtsEnableRepositoryItemComboBox;
            this.RtsEnableEditItem.EditHeight = 20;
            this.RtsEnableEditItem.EditWidth = 100;
            this.RtsEnableEditItem.Id = 16;
            this.RtsEnableEditItem.Name = "RtsEnableEditItem";
            // 
            // RtsEnableRepositoryItemComboBox
            // 
            this.RtsEnableRepositoryItemComboBox.AutoHeight = false;
            this.RtsEnableRepositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RtsEnableRepositoryItemComboBox.Name = "RtsEnableRepositoryItemComboBox";
            // 
            // DtrEnablebarEditItem
            // 
            this.DtrEnablebarEditItem.Caption = "DTR Enable";
            this.DtrEnablebarEditItem.Edit = this.DtrEnableRepositoryItemComboBox;
            this.DtrEnablebarEditItem.EditHeight = 20;
            this.DtrEnablebarEditItem.EditWidth = 100;
            this.DtrEnablebarEditItem.Id = 17;
            this.DtrEnablebarEditItem.Name = "DtrEnablebarEditItem";
            // 
            // DtrEnableRepositoryItemComboBox
            // 
            this.DtrEnableRepositoryItemComboBox.AutoHeight = false;
            this.DtrEnableRepositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtrEnableRepositoryItemComboBox.Name = "DtrEnableRepositoryItemComboBox";
            // 
            // handShakebarEditItem
            // 
            this.handShakebarEditItem.Caption = "Handshake";
            this.handShakebarEditItem.Edit = this.handShakeRepositoryItemComboBox;
            this.handShakebarEditItem.EditHeight = 20;
            this.handShakebarEditItem.EditWidth = 100;
            this.handShakebarEditItem.Id = 18;
            this.handShakebarEditItem.Name = "handShakebarEditItem";
            // 
            // handShakeRepositoryItemComboBox
            // 
            this.handShakeRepositoryItemComboBox.AutoHeight = false;
            this.handShakeRepositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.handShakeRepositoryItemComboBox.Name = "handShakeRepositoryItemComboBox";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 592);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainFrame";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedPortRepositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baudRateRepositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBitsRepositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.displayModeRepositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentPanel)).EndInit();
            this.contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parityRepositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopBitRepositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReadBufferSizeRepositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WriteBufferSizeRepositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RtsEnableRepositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtrEnableRepositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.handShakeRepositoryItemComboBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage measurePage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarEditItem selectedPortElement;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox baudRateRepositoryItemComboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox selectedPortRepositoryItemComboBox;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarEditItem channelsElement;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox dataBitsRepositoryItemComboBox;
        private DevExpress.XtraBars.BarEditItem displayModeElement;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox displayModeRepositoryItemComboBox;
        private DevExpress.XtraBars.BarButtonItem connectButton;
        private DevExpress.XtraBars.BarButtonItem startStopButton;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup controlPanelGroup;
        private DevExpress.XtraBars.BarEditItem baudRateElement;
        private DevExpress.XtraEditors.PanelControl contentPanel;
        private DevExpress.XtraBars.BarStaticItem portStatusLabel;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem backstageViewButtonItem1;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem backstageViewButtonItem2;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator1;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem backstageViewButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPage portOptionsPage;
        private DevExpress.XtraBars.BarEditItem dataBitsEditItem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup portBasicsGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup advancedPortOptionsGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private DevExpress.XtraBars.BarEditItem ParityEditItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox parityRepositoryItemComboBox;
        private DevExpress.XtraBars.BarEditItem stopBitEditItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox stopBitRepositoryItemComboBox;
        private DevExpress.XtraBars.BarEditItem ReadBufferSizeEditItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ReadBufferSizeRepositoryItemComboBox;
        private DevExpress.XtraBars.BarEditItem WriteBufferSizeBarEditItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox WriteBufferSizeRepositoryItemComboBox;
        private DevExpress.XtraBars.BarEditItem RtsEnableEditItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox RtsEnableRepositoryItemComboBox;
        private DevExpress.XtraBars.BarEditItem DtrEnablebarEditItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox DtrEnableRepositoryItemComboBox;
        private DevExpress.XtraBars.BarEditItem handShakebarEditItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox handShakeRepositoryItemComboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
    }
}