using System;
using System.Drawing;
using System.Windows.Forms;

namespace RayTracer
{
    public partial class RayTracerForm : Form
    {
        Bitmap bitmap;
        PictureBox pictureBox;
        const int imageWidth = 600;
        const int imageHeight = 600;

        public RayTracerForm()
        {
            bitmap = new Bitmap(imageWidth, imageHeight);

            pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = bitmap;

            ClientSize = new Size(imageWidth, imageHeight + 24);
            Controls.Add(pictureBox);
            Text = "Ray Tracer";
            Load += RayTracerForm_Load;

            Show();
        }

        private void RayTracerForm_Load(object sender, EventArgs e)
        {
            Show();
            Renderer rayTracer = new Renderer(imageWidth, imageHeight);
            Colour[] pixels = rayTracer.Render(StandardScenes.DefaultScene);
            Bitmap image = new Bitmap(imageWidth, imageHeight);
            for (int x = 0; x < imageWidth; x++)
            {
                for (int y = 0; y < imageHeight; y++)
                {
                    Colour c = pixels[y * imageWidth + x];
                    image.SetPixel(x,y,ToDrawingColor(c));
                }
            }
            pictureBox.Image = image;
            pictureBox.Invalidate();
        }

        private Color ToDrawingColor(Colour c)
        {
            return Color.FromArgb(c.RedByte(), c.GreenByte(), c.BlueByte());
        }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new RayTracerForm());
        }
    }
}
