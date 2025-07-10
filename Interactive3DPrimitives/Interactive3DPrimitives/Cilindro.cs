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
        private Color baseColor;

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
            SolidBrush mBrush = new SolidBrush(shapeColor);
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
            g.FillPolygon(mBrush, caraInferior.ToArray());
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
            g.FillPolygon(mBrush, caraSuperior.ToArray());
            //Dibujar líneas verticales
            mBrush.Color = shapeColor;
            for (int i = 1; i < segmentosVerticales; i+=(segmentosVerticales/12))
            {
                Vector3 superior = baseSuperior[i];
                Vector3 inferior = baseInferior[i];
                g.DrawLine(cPen, new PointF(inferior.X + screenCenterX, -inferior.Y + screenCenterY),
               new PointF(superior.X + screenCenterX, -superior.Y + screenCenterY));
            }
            //Colorear los lados
            
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


        public void escalarCilindro(float factor)
        {
            float newHeight = alturaCilindro * factor;
            float newRadius = radioBase * factor;
            bool muyChico = (newHeight <= 20 && newRadius <= 12 && factor < 1);
            bool muyAlto = (shapeCenter.Y + (newHeight / 2) >= (screenCenterY*2)-20 ) && factor>1;
            bool muyAncho = (shapeCenter.X + newRadius >= (screenCenterX * 2)-20) && factor >1;
            if (!muyAlto && !muyChico && !muyAncho)
            {
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


