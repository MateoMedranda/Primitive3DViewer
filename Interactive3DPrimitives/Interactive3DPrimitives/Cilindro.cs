using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.Logging;

namespace Interactive3DPrimitives
{
    internal class Cilindro
    {
        private float radioBase;
        private float alturaCilindro;
        private float defaultRadius=100;
        private float defaultHeight = 400;
        private List<Vector3> baseInferior;
        private List<Vector3> baseSuperior;
        private float screenCenterX;
        private float screenCenterY;
        private Vector3 shapeCenter;
        private PointF shapeCenterRelative;
        private Color shapeColor;
        private int segmentosVerticales;

        public Cilindro()
        {
            radioBase = defaultRadius;
            alturaCilindro = defaultHeight;
            segmentosVerticales = 36;
            shapeColor = Color.FromArgb(100, 45, 120, 12);
            shapeCenter = new Vector3(0, 0, 0);
        }
        public void setCenter(int centerX, int centerY)
        {
            screenCenterX = centerX;
            screenCenterY = centerY;
        }
        public void getColor(Color newColor)
        {
            shapeColor = newColor;
        }
        public void generateCylinder()
        {
            baseInferior = new List<Vector3>();
            baseSuperior = new List<Vector3>();
            float midHeight = alturaCilindro / 2;
            baseInferior.Add(new Vector3(shapeCenter.X, -midHeight, shapeCenter.Z));
            baseSuperior.Add(new Vector3(shapeCenter.X, midHeight,shapeCenter.Z));
            for (int i = 0; i <= segmentosVerticales; i++)
            {
                float angulo = 2 * (float)Math.PI * i / segmentosVerticales;
                float x = radioBase * (float)Math.Cos(angulo);
                float z = radioBase * (float)Math.Sin(angulo);
                baseInferior.Add(new Vector3(shapeCenter.X+x,shapeCenter.Y-midHeight,shapeCenter.Z+z));
                baseSuperior.Add(new Vector3(shapeCenter.X+x, shapeCenter.Y+midHeight,shapeCenter.Z+z));
            }
        }
        public void DrawPoint(PictureBox Pcanvas, Graphics g)
        {

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen cPen = new Pen(Color.Black, 2);
            List<PointF> caraInferior = new List<PointF>();
            List<PointF> caraSuperior = new List<PointF>();
            //Dibujar base inferior
            for (int i = 1; i < segmentosVerticales + 1; i++)
            {
                Vector3 actual = baseInferior[i];
                Vector3 siguiente = baseInferior[i + 1];
                PointF actualRelativo = new PointF(actual.X + screenCenterX, -actual.Y + screenCenterY);
                PointF siguienteRelativo = new PointF(siguiente.X + screenCenterX, -siguiente.Y + screenCenterY);
                g.DrawLine(cPen, actualRelativo,siguienteRelativo);
                caraInferior.Add(actualRelativo);
                caraInferior.Add(siguienteRelativo);
            }
            //Dibujar base superior
            for (int i = 1; i < segmentosVerticales + 1; i++)
            {
                Vector3 actual = baseSuperior[i];
                Vector3 siguiente = baseSuperior[i + 1];
                PointF actualRelativo = new PointF(actual.X + screenCenterX, -actual.Y + screenCenterY);
                PointF siguienteRelativo = new PointF(siguiente.X + screenCenterX, -siguiente.Y + screenCenterY);
                g.DrawLine(cPen, actualRelativo, siguienteRelativo);
                caraSuperior.Add(actualRelativo);
                caraSuperior.Add(siguienteRelativo);
            }
            //Dibujar líneas verticales
            for (int i = 1; i < segmentosVerticales; i+=(segmentosVerticales/12))
            {
                Vector3 superior = baseSuperior[i];
                Vector3 inferior = baseInferior[i];
                g.DrawLine(cPen, new PointF(inferior.X + screenCenterX, -inferior.Y + screenCenterY),
               new PointF(superior.X + screenCenterX, -superior.Y + screenCenterY));
            }
            //Colorear los lados
            SolidBrush mBrush=new SolidBrush(shapeColor);
            for(int i = 1;i < segmentosVerticales + 1;i++)
            {
                Vector3 superior = baseSuperior[i];
                Vector3 inferior = baseInferior[i];
                Vector3 superiorNext = baseSuperior[i+1];
                Vector3 inferiorNext = baseInferior[i+1];
                PointF[] polygon = [
                    new PointF(inferior.X + screenCenterX, -inferior.Y + screenCenterY),
                    new PointF(inferiorNext.X + screenCenterX, -inferiorNext.Y + screenCenterY), 
                    new PointF(superiorNext.X + screenCenterX, -superiorNext.Y + screenCenterY),
                    new PointF(superior.X + screenCenterX, -superior.Y + screenCenterY)
                   ];
                g.FillPolygon(mBrush, polygon);
            }
            //Colorear las bases
            g.FillPolygon(mBrush, caraInferior.ToArray());
            g.FillPolygon(mBrush, caraSuperior.ToArray());
            //Colorear eje
            cPen = new Pen(Color.Black, 4);
            mBrush.Color = Color.Red;
            g.FillEllipse(mBrush, screenCenterX + shapeCenter.X - 5f, screenCenterY - shapeCenter.Y - 5f, 10, 10);
            g.FillEllipse(mBrush, screenCenterX +baseInferior[0].X - 5f,  screenCenterY-baseInferior[0].Y - 5f, 10, 10);
            g.FillEllipse(mBrush, screenCenterX + baseSuperior[0].X - 5f, screenCenterY - baseSuperior[0].Y - 5f, 10, 10);

        }
        public void RotarX(float angulo)
        {
           foreach (var low in baseInferior)
           {
                    centrarPunto(low);
                    rotarPuntoX(low, angulo);
                    retornarPuntoCentrado(low);
           }
            foreach (var top in baseSuperior)
            {
                centrarPunto(top);
                rotarPuntoX(top, angulo);
                retornarPuntoCentrado(top);
            }
        }
        public void rotarPuntoX(Vector3 punto, float angulo)
        {
            
            float rad = angulo * (float)Math.PI / 180f;
            float y = punto.getY();
            float z = punto.getZ();
            punto.setY(y * (float)Math.Cos(rad) - z * (float)Math.Sin(rad));
            punto.setZ(y * (float)Math.Sin(rad) + z * (float)Math.Cos(rad));

        }
        public void RotarY(float angulo)
        {
            foreach (var low in baseInferior)
            {
                centrarPunto(low);
                rotarPuntoY(low, angulo);
                retornarPuntoCentrado(low);
            }
            foreach (var top in baseSuperior)
            {
                centrarPunto(top);
                rotarPuntoY(top, angulo);
                retornarPuntoCentrado(top);
            }
        }
        public void rotarPuntoY(Vector3 punto, float angulo)
        {
            float rad = angulo * (float)Math.PI / 180f;
            float x = punto.getX();
            float z = punto.getZ();
            punto.setX(x * (float)Math.Cos(rad) + z * (float)Math.Sin(rad));
            punto.setZ(-x * (float)Math.Sin(rad) + z * (float)Math.Cos(rad));
        }
        public void RotarZ(float angulo)
        {
            //Girar el centr
            foreach (var low in baseInferior)
            {
                centrarPunto(low);
                rotarPuntoZ(low, angulo);
                retornarPuntoCentrado(low);
            }
            foreach (var top in baseSuperior)
            {
                centrarPunto(top);
                rotarPuntoY(top, angulo);
                centrarPunto(top);
            }
        }

        public void rotarPuntoZ(Vector3 punto, float angulo)
        {
            float rad = angulo * (float)Math.PI / 180f;
            float x = punto.getX();
            float y = punto.getY();
            punto.setY(x * (float)Math.Cos(rad) - y * (float)Math.Sin(rad));
            punto.setZ(x * (float)Math.Sin(rad) + y * (float)Math.Cos(rad));
        }

        public void centrarPunto(Vector3 punto)
        {
            //Saca las diferencias
            punto.X-= shapeCenter.X;
            punto.Y-= shapeCenter.Y;
            punto.Z -= shapeCenter.Z;
        }
        public void retornarPuntoCentrado(Vector3 punto)
        {
            punto.X += shapeCenter.X;
            punto.Y += shapeCenter.Y;
            punto.Z += shapeCenter.Z;
        }


        public void moverX(String direction)
        {
            Boolean positive=(direction=="right")? true:false;  
            foreach (Vector3 vertex in baseInferior)
            {
                vertex.X += (positive) ? 5 : -5;
            }
            foreach (Vector3 vertex in baseSuperior)
            {
                vertex.X += (positive) ? 5 : -5;
            }
            shapeCenter.X += (positive) ? 5 : -5;
        }
        public void moverY(String direction)
        {
            Boolean positive = (direction.Equals("up")) ? true : false;
            foreach (Vector3 vertex in baseInferior)
            {
                vertex.Y += (positive) ? 5 : -5;
            }
            foreach (Vector3 vertex in baseSuperior)
            {
                vertex.Y += (positive) ? 5 : -5;
            }
            shapeCenter.Y+= (positive) ? 5 : -5;
        }
        public void moverZ(String direction)
        {
            Boolean positive = (direction.Equals("up")) ? true : false;
            foreach (Vector3 vertex in baseInferior)
            {
                vertex.Z += (positive) ? 5 : -5;
                vertex.Y += (positive) ? 5 : -5;
            }
            foreach (Vector3 vertex in baseSuperior)
            {
                vertex.Z += (positive) ? 5 : -5;
                vertex.Y += (positive) ? 5 : -5;
            }
            shapeCenter.Y += (positive) ? 5 : -5;
            shapeCenter.Z += (positive) ? 5: -5;
        }
        public bool cilindroDesplazado()
        {
            if(shapeCenter.X!=0 || shapeCenter.Y!=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Vector3 obtenerDesplazamiento()
        {
            return new Vector3(
                shapeCenter.X,
                shapeCenter.Y,
                0
                );
        }

        public void escalarCilindro(float factor)
        {
            bool muyChico = (alturaCilindro <= 20 && radioBase <= 12 && factor < 1);
            bool muyAlto = (shapeCenter.Y + (alturaCilindro / 2) >= (screenCenterY*2)-20 ) && factor>1;
            bool muyAncho = (shapeCenter.X + radioBase >= (screenCenterX * 2)-20) && factor >1;
            if (!muyAlto && !muyChico && !muyAncho)
            {
                float newHeight = alturaCilindro * factor;
                float newRadius = radioBase * factor;
                float dx, dy, dz;
                float module;
                Vector3 originalScale;
                Vector3 vUnit;
                foreach (Vector3 vertex in baseInferior)
                {
                    vectorialScale(vertex, factor);
                }
                foreach (Vector3 vertex in baseSuperior)
                {
                    vectorialScale(vertex, factor);
                }
                radioBase = newRadius;
                alturaCilindro = newHeight;
            }
            
            
        }

        public void vectorialScale(Vector3 vertex,float factor)
        {
            float dx, dy, dz;
            float module;
            Vector3 vUnit;
            dx = vertex.X - shapeCenter.X;
            dy = vertex.Y - shapeCenter.Y;
            dz = vertex.Z - shapeCenter.Z;



            module = (float)Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2) + Math.Pow(dz, 2));


            vUnit = new Vector3(dx / module, dy / module, dz / module);

            vertex.X = vUnit.X * factor * module;
            vertex.Y = vUnit.Y * factor * module;
            vertex.Z = vUnit.Z * factor * module;
        }

        
    }


}


