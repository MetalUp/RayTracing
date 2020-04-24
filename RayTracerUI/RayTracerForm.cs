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

            ClientSize = new System.Drawing.Size(imageWidth, imageHeight + 24);
            Controls.Add(pictureBox);
            Text = "Ray Tracer";
            Load += RayTracerForm_Load;

            Show();
        }

        private void RayTracerForm_Load(object sender, EventArgs e)
        {
            this.Show();
            Renderer rayTracer = new Renderer(imageWidth, imageHeight, (int x, int y, System.Drawing.Color color) =>
            {
                bitmap.SetPixel(x, y, color);
                if (x == 0) pictureBox.Refresh();
            });
            rayTracer.Render(StandardScenes.DefaultScene);
            pictureBox.Invalidate();

        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new RayTracerForm());
        }
    }
}
