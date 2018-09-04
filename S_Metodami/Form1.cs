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

namespace S_Metodami
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            m = new Matrix();
            g = pictureBox1.CreateGraphics();
        }
        Graphics g;
        Matrix m;
        GraphicsPath gp = new GraphicsPath();
        int x0 = 300; //Середина pictureBox1.Width
        int y0 = 200; //Середина pictureBox1.Height
        int[] offs = {0, 0};

        /// <summary>
        /// Метод для рисования осей координат
        /// </summary>
        public void XoY()
        {
            Pen p = new Pen(Color.Black, 3);
            p.EndCap = LineCap.ArrowAnchor;
            g.DrawLine(p, x0, pictureBox1.Height, x0, 0);
            g.DrawLine(p, 0, y0, pictureBox1.Width, y0);
        }

        /// <summary>
        /// Метод для рисования сетки
        /// </summary>
        public void Setka()
        {
            for (int i = 0; i <= 30; i++)
            {
                Pen p = new Pen(Color.Gray, 1);
                g.DrawLine(p, i * 20, 0, i * 20, pictureBox1.Height);
                g.DrawLine(p, 0, i * 20, pictureBox1.Width, i * 20);
            }
        }

        /// <summary>
        /// Фигура
        /// </summary>
        public void Figure()
        {
            Point A = new Point(x0 + 20, y0 - 150),
                  B = new Point(x0 + 100, y0 - 180),
                  C = new Point(x0 + 120, y0 - 70),
                  D = new Point(x0 + 70, y0 - 50);
            Pen p = new Pen(Color.Red, 2);            
            gp.AddPolygon(new Point[]{A,B,C,D});
            g.DrawPath(p, gp);
            koord();
        }

        

        /// <summary>
        /// Перемещение фигуры
        /// </summary>
        /// <param name="offsetX">По X</param>
        /// <param name="offsetY">По Y</param>
        public void MoveFigure(float offsX, float offsY)
        {
            Pen p = new Pen(Color.Red, 2);
            m.Reset();
            m.Translate(offsX, offsY);
            gp.Transform(m);
            g.DrawPath(p, gp);
            koord();
        }
        
        /// <summary>
        /// Метод для вращения фигуры
        /// </summary>
        public void Rotate()
        {
            PointF pathP = gp.PathPoints[0];
            m.Reset();
            m.RotateAt(10, pathP);
            gp.Transform(m);
            g.DrawPath(new Pen(Color.Red, 2), gp);
            koord();
        }

        /// <summary>
        /// Метод для отображения координат точек
        /// </summary>
        public void koord()
        {
            for (int i = 0; i < gp.PointCount; i++)
			{
                g.DrawString(Convert.ToChar('A' + i).ToString() + "(" + Math.Round(gp.PathPoints[i].X - x0) + ", " + Math.Round(y0 - gp.PathPoints[i].Y) + ")", new Font("Arial", 12), Brushes.Black, gp.PathPoints[i].X, gp.PathPoints[i].Y);
			}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Setka();
            XoY();
            Figure();
            button5.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            Setka();
            XoY();
            MoveFigure(-20, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            Setka();
            XoY();
            MoveFigure(20, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            Setka();
            XoY();
            MoveFigure(0, -20);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            Setka();
            XoY();
            MoveFigure(0, 20);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            Setka();
            XoY();
            Rotate();
        }
    }
}
