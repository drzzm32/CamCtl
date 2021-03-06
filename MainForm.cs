﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

using TIS.Imaging;

using AForge.Imaging;
using AForge.Imaging.Filters;

namespace CamCtl
{
    public partial class MainForm : Form
    {
        private Histogram histoForm;

        public MainForm()
        {
            InitializeComponent();

            histoForm = new Histogram();

            focusList.SelectedIndex = 3;
        }

        private readonly PathPositions pathPosition = PathPositions.Display;
        private int threshold = 128;

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

        private void MainForm_Load(object sender, EventArgs e)
        {
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
    }
}
