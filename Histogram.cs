using System.Drawing;
using System.Windows.Forms;

using AForge.Imaging;

namespace CamCtl
{
    public partial class Histogram : Form
    {
        public Histogram()
        {
            InitializeComponent();
        }

        public void FromImage(Bitmap bitmap)
        {
            ImageStatistics statistics = new ImageStatistics(bitmap);
            histoGramBox.Values = statistics.Gray.Values;
        }
    }
}
