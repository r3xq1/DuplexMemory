namespace DuplexMemory
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    public partial class ScreenViewer : Form
    {
        public ScreenViewer() => InitializeComponent();

        private void ScreenViewer_Load(object sender, EventArgs e)
        {
            // Можно сразу так показать:
            //ScreenBox.Image = new Bitmap(new MemoryStream(ScreenShot.GetData()));

            using var ss = new MemoryStream(ScreenShot.GetData().ToArray());
            ScreenBox.Image = Image.FromStream(ss);

            // Можно из массива byte[] в изображение сделать так:
            // var converter = new ImageConverter();
            // ScreenBox.Image = (Image)converter.ConvertFrom(ScreenShot.GetData().ToArray());

        }
    }
}