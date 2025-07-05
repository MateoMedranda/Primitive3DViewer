using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Interactive3DPrimitives
{
    public partial class Form1 : Form
    {
        private Cube cubo = new Cube();
        private Bitmap buffer;
        private Graphics g;


        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            
            buffer = new Bitmap(picCanvas.Width, picCanvas.Height);
            g = Graphics.FromImage(buffer);
            picCanvas.Image = buffer;

            Rectangle rect = new Rectangle(0, 0, buffer.Width, buffer.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Gray, Color.White, LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, rect);
            }
        }

        private void btnCube_Click(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, buffer.Width, buffer.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Gray, Color.White, LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, rect);
            }

            Pen pen = new Pen(Color.Red);
            cubo.ReadData(pen, picCanvas.Width, picCanvas.Height, 400, g);
            cubo.drawCube();
            picCanvas.Image = buffer;
            picCanvas.Invalidate();
        }



    }
}
