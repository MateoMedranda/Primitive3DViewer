using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualBasic.Devices;

namespace Interactive3DPrimitives
{
    internal class Cilindro
    {
        private float radioBase;
        private float alturaCilindro;
        private List<Vector3> baseInferior;
        private List<Vector3> baseSuperior;
        private int screenCenterX;
        private int screenCenterY;
        private Color shapeColor;
        private int segmentosVerticales;

        public Cilindro()
        {
            radioBase = 100;
            alturaCilindro = 400;
            segmentosVerticales = 36;
            shapeColor = Color.FromArgb(100, 45, 120, 12);
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
            baseInferior.Add(new Vector3(0, -midHeight, 0));
            baseSuperior.Add(new Vector3(0, midHeight,0));
            for (int i = 0; i <= segmentosVerticales; i++)
            {
                float angulo = 2 * (float)Math.PI * i / segmentosVerticales;
                float x = radioBase * (float)Math.Cos(angulo);
                float y = radioBase * (float)Math.Sin(angulo);
                baseInferior.Add(new Vector3(x,-midHeight,y));
                baseSuperior.Add(new Vector3(x, midHeight,y));
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
            g.DrawLine(cPen, new PointF(baseInferior[0].X + screenCenterX + 10,
                -baseInferior[0].Y + screenCenterY - 10),
               new PointF(baseSuperior[0].X + screenCenterX + 10,
               -baseSuperior[0].Y + screenCenterY - 10));
        }
        public void RotarX(float angulo)
        {
            float rad = angulo * (float)Math.PI / 180f;

            foreach (var low in baseInferior)
            {
                float y = low.getY();
                float z = low.getZ();
                low.setY(y * (float)Math.Cos(rad) - z * (float)Math.Sin(rad));
                low.setZ(y * (float)Math.Sin(rad) + z * (float)Math.Cos(rad));
            }
            foreach (var top in baseSuperior)
            {
                float y = top.getY();
                float z = top.getZ();
                top.setY(y * (float)Math.Cos(rad) - z * (float)Math.Sin(rad));
                top.setZ(y * (float)Math.Sin(rad) + z * (float)Math.Cos(rad));
            }
        }

        public void RotarY(float angulo)
        {
            float rad = angulo * (float)Math.PI / 180f;

            foreach (var low in baseInferior)
            {
                float x = low.getX();
                float z = low.getZ();
                low.setX(x * (float)Math.Cos(rad) + z * (float)Math.Sin(rad));
                low.setZ(-x * (float)Math.Sin(rad) + z * (float)Math.Cos(rad));
            }
            foreach (var top in baseSuperior)
            {
                float x = top.getX();
                float z = top.getZ();
                top.setX(x * (float)Math.Cos(rad) + z * (float)Math.Sin(rad));
                top.setZ(-x * (float)Math.Sin(rad) + z * (float)Math.Cos(rad));
            }
        }

        public void RotarZ(float angulo)
        {
            float rad = angulo * (float)Math.PI / 180f;
            foreach (var low in baseInferior)
            {
                float x = low.getX();
                float y = low.getY();
                low.setY(x * (float)Math.Cos(rad) - y * (float)Math.Sin(rad));
                low.setZ(x * (float)Math.Sin(rad) + y * (float)Math.Cos(rad));
            }
            foreach (var top in baseSuperior)
            {
                float x = top.getX();
                float y = top.getY();
                top.setY(x * (float)Math.Cos(rad) - y * (float)Math.Sin(rad));
                top.setZ(x * (float)Math.Sin(rad) + y * (float)Math.Cos(rad));
            }
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
            screenCenterX += (positive) ? 5 : -5;
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
            screenCenterY += (positive) ? 5 : -5;
        }
        public void moverZ(String direction)
        {
            Boolean positive = (direction.Equals("up")) ? true : false;
            foreach (Vector3 vertex in baseInferior)
            {
                vertex.Z += (positive) ? 5 : -5;
            }
            foreach (Vector3 vertex in baseSuperior)
            {
                vertex.Z += (positive) ? 5 : -5;
            }
            screenCenterY += (positive) ? 5 : -5;
        }

        public void escalarCilindro(float factor)
        {
            //Pendiente
        }


        
    }

}
