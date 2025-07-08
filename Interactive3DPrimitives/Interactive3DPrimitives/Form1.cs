using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Interactive3DPrimitives
{
    public partial class Form1 : Form
    {
        private Cube cubo = new Cube();
        private Sphere esfera = new Sphere();
        private Bitmap buffer;
        private Graphics g;
        private bool drawCube = false;
        private bool drawSphere = false;
        private bool drawCylinder = false;
        private bool holding = false;
        private bool rotateOn = false;
        private bool fusion = false;
        int cont = 0, lastdx,lastdy;
        private Point previusMouse;
        float angleX = 0f;
        float angleY = 0f;
        Color color = Color.FromArgb(50, 255, 0, 0);
        Cono cone = new Cono();
        Cilindro cilinder = new Cilindro();
        bool conecreated = false;
        float mousScrollValue = 1;
        float alt, rad, valInicial = 1;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            picCanvas.Paint += picCanvas_Paint;
            this.MouseWheel += Form1_MouseWheel;
            this.Load += Form1_Load;

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

            if (drawSphere)
            {
                drawSphereAtScreen(g);
            }

            if (conecreated)
            {
                cone.setColor(color);
                cone.DrawPoint(picCanvas, g);
            }
            if (drawCylinder)
            {
                cilinder.DrawPoint(picCanvas, g);
            }
        }

        private void drawCubeAtScreen(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);
            cubo.ReadData(color, picCanvas.Width, picCanvas.Height, 400, g);
            cubo.changeAngle(-angleX, -angleY);
            cubo.drawCube();
        }

        private void drawSphereAtScreen(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);
            esfera.genetateSphere();
            esfera.ReadData(color, picCanvas.Width, picCanvas.Height, 400, g);
            esfera.changeAngle(-angleX, -angleY);
            esfera.drawSphere();
        }


        private void btnCube_Click(object sender, EventArgs e)
        {
            lbFigure.Text = "";
            if (fusion)
            {
                if (cont <= 1 && !drawCube)
                {
                    cont++;
                    drawCube = true;
                    lbFigure.Text += "Cubo ";
                }
                if (cont == 2)
                {
                    fusion = false;
                    cont = 0;
                }
            }
            else if (!drawCube)
            {
                drawCube = true;
                conecreated = false;
                drawSphere = false;
                drawCylinder = false;
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

        private async void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (holding)
            {
                int dx = e.X - previusMouse.X;
                int dy = -(e.Y - previusMouse.Y);
                lastdx = dx;
                lastdy = dy;
                picCanvas.Invalidate();
                if (rotateOn && !drawCube)
                {
                    angleY += dx * 0.01f;
                    angleX += dy * 0.01f;
                    previusMouse = e.Location;

                }
                if (rotateOn && conecreated)
                {

                    cone.RotarY(dx);
                    cone.RotarX(dy);

                    previusMouse = e.Location;
                    
                }
                if (rotateOn && drawSphere)
                {
                    angleY += dx * 0.01f;
                    angleX += dy * 0.01f;
                    previusMouse = e.Location;
                }
                if (rotateOn && drawCylinder)
                {
                    cilinder.RotarY(dx);
                    cilinder.RotarX(dy);
                    previusMouse = e.Location;
                }
                picCanvas.Invalidate();
            }


        }

        public async void continuarRotacion(int dx, int dy)
        {
            for (int i = 0; i < 50; i++)
            {
                if (conecreated)
                {
                    cone.RotarY(dx);
                    cone.RotarX(dy);
                }
                picCanvas.Invalidate();

                dx = (int)(dx * 1.01);
                dy = (int)(dy * 1.01);

                await Task.Delay(10);
            }
            for (int i = 0; i < 50; i++)
            {
                if (conecreated)
                {
                    cone.RotarY(dx);
                    cone.RotarX(dy);
                }
                picCanvas.Invalidate();

                dx = (int)(dx * 0.95);
                dy = (int)(dy * 0.95);

                await Task.Delay(10);
            }
        }
        private async void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if(holding && conecreated)
                    continuarRotacion(lastdx, lastdy);
                holding = false;
                
            }

        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (!rotateOn)
            {
                btnRotate.BackColor = Color.GreenYellow;
                rotateOn = true;
                lbMode.Text = "Rotaci�n";
            }
            else
            {
                btnRotate.BackColor = Color.White;
                rotateOn = false;
                lbMode.Text = "Est�tico";
            }

        }

        private void btnFigureColor_Click(object sender, EventArgs e)
        {
            if (figureColor.ShowDialog() == DialogResult.OK)
            {
                picColor.BackColor = figureColor.Color;
                color = Color.FromArgb(128, figureColor.Color);
                picCanvas.Invalidate();
            }
            cilinder.getColor(color);
        }

        private void btnCone_Click(object sender, EventArgs e)
        {
            lbFigure.Text = "";
            if (fusion)
            {
                if (cont <= 1 && !conecreated)
                {
                    cont++;
                    conecreated = true;
                    lbFigure.Text += "Cono ";
                }
                if (cont == 2)
                {
                    fusion = false;
                    cont = 0;
                }
            }
            else if(!conecreated)
            {
                conecreated = true;
                drawCube = false;
                drawSphere = false;
                drawCylinder = false;
                lbFigure.Text = "Cono";
            }
            picCanvas.Invalidate();
            cone.setCenter(picCanvas.Width / 2, picCanvas.Height / 2);
            cone.GenerarCono();
            alt = cone.altura;
            rad = cone.radio;
        }
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {

            if (!conecreated && !drawCube)
            {
                MessageBox.Show("No puedes manipular la figura sin generarla");
                return;
            }

            if (mousScrollValue == 1 && e.Delta < 0)
            {
                MessageBox.Show("No puedes achicar mas la figura");
                return;
            }
            if (e.Delta > 0)
                mousScrollValue++;
            else
                mousScrollValue--;

            if (conecreated)
            {
                float factor = 5 / 10 + mousScrollValue / valInicial;
                cone.EscalarCono(factor, factor);
                valInicial = mousScrollValue;
            }
            picCanvas.Invalidate();

        }

        private void btnSphere_Click(object sender, EventArgs e)
        {
            lbFigure.Text = "";
            if (fusion)
            {
                if (cont <= 1 && !drawSphere)
                {
                    cont++;
                    drawSphere = true;
                    lbFigure.Text += "Esfera ";
                }
                if (cont == 2)
                {
                    fusion = false;
                    cont = 0;
                }
            }
            else if(!drawSphere)
            {
                drawSphere = true;
                drawCube = false;
                conecreated = false;
                drawCylinder = false;
                lbFigure.Text = "Esfera";
            }
            picCanvas.Invalidate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!conecreated && !drawCube)
            {
                MessageBox.Show("No puedes manipular la figura sin generarla");
                return true;
            }

            int mov = 0;
            if (keyData == Keys.Up) mov = 1;
            else if (keyData == Keys.Down) mov = 2;
            else if (keyData == Keys.Left) mov = 3;
            else if (keyData == Keys.Right) mov = 4;

            if (conecreated)
            {
                if (cone.ComprobarCentro(picCanvas))
                {
                    MessageBox.Show("No puedes mover la figura fuera de la pantalla");
                    switch (mov)
                    {
                        case 1:
                            cone.MoverPuntosY(-5);
                            break;
                        case 2:
                            cone.MoverPuntosY(5);
                            break;
                        case 3:
                            cone.MoverPuntosX(5);
                            break;
                        case 4:
                            cone.MoverPuntosX(-5);
                            break;
                    }
                    return true;
                }
                switch (mov)
                {
                    case 1:
                        cone.MoverPuntosY(5);
                        break;
                    case 2:
                        cone.MoverPuntosY(-5);
                        break;
                    case 3:
                        cone.MoverPuntosX(-5);
                        break;
                    case 4:
                        cone.MoverPuntosX(5);
                        break;
                }
                picCanvas.Invalidate();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Focus();
        }

        private void btnCilinder_Click(object sender, EventArgs e)
        {
            lbFigure.Text = "";
            if (fusion)
            {
                if(cont <= 1 && !drawCylinder)
                {
                    cont++;
                    drawCylinder = true;
                    lbFigure.Text += "Cilindro ";
                }
                
                if(cont==2)
                {
                    fusion = false;
                    cont = 0;
                }
            } else if (!drawCylinder)
            {
                drawCylinder = true;
                drawSphere = false;
                drawCube = false;
                conecreated = false;
                lbFigure.Text = "Cilindro";
            }
            cilinder.setCenter(picCanvas.Width / 2, picCanvas.Height / 2);
            cilinder.generateCylinder();
            picCanvas.Invalidate();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            fusion = !fusion;
            drawCylinder = false;
            drawSphere = false;
            drawCube = false;
            conecreated = false;
        }
    }
}
