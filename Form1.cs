using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAPwithPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private interface IShape
        {
            IShape Clone();
            void Draw(Graphics graphics, Point startPoint, Point endPoint);
        }

        private class RectangleShape : IShape
        {
            public IShape Clone()
            {
                return new RectangleShape();
            }

            public void Draw(Graphics graphics, Point startPoint, Point endPoint)
            {
                Rectangle rect = GetRectangle(startPoint, endPoint);
                graphics.DrawRectangle(new Pen(Color.Black, 2), rect);
            }
        }

        private class TriangleShape: IShape
        {
            public IShape Clone()
            {
                return new TriangleShape();
            }

            public void Draw(Graphics graphics, Point startPoint, Point endPoint)
            {
                Point[] points = GetTriangle(startPoint, endPoint);
                graphics.DrawPolygon(new Pen(Color.Black, 2), points);
            }
        }

        private class CircleShape: IShape
        {
            public IShape Clone()
            {
                return new CircleShape();
            }

            public void Draw(Graphics graphics, Point startPoint, Point endPoint)
            {
                Rectangle rect = GetCircle(startPoint, endPoint);
                graphics.DrawEllipse(new Pen(Color.Black, 2), rect);
            }
        }

        private IShape rectanglePrototype = new RectangleShape();
        private IShape trianglePrototype = new TriangleShape();
        private IShape circlePrototype = new CircleShape();

        private IShape selectedShape;
        private Point startPoint;
        private Point endPoint;

        private void drawBoard_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
        }

        private void drawBoard_MouseUp(object sender, MouseEventArgs e)
        {
            endPoint = e.Location;
            DrawShape();
        }

        private void DrawShape()
        {
            if (selectedShape == null)
            {
                return;
            }

            Graphics graphics = drawBoard.CreateGraphics();
            selectedShape.Draw(graphics, startPoint, endPoint);
            graphics.Dispose();
        }

        private static Rectangle GetRectangle(Point startPoint, Point endPoint)
        {
            int width = Math.Abs(endPoint.X - startPoint.X); 
            int height= Math.Abs(endPoint.Y - startPoint.Y);
            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);

            return new Rectangle(x, y, width, height);
        }

        private static Point[] GetTriangle(Point startPoint, Point endPoint)
        {
            Point[] points = new Point[3];
            points[0] = startPoint;
            points[1] = new Point(startPoint.X, endPoint.Y);
            points[2] = endPoint;

            return points;
        }

        private static Rectangle GetCircle(Point startPoint, Point endPoint)
        {
            int width = Math.Abs(endPoint.X - startPoint.X);
            int height = Math.Abs(endPoint.Y - startPoint.Y);
            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);

            return new Rectangle(x, y, width, height);
        }

        private void drawRectangle_Click(object sender, EventArgs e)
        {
            selectedShape= rectanglePrototype.Clone();
        }

        private void drawCircle_Click(object sender, EventArgs e)
        {
            selectedShape = circlePrototype.Clone();
        }

        private void drawTriangle_Click(object sender, EventArgs e)
        {
            selectedShape = trianglePrototype.Clone();
        }
    }
}
