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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.stautsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.camCtl)).BeginInit();
            this.tool.SuspendLayout();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
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
            this.focusList});
            this.tool.Location = new System.Drawing.Point(0, 25);
            this.tool.Name = "tool";
            this.tool.Size = new System.Drawing.Size(640, 25);
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
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(640, 25);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCamera,
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
            this.status.Size = new System.Drawing.Size(640, 22);
            this.status.TabIndex = 3;
            this.status.Text = "statusStrip1";
            // 
            // stautsLabel
            // 
            this.stautsLabel.Name = "stautsLabel";
            this.stautsLabel.Size = new System.Drawing.Size(49, 17);
            this.stautsLabel.Text = "CamCtl";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 558);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tool);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.camCtl);
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(336, 357);
            this.Name = "MainForm";
            this.Text = "CamCtl";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.camCtl)).EndInit();
            this.tool.ResumeLayout(false);
            this.tool.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
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
    }
}

