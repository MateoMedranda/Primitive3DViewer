using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Interactive3DPrimitives
{

    internal class Sphere
    {
        private int radius;
        private int d;
        private int canvasWidth;
        private int canvasHeight;
        private float angleX = 0f;
        private float angleY = 0f;
        private Graphics mgraph;
        private Color colorCube;
        private List<float[]> sphereVertex = new List<float[]>();

        public Sphere(){
        
        }

        public void genetateSphere()
        {
            radius = 100;
            sphereVertex.Clear();
            for(float theta=0; theta<=2*Math.PI; theta = theta + 0.2f)
            {
                for (float phi = 0; phi <= 2*Math.PI; phi = phi + 0.2f)
                {
                    float x = radius * (float)Math.Sin(phi) * (float)Math.Cos(theta);
                    float y = radius * (float)Math.Sin(phi) * (float)Math.Sin(theta);
                    float z = radius * (float)Math.Cos(phi);

                    sphereVertex.Add(new float[] { x, y, z });
                }
            }
        }

        private Point proyectPoint(float x, float y, float z)
        {
            float xp = ((x * d) / (d + z)) + canvasWidth / 2;
            float yp = ((y * d) / (d + z)) + canvasHeight / 2;
            return new Point((int)xp, (int)yp);
        }

        public void changeAngle(float ax, float ay)
        {
            angleX = ax;
            angleY = ay;
        }

        public void ReadData(Color color, int camWidth, int camHeight, int nd, Graphics g)
        {
            canvasWidth = camWidth;
            canvasHeight = camHeight;
            mgraph = g;
            colorCube = color;
            d = nd;
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

        public void drawSphere()
        {
            Pen mpen = new Pen(Color.Black, 2);
            Point point = new Point();
            for (int i = 0; i < sphereVertex.Count; i++)
            {
                float x = sphereVertex[i][0];
                float y = sphereVertex[i][1];
                float z = sphereVertex[i][2];

                Rotate(ref x, ref y, ref z);
                point = proyectPoint(x, y, z);

                mgraph.DrawRectangle(mpen, point.X, point.Y, 2, 2);
            }
        }

    }
}
