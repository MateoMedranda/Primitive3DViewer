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
        private bool drawCube = false;
        private bool holding = false;
        private bool rotateOn = false;
        private Point previusMouse;
        float angleX = 0f;
        float angleY = 0f;
        Color color;


        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            picCanvas.Paint += picCanvas_Paint;
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(picCanvas.BackColor);

            Rectangle rect = picCanvas.ClientRectangle;
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Gray, Color.White, LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, rect);
            }

            if (drawCube)
            {
                drawCubeAtScreen(g);
            }

        }

        private void drawCubeAtScreen(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);
            cubo.ReadData(color, picCanvas.Width, picCanvas.Height, 400, g);
            cubo.changeAngle(-angleX, -angleY);
            cubo.drawCube();
        }


        private void btnCube_Click(object sender, EventArgs e)
        {
            if (!drawCube)
            {
                drawCube = true;
                lbFigure.Text = "Cubo";
            }
            picCanvas.Invalidate();
        }

        private void picCanvas_SizeChanged(object sender, EventArgs e)
        {
            picCanvas.Invalidate();
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                holding = true;
                previusMouse = e.Location;
            }
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (holding)
            {
                if (rotateOn)
                {
                    int dx = e.X - previusMouse.X;
                    int dy = -(e.Y - previusMouse.Y);

                    angleY += dx * 0.01f;
                    angleX += dy * 0.01f;

                    previusMouse = e.Location;
                    picCanvas.Invalidate();
                }
            }
        }

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                holding = false;
            }
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (!rotateOn)
            {
                btnRotate.BackColor = Color.GreenYellow;
                rotateOn = true;
                lbMode.Text = "Rotación";
            }
            else
            {
                btnRotate.BackColor = Color.White;
                rotateOn = false;
                lbMode.Text = "Estático";
            }

        }

        private void btnFigureColor_Click(object sender, EventArgs e)
        {
            if(figureColor.ShowDialog() == DialogResult.OK)
            {
                picColor.BackColor = figureColor.Color;
                color = Color.FromArgb(128, figureColor.Color);
                picCanvas.Invalidate();
            }
        }
    }
}
