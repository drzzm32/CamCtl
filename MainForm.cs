using System;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.ServiceModel;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

using TIS.Imaging;

using AForge.Imaging;
using AForge.Imaging.Filters;

using Renishaw.Calibration;
using Renishaw.Calibration.Laser;
using Renishaw.Calibration.Laser.Service;
using System.IO;

namespace CamCtl
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class MainForm : Form, ILaserSystemCallback
    {
        private SynchronizationContext context;

        private Histogram histoForm;
        private LaserSystemClient laser;

        private LaserSystemClient Laser
        {
            get
            {
                if (laser == null)
                {
                    laser = LocalXLHost.CreateLaserProxy(this);
                }

                return laser;
            }
        }

        public void ConnectionStatusChanged(DeviceInfo device, ConnectionStatus value)
        {
            void update(object obj)
            {
                boxInfo.Text = value.ToString();
                if (value != ConnectionStatus.Ok)
                {
                    btnDatum.Enabled = false;
                    boxSerial.ReadOnly = false;
                }
            }
            context.Post(update, null);
        }

        public void LatestReadingUpdated(DeviceInfo device, LaserReading value)
        {
            void update(object obj)
            {
                length = value.ValueOf * 1000 * 2; // retro-measurement
                ledMeasure.Value = length.ToString("F6");
            }
            context.Post(update, null);
        }

        public void ReadingTriggered(DeviceInfo device, LaserReading value)
        {

        }

        public MainForm()
        {
            InitializeComponent();

            context = SynchronizationContext.Current;

            histoForm = new Histogram();

            focusList.SelectedIndex = 3;
        }

        private readonly PathPositions pathPosition = PathPositions.Display;
        private int threshold = 128;

        private double length;

        private void MainForm_Load(object sender, EventArgs e)
        {
            DisableButtons();

            string[] ports = SerialPort.GetPortNames();
            boxPort.Items.Clear();
            boxPort.Items.AddRange(ports);
            if (boxPort.SelectedIndex < 0)
                boxPort.SelectedIndex = 0;
        }

        private void MoveHistoForm()
        {
            histoForm.Left = Left + Width;
            histoForm.Top = Top + 32;

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            if (histoForm.Left > screenWidth)
                histoForm.Left = screenWidth - histoForm.Width;
            if (histoForm.Top > screenHeight)
                histoForm.Top = screenHeight - histoForm.Height;
        }

        private void EnableButtons()
        {
            btnStop.Enabled = true;
            btnConfig.Enabled = true;
            btnCapture.Enabled = true;
            btnFocus.Enabled = true;
        }

        private void DisableButtons()
        {
            btnStop.Enabled = false;
            btnConfig.Enabled = false;
            btnCapture.Enabled = false;
            btnFocus.Enabled = false;
        }

        private void DoCapture()
        {
            if (camCtl.DeviceValid)
            {
                var buffer = camCtl.ImageActiveBuffer;
                DateTime now = DateTime.Now;
                string name = "img_" + now.ToString("yyyyMMddHHmmss");
                buffer.SaveAsBitmap(name + ".bmp", ICImagingControlColorformats.ICY8);
            }
        }

        private void ChangeScale()
        {
            if (camCtl.DeviceValid)
            {
                float scaleX = (float)camCtl.Width / camCtl.ImageWidth;
                float scaleY = (float)camCtl.Height / camCtl.ImageHeight;
                camCtl.LiveDisplayZoomFactor = Math.Min(scaleX, scaleY);
            }
            MoveHistoForm();
        }

        private void SelectCamera()
        {
            if (camCtl.LiveVideoRunning)
                camCtl.LiveStop();
            camCtl.ShowDeviceSettingsDialog();
            if (camCtl.DeviceValid)
            {
                camCtl.OverlayBitmapPosition = pathPosition;
                camCtl.LiveCaptureContinuous = true;

                camCtl.LiveDisplayDefault = false;
                camCtl.LiveDisplayWidth = camCtl.ImageWidth;
                camCtl.LiveDisplayHeight = camCtl.ImageHeight;
                ChangeScale();
                camCtl.LiveStart();
                EnableButtons();
            }
            else
                DisableButtons();
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            MoveHistoForm();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openCamera_Click(object sender, EventArgs e)
        {
            SelectCamera();
        }

        private void saveImage_Click(object sender, EventArgs e)
        {
            DoCapture();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (camCtl.DeviceValid)
            {
                camCtl.LiveStart();
                EnableButtons();
            }
            else
                SelectCamera();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (camCtl.LiveVideoRunning)
                camCtl.LiveStop();
            DisableButtons();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (camCtl.DeviceValid)
                camCtl.ShowPropertyDialog();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            DoCapture();
        }

        private void btnFocus_CheckedChanged(object sender, EventArgs e)
        {
            focusList.Enabled = !btnFocus.Checked;
            if (btnFocus.Checked)
                threshold = (focusList.SelectedIndex + 1) * 32;
        }

        private void btnHisto_CheckedChanged(object sender, EventArgs e)
        {
            if (btnHisto.Checked)
            {
                histoForm.Show();
                MoveHistoForm();
            }
            else
            {
                histoForm.Hide();
            }
        }

        private void camCtl_SizeChanged(object sender, EventArgs e)
        {
            ChangeScale();
        }

        private void camCtl_DeviceLost(object sender, ICImagingControl.DeviceLostEventArgs e)
        {
            DisableButtons();
        }

        private void DrawCoordinatesystem(OverlayBitmap ob, Color clr, bool hasText = true)
        {
            int Col = camCtl.ImageWidth / 2;
            int Row = camCtl.ImageHeight / 2;

            var g = ob.GetGraphics();
            g.SmoothingMode = SmoothingMode.None;
            g.PixelOffsetMode = PixelOffsetMode.None;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;

            Pen pen = new Pen(clr, 3);
            Font font = new Font("Arial", 8);
            Brush brush = new SolidBrush(clr);
            void __draw_text(int x, int y, string str)
            {
                g.DrawString(str, font, brush, x, y);
            }

            g.DrawLine(pen, Col, 0, Col, camCtl.ImageHeight);
            g.DrawLine(pen, 0, Row, camCtl.ImageWidth, Row);

            if (hasText)
            {
                for (int i = 0; i < Row; i += 20)
                {
                    g.DrawLine(pen, Col - 5, Row - i, Col + 5, Row - i);
                    g.DrawLine(pen, Col - 5, Row + i, Col + 5, Row + i);
                    if (i > 0)
                    {
                        __draw_text(Col + 10, Row - i - 7, string.Format("{0}", i / 10));
                        __draw_text(Col + 10, Row + i - 7, string.Format("{0}", -i / 10));

                    }
                }

                for (int i = 0; i < Col; i += 20)
                {
                    g.DrawLine(pen, Col - i, Row - 5, Col - i, Row + 5);
                    g.DrawLine(pen, Col + i, Row - 5, Col + i, Row + 5);
                    if (i > 0)
                    {
                        __draw_text(Col + i - 5, Row - 17, string.Format("{0}", i / 10));
                        __draw_text(Col - i - 10, Row - 17, string.Format("{0}", -i / 10));
                    }
                }
            }

            ob.ReleaseGraphics(g);
        }

        private void camCtl_LivePrepared(object sender, EventArgs e)
        {
            if (camCtl.DeviceValid)
            {
                var ob = camCtl.OverlayBitmapAtPath[pathPosition];
                ob.Enable = true;
                ob.DropOutColor = Color.Black;
                ob.FontTransparent = true;
                ob.Font = new Font("Arial", 16);
            }
        }

        private void camCtl_OverlayUpdate(object sender, ICImagingControl.OverlayUpdateEventArgs e)
        {
            if (camCtl.DeviceValid)
            {
                var ob = e.overlay;

                ob.Fill(ob.DropOutColor);
                
                if (btnFocus.Checked)
                {
                    var buffer = camCtl.ImageActiveBuffer;
                    Bitmap bmp = new Bitmap(buffer.Bitmap);
                    bmp = Grayscale.CommonAlgorithms.RMY.Apply(bmp);

                    FiltersSequence filters = new FiltersSequence
                    {
                        new DifferenceEdgeDetector(),
                        new Threshold(threshold),
                        new Dilatation3x3()
                    };
                    bmp = filters.Apply(bmp);

                    ColorRemapping remapping = new ColorRemapping
                    {
                        RedMap = new byte[256],
                        GreenMap = new byte[256],
                        BlueMap = new byte[256]
                    };
                    remapping.RedMap[255] = 255;

                    Bitmap overlay = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format24bppRgb);
                    using (Graphics gr = Graphics.FromImage(overlay))
                    {
                        gr.DrawImage(bmp, 0, 0);
                        gr.Save();
                        gr.Dispose();
                    }
                    overlay = remapping.Apply(overlay);

                    var g = ob.GetGraphics();
                    g.DrawImage(overlay, 0, 0);
                    ob.ReleaseGraphics(g);
                }

                DrawCoordinatesystem(ob, Color.Aqua, false);
            }
        }

        private void camCtl_ImageAvailable(object sender, ICImagingControl.ImageAvailableEventArgs e)
        {
            var buffer = e.ImageBuffer;
            Bitmap bmp = new Bitmap(buffer.Bitmap);
            bmp = Grayscale.CommonAlgorithms.RMY.Apply(bmp);
            histoForm.FromImage(bmp);
        }

        private void btnDatum_Click(object sender, EventArgs e)
        {
            try
            {
                Laser.Datum();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "XL80 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                DeviceInfo info;
                if (boxSerial.Text.Length == 0)
                    info = new DeviceInfo();
                else
                    info = new DeviceInfo { SerialNumber = boxSerial.Text };
                if (!Laser.Connect(ref info))
                {
                    MessageBox.Show(this, "Failed to connect to a XL80", "XL80 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    boxSerial.Text = info.SerialNumber;
                    boxInfo.Text += (" | Connected to: " + boxSerial.Text);
                    btnConnect.Text = "Disconnect";
                    btnDatum.Enabled = true;
                    boxSerial.ReadOnly = true;
                }
            }
            else
            {
                if (Laser.GetConnectionStatus() == ConnectionStatus.Ok)
                    Laser.Disconnect();
                btnConnect.Text = "Connect";
                btnDatum.Enabled = false;
                boxSerial.ReadOnly = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            boxPort.Items.Clear();
            boxPort.Items.AddRange(ports);
            if (boxPort.SelectedIndex < 0)
                boxPort.SelectedIndex = 0;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (btnOpen.Text == "Connect")
            {
                serial.PortName = boxPort.SelectedItem.ToString();
                try
                {
                    serial.Open();
                }
                catch
                {
                    MessageBox.Show(this, "Serial port error !", "Serial Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnOpen.Text = "Disconnect";
                boxPort.Enabled = false;
                btnRefresh.Enabled = false;
                btnJog.Enabled = true;
            }
            else
            {
                if (serial.IsOpen)
                    serial.Close();
                btnOpen.Text = "Connect";
                boxPort.Enabled = true;
                btnRefresh.Enabled = true;
                btnJog.Enabled = false;
            }
        }

        private double GetStep()
        {
            if (!double.TryParse(boxStep.Text, out double step))
                step = 1;
            return step;
        }

        private int GetCount()
        {
            if (!int.TryParse(boxTotalCount.Text, out int count))
                count = 0;
            return count;
        }

        private void boxTotalLen_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(boxTotalLen.Text, out double len))
                boxTotalCount.Text = ((int)(len / GetStep())).ToString();
        }

        private void boxTotalCount_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(boxTotalCount.Text, out int count))
                boxTotalLen.Text = (count * GetStep()).ToString();
        }

        private object _lock = new object();
        private bool receiveFlag = false;
        private bool RecFlag
        {
            get
            {
                try
                {
                    Monitor.Enter(_lock);
                    return receiveFlag;
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
            set
            {
                Monitor.Enter(_lock);
                receiveFlag = value;
                Monitor.Exit(_lock);
            }
        }

        private long GetMillis()
        {
            return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds);
        }

        private bool SendToRail(byte addr, char func, byte param1, uint param4)
        {
            if (serial.IsOpen)
            {
                byte[] bytes = new byte[]
                {
                    0x00, 0x00,
                    (byte)'@',
                    addr,
                    (byte)func,
                    param1,
                    (byte)((param4 >> 0 ) & 0xFF),
                    (byte)((param4 >> 8 ) & 0xFF),
                    (byte)((param4 >> 16) & 0xFF),
                    (byte)((param4 >> 24) & 0xFF)
                };
                receiveFlag = false;
                try
                {
                    serial.Write(bytes, 0, bytes.Length);
                }
                catch
                {
                    if (serial.IsOpen)
                        serial.Close();
                    btnOpen.Text = "Connect";
                    boxPort.Enabled = true;
                    btnRefresh.Enabled = true;
                    btnJog.Enabled = false;
                    return false;
                }

                long start = GetMillis();
                while (true)
                {
                    if (RecFlag) break;
                    Application.DoEvents();
                    long now = GetMillis();
                    if (now - start > 3000)
                    {
                        MessageBox.Show(this, "Serial write timeout !", "Serial Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                return true;
            }
            return false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!camCtl.DeviceValid)
            {
                MessageBox.Show(this, "Please connect camera !", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Laser.GetConnectionStatus() != ConnectionStatus.Ok)
            {
                MessageBox.Show(this, "Please connect interferometer !", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!serial.IsOpen)
            {
                MessageBox.Show(this, "Please connect rail !", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Directory.Exists(boxPath.Text))
            {
                MessageBox.Show(this, "Please select image folder !", "Image Folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            boxAddr.ReadOnly = true; boxSpeed.ReadOnly = true; boxStep.ReadOnly = true; barDir.Enabled = false;
            boxTotalLen.ReadOnly = true; boxTotalCount.ReadOnly = true; boxPath.ReadOnly = true; checkExtra.Enabled = false;

            int count = GetCount();
            string path = boxPath.Text + "\\";

            proBar.Value = 0;
            proBar.Maximum = count;

            byte railAddr = 1;
            if (int.TryParse(boxAddr.Text, out int addr))
                railAddr = (byte)addr;
            byte railSpeed = 16;
            if (int.TryParse(boxSpeed.Text, out int speed))
                railSpeed = (byte)speed;
            double railStep = 1;
            if (double.TryParse(boxStep.Text, out double step))
                railStep = step;
            byte railDir = (byte)barDir.Value;

            if (!SendToRail(railAddr, 'W', 0x03, 0x00001401))
            {
                MessageBox.Show(this, "Serial write error !", "Serial Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto END;
            }

            List<string> measures = new List<string>();
            for (int i = 0; i < count; i++)
            {
                SendToRail(railAddr, 'D', 0x00, railDir);
                SendToRail(railAddr, 'S', 0x00, railSpeed);
                SendToRail(railAddr, 'P', 0x00, (uint)(railStep * 1000));

                if (!SendToRail(railAddr, 'G', 0x00, 0x00))
                {
                    MessageBox.Show(this, "Rail move error !", "Rail Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto END;
                }

                double measure = length;
                string str = measure.ToString("F4");
                measures.Add(str);
                var buffer = camCtl.ImageActiveBuffer;
                string name = checkExtra.Checked ? (i + 1).ToString("D4") : str;
                buffer.SaveAsBitmap(path + name + ".bmp", ICImagingControlColorformats.ICY8);
            }
            
            if (checkExtra.Checked)
            {
                string data = "";
                foreach (string s in measures)
                    data += (s + "\r\n");
                File.WriteAllText(path + "data.txt", data);
            }

            END:
            boxAddr.ReadOnly = false; boxSpeed.ReadOnly = false; boxStep.ReadOnly = false; barDir.Enabled = true;
            boxTotalLen.ReadOnly = false; boxTotalCount.ReadOnly = false; boxPath.ReadOnly = false; checkExtra.Enabled = true;
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            saveLog.ShowDialog();
            boxPath.Text = saveLog.SelectedPath;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serial.IsOpen)
                serial.Close();
            if (Laser.GetConnectionStatus() == ConnectionStatus.Ok)
                Laser.Disconnect();
        }

        private void boxStep_TextChanged(object sender, EventArgs e)
        {
            boxTotalLen.Clear();
            boxTotalCount.Clear();
        }

        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //byte old = (byte)serial.ReadByte();
            //while (serial.BytesToRead > 0)
            //{
            //    byte now = (byte)serial.ReadByte();
            //    if ((old & 0xF0) == 0xA0 && (now & 0x0F) == 0x00)
            //    {
            //        RecFlag = true;
            //        serial.ReadExisting();
            //        break;
            //    }
            //    old = now;
            //}
            RecFlag = true;
        }

        private void btnJog_Click(object sender, EventArgs e)
        {
            if (!serial.IsOpen)
            {
                MessageBox.Show(this, "Please connect rail !", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte railAddr = 1;
            if (int.TryParse(boxAddr.Text, out int addr))
                railAddr = (byte)addr;
            byte railSpeed = 16;
            if (int.TryParse(boxSpeed.Text, out int speed))
                railSpeed = (byte)speed;
            double railStep = 1;
            if (double.TryParse(boxStep.Text, out double step))
                railStep = step;
            byte railDir = (byte)barDir.Value;

            if (!SendToRail(railAddr, 'W', 0x03, 0x00001401))
            {
                MessageBox.Show(this, "Serial write error !", "Serial Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SendToRail(railAddr, 'D', 0x00, railDir);
            SendToRail(railAddr, 'S', 0x00, railSpeed);
            SendToRail(railAddr, 'P', 0x00, (uint)(railStep * 1000));

            if (!SendToRail(railAddr, 'G', 0x00, 0x00))
            {
                MessageBox.Show(this, "Rail move error !", "Rail Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
