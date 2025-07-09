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
        private int traslationX = 0;
        private int traslationY = 0;
        private Graphics mgraph;
        private Color colorSphere;
        private List<float[]> sphereVertex = new List<float[]>();
        private const float distancePoints = 0.12f;


        public Sphere()
        {

        }

        public void genetateSphere(int n)
        {
            radius = n;
            sphereVertex.Clear();
            for (float theta = 0; theta <= 2 * Math.PI; theta = theta + distancePoints)
            {
                for (float phi = 0; phi <= Math.PI; phi = phi + distancePoints)
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
            float xp = ((x * d) / (d + z)) + canvasWidth / 2 + traslationX;
            float yp = ((y * d) / (d + z)) + canvasHeight / 2 + traslationY;
            return new Point((int)xp, (int)yp);
        }

        public void changeAngle(float ax, float ay)
        {
            angleX = ax;
            angleY = ay;
        }

        public void changeTraslation(int tx, int ty)
        {
            traslationY = ty;
            traslationX = tx;
        }

        public void ReadData(Color color, int camWidth, int camHeight, int nd, Graphics g)
        {
            canvasWidth = camWidth;
            canvasHeight = camHeight;
            mgraph = g;
            colorSphere = color;
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
            int nTheta = (int)(2 * Math.PI / distancePoints) + 1;
            int nPhi = (int)(Math.PI / distancePoints) + 1;
            List<int> index = new List<int>();

            Pen mpen = new Pen(Color.Black, 1);
            Point[] points2D = new Point[sphereVertex.Count];

            for (int i = 0; i < sphereVertex.Count; i++)
            {
                float x = sphereVertex[i][0];
                float y = sphereVertex[i][1];
                float z = sphereVertex[i][2];

                Rotate(ref x, ref y, ref z);
                if (z > 20)
                {
                    index.Add(i);
                }
                points2D[i] = proyectPoint(x, y, z);

            }
            for (int t = 0; t < nTheta - 1; t++)
            {
                for (int p = 0; p < nPhi - 1; p++)
                {
                    int index1 = t * nPhi + p;
                    int index2 = index1 + 1;
                    int index3 = index1 + nPhi + 1;
                    int index4 = index1 + nPhi;

                    if (index.Contains(index2) || index.Contains(index1) || index.Contains(index3) || index.Contains(index4))
                    {
                        continue;
                    }

                    Point[] polygon = new Point[]
                    {
                        points2D[index1],
                        points2D[index2],
                        points2D[index3],
                        points2D[index4]
                    };
                    Brush mbrush = new SolidBrush(colorSphere);
                    mgraph.FillPolygon(mbrush, polygon);
                    mgraph.DrawPolygon(mpen, polygon);
                }
            }

        }
    }
}
