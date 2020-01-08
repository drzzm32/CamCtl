using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using TIS.Imaging;

using AForge.Imaging.Filters;

namespace CamCtl
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private readonly PathPositions pathPosition = PathPositions.Display;
        private int threshold = 128;

        private void ResetButtons()
        {
            btnConfig.Enabled = false;
            btnCapture.Enabled = false;
            btnFocus.Enabled = false;

            focusList.SelectedIndex = 1;
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
        }

        private void SelectCamera()
        {
            if (camCtl.LiveVideoRunning)
                camCtl.LiveStop();
            camCtl.ShowDeviceSettingsDialog();
            if (camCtl.DeviceValid)
            {
                camCtl.MemoryCurrentGrabberColorformat = ICImagingControlColorformats.ICY8;
                camCtl.OverlayBitmapPosition = pathPosition;
                camCtl.LiveCaptureContinuous = true;

                camCtl.LiveDisplayDefault = false;
                camCtl.LiveDisplayWidth = camCtl.ImageWidth;
                camCtl.LiveDisplayHeight = camCtl.ImageHeight;
                ChangeScale();
                camCtl.LiveStart();
                btnConfig.Enabled = true;
                btnCapture.Enabled = true;
                btnFocus.Enabled = true;
            }
            else
                ResetButtons();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResetButtons();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                DoCapture();
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openCamera_Click(object sender, EventArgs e)
        {
            SelectCamera();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (camCtl.DeviceValid)
                camCtl.LiveStart();
            else
                SelectCamera();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (camCtl.LiveVideoRunning)
                camCtl.LiveStop();
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
                threshold = (focusList.SelectedIndex + 1) * 64;
        }

        private void camCtl_SizeChanged(object sender, EventArgs e)
        {
            ChangeScale();
        }

        private void camCtl_DeviceLost(object sender, ICImagingControl.DeviceLostEventArgs e)
        {
            ResetButtons();
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

                    var g = ob.GetGraphics();
                    g.DrawImage(bmp, 0, 0);
                    ob.ReleaseGraphics(g);
                }

                DrawCoordinatesystem(ob, Color.Aqua, false);
            }
        }  
    }
}
