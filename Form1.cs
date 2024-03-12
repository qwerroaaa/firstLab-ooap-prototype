using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            int ID { get; }
            IShape Clone();
            void Draw(Graphics graphics, Point startPoint, Point endPoint);
            bool IsPointInside(Point point);
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
            public bool IsPointInside(Point point)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(new Rectangle(point.X - 2, point.Y - 2, 4, 4)); // 4 - точный размер для определения попадания
                return path.IsVisible(point);
            }

            private static int idCounter = 0;
            public int ID { get; } // Уникальный идентификатор фигуры
            public RectangleShape()
            {
                ID = idCounter++;
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

            public bool IsPointInside(Point point)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddPolygon(GetTriangle(point, point)); // Треугольник с одной точкой - это просто линия
                return path.IsVisible(point);
            }

            private static int idCounter = 0;
            public int ID { get; } // Уникальный идентификатор фигуры
            public TriangleShape()
            {
                ID = idCounter++;
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

            public bool IsPointInside(Point point)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(new Rectangle(point.X - 2, point.Y - 2, 4, 4));
                return path.IsVisible(point);
            }

            private static int idCounter = 0;
            public int ID { get; } // Уникальный идентификатор фигуры
            public CircleShape()
            {
                ID = idCounter++;
            }
        }
        private List<IShape> shapes = new List<IShape>();
        private IShape rectanglePrototype = new RectangleShape();
        private IShape trianglePrototype = new TriangleShape();
        private IShape circlePrototype = new CircleShape();
        private bool eraseMode = false;
        private IShape selectedShape;
        private Point startPoint;
        private Point endPoint;
        private Point startDrawingPoint;
        private Color selectedColor = Color.Black;
        

        private void drawBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (!eraseMode && selectedShape != null)
            {
                startPoint = e.Location;
                // Проверяем, были ли сохранены начальные координаты для рисования фигуры
                if (startDrawingPoint == Point.Empty)
                {
                    startDrawingPoint = e.Location;
                }
                else
                {
                    selectedShape.Draw(drawBoard.CreateGraphics(), startDrawingPoint, e.Location);
                    shapes.Add(selectedShape.Clone());
                    startDrawingPoint = Point.Empty; // Сбрасываем начальные координаты
                }
            }
            else if (eraseMode)
            {
                foreach (var shape in shapes.ToList()) // Копируем список для безопасного удаления во время итерации
                {
                    if (shape.IsPointInside(e.Location))
                    {
                        shapes.Remove(shape);
                        drawBoard.Invalidate();
                        break; // Удаляем только один объект при клике
                    }
                }
            }
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
            selectedShape = rectanglePrototype.Clone();
            startDrawingPoint = Point.Empty;
        }

        private void drawCircle_Click(object sender, EventArgs e)
        {
            selectedShape = circlePrototype.Clone();
            startDrawingPoint = Point.Empty; // Сброс предыдущих координат начального клика
        }

        private void drawTriangle_Click(object sender, EventArgs e)
        {
            selectedShape = trianglePrototype.Clone();
            startDrawingPoint = Point.Empty;
        }
        
        private void eraseButton_Click(object sender, EventArgs e)
        {
            eraseMode = !eraseMode;

            // Обновляем визуальное состояние кнопки
            eraseButton.BackColor = eraseMode ? Color.Red : SystemColors.Control; // Например, меняем цвет кнопки

            // Если переходим в режим стирания, сбрасываем выбранную фигуру
            if (eraseMode)
            {
                selectedShape = null;
            }
        }

        private void drawBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (eraseMode)
            {
                // Сначала создаем список для хранения ссылок на фигуры, которые нужно удалить
                List<IShape> shapesToRemove = new List<IShape>();

                // Проверяем каждую фигуру
                foreach (var shape in shapes)
                {
                    // Проверяем, находится ли точка внутри текущей фигуры
                    if (shape.IsPointInside(e.Location))
                    {
                        // Если нашли фигуру для удаления, добавляем ее в список
                        shapesToRemove.Add(shape);
                    }
                }

                // После завершения итерации удаляем фигуры из основного списка
                foreach (var shapeToRemove in shapesToRemove)
                {
                    shapes.Remove(shapeToRemove);
                }

                // После удаления фигур перерисовываем поле
                drawBoard.Invalidate();
            }
        }

        private void fillButton_Click(object sender, EventArgs e)
        {
            if (selectedShape != null)
            {
                using (Graphics graphics = drawBoard.CreateGraphics())
                {
                    // Заливаем фигуру зеленым цветом
                    SolidBrush brush = new SolidBrush(Color.Green);
                    if (selectedShape is RectangleShape)
                    {
                        Rectangle rect = GetRectangle(startPoint, endPoint);
                        graphics.FillRectangle(brush, rect);
                    }
                    else if (selectedShape is CircleShape)
                    {
                        Rectangle rect = GetCircle(startPoint, endPoint);
                        graphics.FillEllipse(brush, rect);
                    }
                    else if (selectedShape is TriangleShape)
                    {
                        Point[] points = GetTriangle(startPoint, endPoint);
                        graphics.FillPolygon(brush, points);
                    }
                    brush.Dispose();
                }
            }
        }
    }
}
