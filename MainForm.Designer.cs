namespace CamCtl
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.camCtl = new TIS.Imaging.ICImagingControl();
            this.tool = new System.Windows.Forms.ToolStrip();
            this.btnPlay = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCapture = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFocus = new System.Windows.Forms.ToolStripButton();
            this.focusList = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHisto = new System.Windows.Forms.ToolStripButton();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.stautsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupInterferometer = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.boxSerial = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.boxInfo = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDatum = new System.Windows.Forms.Button();
            this.ledMeasure = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.groupRail = new System.Windows.Forms.GroupBox();
            this.btnJog = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.boxStep = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.barDir = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.boxSpeed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.boxAddr = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.boxPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupMeasure = new System.Windows.Forms.GroupBox();
            this.proBar = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.checkExtra = new System.Windows.Forms.CheckBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.boxPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.boxTotalCount = new System.Windows.Forms.TextBox();
            this.boxTotalLen = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.serial = new System.IO.Ports.SerialPort(this.components);
            this.saveLog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.camCtl)).BeginInit();
            this.tool.SuspendLayout();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
            this.groupInterferometer.SuspendLayout();
            this.groupRail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barDir)).BeginInit();
            this.groupMeasure.SuspendLayout();
            this.SuspendLayout();
            // 
            // camCtl
            // 
            this.camCtl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.camCtl.BackColor = System.Drawing.Color.White;
            this.camCtl.DeviceListChangedExecutionMode = TIS.Imaging.EventExecutionMode.Invoke;
            this.camCtl.DeviceLostExecutionMode = TIS.Imaging.EventExecutionMode.AsyncInvoke;
            this.camCtl.ImageAvailableExecutionMode = TIS.Imaging.EventExecutionMode.MultiThreaded;
            this.camCtl.LiveDisplayPosition = new System.Drawing.Point(0, 0);
            this.camCtl.Location = new System.Drawing.Point(0, 53);
            this.camCtl.Name = "camCtl";
            this.camCtl.Size = new System.Drawing.Size(640, 480);
            this.camCtl.TabIndex = 0;
            this.camCtl.OverlayUpdate += new System.EventHandler<TIS.Imaging.ICImagingControl.OverlayUpdateEventArgs>(this.camCtl_OverlayUpdate);
            this.camCtl.ImageAvailable += new System.EventHandler<TIS.Imaging.ICImagingControl.ImageAvailableEventArgs>(this.camCtl_ImageAvailable);
            this.camCtl.LivePrepared += new System.EventHandler(this.camCtl_LivePrepared);
            this.camCtl.DeviceLost += new System.EventHandler<TIS.Imaging.ICImagingControl.DeviceLostEventArgs>(this.camCtl_DeviceLost);
            this.camCtl.SizeChanged += new System.EventHandler(this.camCtl_SizeChanged);
            // 
            // tool
            // 
            this.tool.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPlay,
            this.btnStop,
            this.btnConfig,
            this.toolStripSeparator2,
            this.btnCapture,
            this.toolStripSeparator3,
            this.btnFocus,
            this.focusList,
            this.toolStripSeparator4,
            this.btnHisto});
            this.tool.Location = new System.Drawing.Point(0, 25);
            this.tool.Name = "tool";
            this.tool.Size = new System.Drawing.Size(959, 25);
            this.tool.TabIndex = 1;
            this.tool.Text = "toolStrip1";
            // 
            // btnPlay
            // 
            this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(23, 22);
            this.btnPlay.Text = "Play";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(23, 22);
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(23, 22);
            this.btnConfig.Text = "Config";
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCapture
            // 
            this.btnCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCapture.Image = ((System.Drawing.Image)(resources.GetObject("btnCapture.Image")));
            this.btnCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(23, 22);
            this.btnCapture.Text = "Capture";
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFocus
            // 
            this.btnFocus.CheckOnClick = true;
            this.btnFocus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFocus.Image = ((System.Drawing.Image)(resources.GetObject("btnFocus.Image")));
            this.btnFocus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFocus.Name = "btnFocus";
            this.btnFocus.Size = new System.Drawing.Size(23, 22);
            this.btnFocus.Text = "Focus";
            this.btnFocus.CheckedChanged += new System.EventHandler(this.btnFocus_CheckedChanged);
            // 
            // focusList
            // 
            this.focusList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.focusList.Items.AddRange(new object[] {
            "32",
            "64",
            "96",
            "128",
            "160",
            "192",
            "224"});
            this.focusList.MergeIndex = 0;
            this.focusList.Name = "focusList";
            this.focusList.Size = new System.Drawing.Size(75, 25);
            this.focusList.ToolTipText = "Threshold";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnHisto
            // 
            this.btnHisto.CheckOnClick = true;
            this.btnHisto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHisto.Image = ((System.Drawing.Image)(resources.GetObject("btnHisto.Image")));
            this.btnHisto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHisto.Name = "btnHisto";
            this.btnHisto.Size = new System.Drawing.Size(23, 22);
            this.btnHisto.Text = "Histogram";
            this.btnHisto.CheckedChanged += new System.EventHandler(this.btnHisto_CheckedChanged);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(959, 25);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCamera,
            this.saveImage,
            this.toolStripSeparator1,
            this.menuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openCamera
            // 
            this.openCamera.Name = "openCamera";
            this.openCamera.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openCamera.Size = new System.Drawing.Size(204, 22);
            this.openCamera.Text = "Open Camera";
            this.openCamera.Click += new System.EventHandler(this.openCamera_Click);
            // 
            // saveImage
            // 
            this.saveImage.Name = "saveImage";
            this.saveImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveImage.Size = new System.Drawing.Size(204, 22);
            this.saveImage.Text = "Save Image";
            this.saveImage.Click += new System.EventHandler(this.saveImage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuExit.Size = new System.Drawing.Size(204, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stautsLabel});
            this.status.Location = new System.Drawing.Point(0, 536);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(959, 22);
            this.status.TabIndex = 3;
            this.status.Text = "statusStrip1";
            // 
            // stautsLabel
            // 
            this.stautsLabel.Name = "stautsLabel";
            this.stautsLabel.Size = new System.Drawing.Size(49, 17);
            this.stautsLabel.Text = "CamCtl";
            // 
            // groupInterferometer
            // 
            this.groupInterferometer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupInterferometer.Controls.Add(this.label11);
            this.groupInterferometer.Controls.Add(this.boxSerial);
            this.groupInterferometer.Controls.Add(this.label10);
            this.groupInterferometer.Controls.Add(this.boxInfo);
            this.groupInterferometer.Controls.Add(this.btnConnect);
            this.groupInterferometer.Controls.Add(this.btnDatum);
            this.groupInterferometer.Controls.Add(this.ledMeasure);
            this.groupInterferometer.Location = new System.Drawing.Point(646, 53);
            this.groupInterferometer.Name = "groupInterferometer";
            this.groupInterferometer.Size = new System.Drawing.Size(307, 150);
            this.groupInterferometer.TabIndex = 4;
            this.groupInterferometer.TabStop = false;
            this.groupInterferometer.Text = "Interferometer Control";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "Serial";
            // 
            // boxSerial
            // 
            this.boxSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxSerial.Location = new System.Drawing.Point(53, 89);
            this.boxSerial.Name = "boxSerial";
            this.boxSerial.Size = new System.Drawing.Size(248, 21);
            this.boxSerial.TabIndex = 14;
            this.boxSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "Status";
            // 
            // boxInfo
            // 
            this.boxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxInfo.Location = new System.Drawing.Point(53, 62);
            this.boxInfo.Name = "boxInfo";
            this.boxInfo.ReadOnly = true;
            this.boxInfo.Size = new System.Drawing.Size(248, 21);
            this.boxInfo.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(226, 121);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDatum
            // 
            this.btnDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDatum.Enabled = false;
            this.btnDatum.Location = new System.Drawing.Point(6, 121);
            this.btnDatum.Name = "btnDatum";
            this.btnDatum.Size = new System.Drawing.Size(75, 23);
            this.btnDatum.TabIndex = 1;
            this.btnDatum.Text = "Datum";
            this.btnDatum.UseVisualStyleBackColor = true;
            this.btnDatum.Click += new System.EventHandler(this.btnDatum_Click);
            // 
            // ledMeasure
            // 
            this.ledMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ledMeasure.ArrayCount = 12;
            this.ledMeasure.ColorBackground = System.Drawing.Color.Black;
            this.ledMeasure.ColorDark = System.Drawing.Color.DarkSlateGray;
            this.ledMeasure.ColorLight = System.Drawing.Color.Aqua;
            this.ledMeasure.DecimalShow = true;
            this.ledMeasure.ElementPadding = new System.Windows.Forms.Padding(4);
            this.ledMeasure.ElementWidth = 10;
            this.ledMeasure.ItalicFactor = 0F;
            this.ledMeasure.Location = new System.Drawing.Point(6, 20);
            this.ledMeasure.Name = "ledMeasure";
            this.ledMeasure.Size = new System.Drawing.Size(295, 36);
            this.ledMeasure.TabIndex = 0;
            this.ledMeasure.TabStop = false;
            this.ledMeasure.Value = null;
            // 
            // groupRail
            // 
            this.groupRail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupRail.Controls.Add(this.btnJog);
            this.groupRail.Controls.Add(this.btnRefresh);
            this.groupRail.Controls.Add(this.label6);
            this.groupRail.Controls.Add(this.label5);
            this.groupRail.Controls.Add(this.boxStep);
            this.groupRail.Controls.Add(this.label4);
            this.groupRail.Controls.Add(this.barDir);
            this.groupRail.Controls.Add(this.label3);
            this.groupRail.Controls.Add(this.boxSpeed);
            this.groupRail.Controls.Add(this.label2);
            this.groupRail.Controls.Add(this.boxAddr);
            this.groupRail.Controls.Add(this.btnOpen);
            this.groupRail.Controls.Add(this.boxPort);
            this.groupRail.Controls.Add(this.label1);
            this.groupRail.Location = new System.Drawing.Point(646, 209);
            this.groupRail.Name = "groupRail";
            this.groupRail.Size = new System.Drawing.Size(307, 154);
            this.groupRail.TabIndex = 5;
            this.groupRail.TabStop = false;
            this.groupRail.Text = "Rail Control";
            // 
            // btnJog
            // 
            this.btnJog.Enabled = false;
            this.btnJog.Location = new System.Drawing.Point(82, 125);
            this.btnJog.Name = "btnJog";
            this.btnJog.Size = new System.Drawing.Size(143, 23);
            this.btnJog.TabIndex = 13;
            this.btnJog.Text = "Jog";
            this.btnJog.UseVisualStyleBackColor = true;
            this.btnJog.Click += new System.EventHandler(this.btnJog_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(145, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(226, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "Forward";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Step";
            // 
            // boxStep
            // 
            this.boxStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxStep.Location = new System.Drawing.Point(253, 46);
            this.boxStep.Name = "boxStep";
            this.boxStep.Size = new System.Drawing.Size(48, 21);
            this.boxStep.TabIndex = 9;
            this.boxStep.Text = "1";
            this.boxStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxStep.TextChanged += new System.EventHandler(this.boxStep_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Reverse";
            // 
            // barDir
            // 
            this.barDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.barDir.Location = new System.Drawing.Point(87, 74);
            this.barDir.Maximum = 1;
            this.barDir.Name = "barDir";
            this.barDir.Size = new System.Drawing.Size(133, 45);
            this.barDir.TabIndex = 7;
            this.barDir.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.barDir.Value = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Speed";
            // 
            // boxSpeed
            // 
            this.boxSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxSpeed.Location = new System.Drawing.Point(150, 46);
            this.boxSpeed.Name = "boxSpeed";
            this.boxSpeed.Size = new System.Drawing.Size(48, 21);
            this.boxSpeed.TabIndex = 5;
            this.boxSpeed.Text = "16";
            this.boxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Addr";
            // 
            // boxAddr
            // 
            this.boxAddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxAddr.Location = new System.Drawing.Point(41, 46);
            this.boxAddr.Name = "boxAddr";
            this.boxAddr.Size = new System.Drawing.Size(48, 21);
            this.boxAddr.TabIndex = 3;
            this.boxAddr.Text = "1";
            this.boxAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(226, 18);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Connect";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // boxPort
            // 
            this.boxPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxPort.FormattingEnabled = true;
            this.boxPort.Location = new System.Drawing.Point(41, 20);
            this.boxPort.Name = "boxPort";
            this.boxPort.Size = new System.Drawing.Size(98, 20);
            this.boxPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // groupMeasure
            // 
            this.groupMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupMeasure.Controls.Add(this.proBar);
            this.groupMeasure.Controls.Add(this.btnStart);
            this.groupMeasure.Controls.Add(this.checkExtra);
            this.groupMeasure.Controls.Add(this.btnPath);
            this.groupMeasure.Controls.Add(this.boxPath);
            this.groupMeasure.Controls.Add(this.label9);
            this.groupMeasure.Controls.Add(this.label8);
            this.groupMeasure.Controls.Add(this.boxTotalCount);
            this.groupMeasure.Controls.Add(this.boxTotalLen);
            this.groupMeasure.Controls.Add(this.label7);
            this.groupMeasure.Location = new System.Drawing.Point(646, 381);
            this.groupMeasure.Name = "groupMeasure";
            this.groupMeasure.Size = new System.Drawing.Size(307, 152);
            this.groupMeasure.TabIndex = 6;
            this.groupMeasure.TabStop = false;
            this.groupMeasure.Text = "Measure Config";
            // 
            // proBar
            // 
            this.proBar.Location = new System.Drawing.Point(8, 20);
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(293, 23);
            this.proBar.TabIndex = 9;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(159, 49);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(142, 48);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "START\r\nMEASUREMENT";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // checkExtra
            // 
            this.checkExtra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkExtra.AutoSize = true;
            this.checkExtra.Location = new System.Drawing.Point(89, 130);
            this.checkExtra.Name = "checkExtra";
            this.checkExtra.Size = new System.Drawing.Size(168, 16);
            this.checkExtra.TabIndex = 7;
            this.checkExtra.Text = "Output extra length data";
            this.checkExtra.UseVisualStyleBackColor = true;
            // 
            // btnPath
            // 
            this.btnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPath.Location = new System.Drawing.Point(269, 103);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(32, 21);
            this.btnPath.TabIndex = 6;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // boxPath
            // 
            this.boxPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boxPath.Location = new System.Drawing.Point(89, 103);
            this.boxPath.Name = "boxPath";
            this.boxPath.Size = new System.Drawing.Size(174, 21);
            this.boxPath.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "Image Folder";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "Total Images";
            // 
            // boxTotalCount
            // 
            this.boxTotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boxTotalCount.Location = new System.Drawing.Point(89, 76);
            this.boxTotalCount.Name = "boxTotalCount";
            this.boxTotalCount.Size = new System.Drawing.Size(64, 21);
            this.boxTotalCount.TabIndex = 2;
            this.boxTotalCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxTotalCount.TextChanged += new System.EventHandler(this.boxTotalCount_TextChanged);
            // 
            // boxTotalLen
            // 
            this.boxTotalLen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boxTotalLen.Location = new System.Drawing.Point(89, 49);
            this.boxTotalLen.Name = "boxTotalLen";
            this.boxTotalLen.Size = new System.Drawing.Size(64, 21);
            this.boxTotalLen.TabIndex = 1;
            this.boxTotalLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxTotalLen.TextChanged += new System.EventHandler(this.boxTotalLen_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "Total Length";
            // 
            // serial
            // 
            this.serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serial_DataReceived);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 558);
            this.Controls.Add(this.groupMeasure);
            this.Controls.Add(this.groupRail);
            this.Controls.Add(this.groupInterferometer);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tool);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.camCtl);
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(975, 597);
            this.Name = "MainForm";
            this.Text = "CamCtl - with Interferometer and Rail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Move += new System.EventHandler(this.MainForm_Move);
            ((System.ComponentModel.ISupportInitialize)(this.camCtl)).EndInit();
            this.tool.ResumeLayout(false);
            this.tool.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.groupInterferometer.ResumeLayout(false);
            this.groupInterferometer.PerformLayout();
            this.groupRail.ResumeLayout(false);
            this.groupRail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barDir)).EndInit();
            this.groupMeasure.ResumeLayout(false);
            this.groupMeasure.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TIS.Imaging.ICImagingControl camCtl;
        private System.Windows.Forms.ToolStrip tool;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripButton btnPlay;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCamera;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCapture;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel stautsLabel;
        private System.Windows.Forms.ToolStripButton btnFocus;
        private System.Windows.Forms.ToolStripComboBox focusList;
        private System.Windows.Forms.ToolStripMenuItem saveImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnHisto;
        private System.Windows.Forms.GroupBox groupInterferometer;
        private System.Windows.Forms.TextBox boxInfo;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDatum;
        private DmitryBrant.CustomControls.SevenSegmentArray ledMeasure;
        private System.Windows.Forms.GroupBox groupRail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar barDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox boxAddr;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox boxPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupMeasure;
        private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox boxStep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox boxTotalCount;
        private System.Windows.Forms.TextBox boxTotalLen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FolderBrowserDialog saveLog;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox checkExtra;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.TextBox boxPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox boxSerial;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar proBar;
        private System.Windows.Forms.Button btnJog;
    }
}

