using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive3DPrimitives
{
    class Cube
    {
        private float[,] vertex;
        private int d;
        private int canvasWidth;
        private int canvasHeight;
        private float angleX = 0f;
        private float angleY = 0f;
        private Graphics mgraph;
        private Color colorCube;


        public Cube() {
            
            vertex = new float[,]
            {
                // Cara frontal (Z = -100)
                { -100, -100, -100 },  
                {  100, -100, -100 },  
                {  100,  100, -100 },  
                { -100,  100, -100 },  
                // Cara trasera (Z = +100)
                { -100, -100,  100 },  
                {  100, -100,  100 },  
                {  100,  100,  100 },  
                { -100,  100,  100 }  
            };
        }

        public void ReadData(Color color, int camWidth, int camHeight,int nd, Graphics g)
        {
            canvasWidth = camWidth;
            canvasHeight = camHeight;
            mgraph = g;
            colorCube = color;
            d = nd;
        }

        private Point proyectPoint(float x, float y, float z)
        {
            float xp = ((x * d) / (d + z)) + canvasWidth/2;
            float yp = ((y * d) / (d + z)) + canvasHeight/2;
            return new Point((int)xp,(int) yp);
        }

        public void changeAngle(float ax, float ay)
        {
            angleX = ax;
            angleY = ay;
        }

        private void Rotate(ref float x, ref float y, ref float z)
        {
            // Rotación en X
            float cosX = (float)Math.Cos(angleX);
            float sinX = (float)Math.Sin(angleX);
            float y1 = y * cosX - z * sinX;
            float z1 = y * sinX + z * cosX;
            y = y1;
            z = z1;

            // Rotación en Y
            float cosY = (float)Math.Cos(angleY);
            float sinY = (float)Math.Sin(angleY);
            float x1 = x * cosY + z * sinY;
            z1 = -x * sinY + z * cosY;
            x = x1;
            z = z1;
        }

        public void drawCube()
        {

            Point[] pointds2D = new Point[8];
            for (int i = 0; i < 8; i++)
            {
                float x = vertex[i, 0];
                float y = vertex[i, 1];
                float z = vertex[i, 2];

                Rotate(ref x, ref y, ref z);
                pointds2D[i] = proyectPoint(x, y, z);
            }

            Pen mpen = new Pen(Color.Black,2);
            mgraph.DrawPolygon(mpen, new[] { pointds2D[0], pointds2D[1], pointds2D[2], pointds2D[3] });
            mgraph.DrawPolygon(mpen, new[] { pointds2D[4], pointds2D[5], pointds2D[6], pointds2D[7] });
            mgraph.DrawPolygon(mpen, new[] { pointds2D[0], pointds2D[4], pointds2D[5], pointds2D[1] });
            mgraph.DrawPolygon(mpen, new[] { pointds2D[2], pointds2D[6], pointds2D[7], pointds2D[3] });

            Brush mbrush = new SolidBrush(colorCube);

            mgraph.FillPolygon(mbrush, new[] { pointds2D[0], pointds2D[1], pointds2D[2], pointds2D[3] });
            mgraph.FillPolygon(mbrush, new[] { pointds2D[4], pointds2D[5], pointds2D[6], pointds2D[7] });
            mgraph.FillPolygon(mbrush, new[] { pointds2D[0], pointds2D[4], pointds2D[5], pointds2D[1] });
            mgraph.FillPolygon(mbrush, new[] { pointds2D[2], pointds2D[6], pointds2D[7], pointds2D[3] });

            /*
            for (int i = 0; i < 4; i++)
            {
                mgraph.DrawLine(mpen, pointds2D[i], pointds2D[i + 4]);
            }
            */
        }


    }
}
