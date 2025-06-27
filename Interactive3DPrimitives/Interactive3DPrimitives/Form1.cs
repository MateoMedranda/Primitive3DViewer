using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Interactive3DPrimitives
{
    public partial class Form1 : Form
    {
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = picCanvas.ClientRectangle;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.Gray,         
                Color.White,   
                LinearGradientMode.Vertical)) 
            {
                g.FillRectangle(brush, rect);
            }
        }

        public Form1()
        {
            InitializeComponent();
            picCanvas.Paint += pictureBox1_Paint;
            picCanvas.Resize += (s, e) => picCanvas.Invalidate();

        }
    }
}
