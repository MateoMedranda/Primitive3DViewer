using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Interactive3DPrimitives
{
    public class Vector3
    {
        public float X, Y, Z;

        public Vector3(float x, float y, float z)
        {
            X = x; Y = y; Z = z;
        }
        public float getX()
        {
            return X;
        }
        public float getY()
        {
            return Y;
        }
        public float getZ()
        {
            return Z;
        }

        public void setX(float newX)
        {
            X = newX;
        }
        public void setY(float newY)
        {
            Y = newY;
        }
        public void setZ(float newZ)
        {
            Z = newZ;
        }
    }
    class Cono
    {
        public float altura = 50, radio = 40;
        public int segmentos = 40;
        public float centroX, centroY;
        List<Vector3> puntos;
        SolidBrush color = new SolidBrush(System.Drawing.Color.FromArgb(100,255,0,0));
        SolidBrush baseP = new SolidBrush(System.Drawing.Color.FromArgb(100, 0, 0, 255));
        public Cono()
        {

        }
        public void setColor(System.Drawing.Color colorSelected)
        {
            color?.Dispose();
            baseP?.Dispose();

            color = new SolidBrush(colorSelected);
            System.Drawing.Color inverso = (System.Drawing.Color.FromArgb(
                colorSelected.A,                   
                255 - colorSelected.R,
                100 - colorSelected.G,
                255 - colorSelected.B
            ));
            baseP = new SolidBrush(inverso);
        }
        public void setValues(float alt, float rad, int segm)
        {
            altura = alt;
            radio = rad;
            segmentos = segm;
        }

        public void setCenter(float X, float Y)
        {
            centroX = X; centroY = Y;
        }

        public void GenerarCono()
        {
            puntos = new List<Vector3>();

            puntos.Add(new Vector3(0, 0, 0));
            for (int i = 0; i <= segmentos; i++)
            {
                float angulo = 2 * (float)Math.PI * i / segmentos;
                float x = radio * (float)Math.Cos(angulo);
                float z = radio * (float)Math.Sin(angulo);
                puntos.Add(new Vector3(x, 0, z));

            }
            puntos.Add(new Vector3(0, altura, 0));

        }

        public void MoverPuntosX( float desplazamiento)
        {
            for (int i = 0; i < puntos.Count; i++)
            {
                puntos[i].setX(puntos[i].getX() + desplazamiento);
            }
        }

        public void MoverPuntosY(float desplazamiento)
        {
            for (int i = 0; i < puntos.Count; i++)
            {
                puntos[i].setY(puntos[i].getY() + desplazamiento);
            }
        }
        public void MoverPuntosZ( float desplazamiento)
        {
            for (int i = 0; i < puntos.Count; i++)
            {
                puntos[i].setZ(puntos[i].getZ() + desplazamiento);
            }
        }

        public void DrawPoint(PictureBox Pcanvas,Graphics g)
        {    
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            

            Vector3 centroBase = puntos[0];
            Vector3 vertice = puntos[puntos.Count - 1];
            PointF[] basePolygon = new PointF[segmentos];
                            
            for (int i = 0; i < segmentos ; i++)               
            {
                Vector3 p = puntos[i+1];
                basePolygon[i] = new PointF(p.X + centroX, -p.Y + centroY);
            }
            
            g.FillPolygon(baseP, basePolygon);
                               
            for (int i = 1; i < segmentos + 1; i++)               
            {
                Vector3 actual = puntos[i];
                Vector3 siguiente = puntos[i + 1];

                PointF[] cara = new PointF[3];
                cara[0] = new PointF(actual.X + centroX, -actual.Y + centroY);
                cara[1] = new PointF(siguiente.X + centroX, -siguiente.Y + centroY);
                cara[2] = new PointF(vertice.X + centroX, -vertice.Y + centroY);

                g.FillPolygon(color, cara);
            }


            for (int i = 1; i <= segmentos; i++)
            {
                Vector3 borde = puntos[i];

                g.FillEllipse(System.Drawing.Brushes.Black,
                    borde.X + centroX - 3, -borde.Y + centroY - 3, 3, 3);
            }

            g.FillEllipse(System.Drawing.Brushes.Black,
                vertice.X + centroX - 1, -vertice.Y + centroY - 1, 3, 3);

        }


        public void RotarX(float angulo)
        {
            float rad = angulo * (float)Math.PI / 180f;

            Vector3 centro = puntos[0];

            foreach (var p in puntos)
            {
                float x = p.X - centro.X;
                float y = p.Y - centro.Y;
                float z = p.Z - centro.Z;

                float yRot = y * (float)Math.Cos(rad) - z * (float)Math.Sin(rad);
                float zRot = y * (float)Math.Sin(rad) + z * (float)Math.Cos(rad);

                p.X = centro.X + x;
                p.Y = centro.Y + yRot;
                p.Z = centro.Z + zRot;
            }
        }
        

        public void RotarY(float angulo)
        {
            float rad = angulo * (float)Math.PI / 180f;

            Vector3 centro = puntos[0];  

            foreach (var p in puntos)
            {
                float x = p.X - centro.X;
                float y = p.Y - centro.Y;
                float z = p.Z - centro.Z;

                float xRot = x * (float)Math.Cos(rad) + z * (float)Math.Sin(rad);
                float zRot = -x * (float)Math.Sin(rad) + z * (float)Math.Cos(rad);

                p.X = centro.X + xRot;
                p.Y = centro.Y + y;
                p.Z = centro.Z + zRot;
            }
        }

        public void RotarZ(float angulo)
        {
            float rad = angulo * (float)Math.PI / 180f;

            Vector3 centro = puntos[0];

            foreach (var p in puntos)
            {
                float x = p.X - centro.X;
                float y = p.Y - centro.Y;
                float z = p.Z - centro.Z;

                float xRot = x * (float)Math.Cos(rad) - y * (float)Math.Sin(rad);
                float yRot = x * (float)Math.Sin(rad) + y * (float)Math.Cos(rad);

                p.X = centro.X + xRot;
                p.Y = centro.Y + yRot;
                p.Z = centro.Z + z;
            }
        }


        public void EscalarCono(float factorRadio, float factorAltura)
        {
            Vector3 baseCentro = puntos[0];
            Vector3 alturaCentro = puntos[puntos.Count - 1];

            float escx = alturaCentro.X - baseCentro.X;
            float escy = alturaCentro.Y - baseCentro.Y;
            float escz = alturaCentro.Z - baseCentro.Z;

            float len = (float)Math.Sqrt(escx * escx + escy * escy + escz * escz);
            escx /= len; escy /= len; escz /= len;

            for (int i = 1; i < puntos.Count; i++)
            {
                Vector3 p = puntos[i];

                float dx = p.X - baseCentro.X;
                float dy = p.Y - baseCentro.Y;
                float dz = p.Z - baseCentro.Z;

                float alturaActual = dx * escx + dy * escy + dz * escz;

                float hx = alturaActual * escx;
                float hy = alturaActual * escy;
                float hz = alturaActual * escz;

                float rx = dx - hx;
                float ry = dy - hy;
                float rz = dz - hz;

                hx *= factorAltura;
                hy *= factorAltura;
                hz *= factorAltura;

                rx *= factorRadio;
                ry *= factorRadio;
                rz *= factorRadio;

                p.X = baseCentro.X + hx + rx;
                p.Y = baseCentro.Y + hy + ry;
                p.Z = baseCentro.Z + hz + rz;
            }
        }

    }
}
