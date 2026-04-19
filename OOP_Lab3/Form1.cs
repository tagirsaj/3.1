using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_Lab3
{
    public class CCircle
    {
        public int X, Y;
        public bool IsSelected = false;
        public CCircle(int x, int y) { X = x; Y = y; }

        public void Draw(Graphics g)
        {
            Pen p = IsSelected ? new Pen(Color.Red, 3) : Pens.Black;
            g.DrawEllipse(p, X - 30, Y - 30, 60, 60);
        }

        public bool HitTest(Point p)
        {
            return (X - p.X) * (X - p.X) + (Y - p.Y) * (Y - p.Y) <= 900;
        }
    }

    public partial class Form1 : Form
    {
        private List<CCircle> storage = new List<CCircle>();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Лаб 3.1";
            this.DoubleBuffered = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            bool hit = false;
            foreach (var circle in storage) circle.IsSelected = false;

            for (int i = storage.Count - 1; i >= 0; i--)
            {
                if (storage[i].HitTest(e.Location))
                {
                    storage[i].IsSelected = true;
                    hit = true; break;
                }
            }
            if (!hit) storage.Add(new CCircle(e.X, e.Y));
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (var circle in storage) circle.Draw(e.Graphics);
        }
    }
}