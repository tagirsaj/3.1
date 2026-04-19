using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_Lab3
{
    public class CCircle
    {
        public int X, Y;
        public CCircle(int x, int y) { X = x; Y = y; }
        public void Draw(Graphics g) => g.DrawEllipse(Pens.Black, X - 30, Y - 30, 60, 60);
    }

    public partial class Form1 : Form
    {
        private List<CCircle> storage = new List<CCircle>();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Лаба 3.1";
            this.DoubleBuffered = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            storage.Add(new CCircle(e.X, e.Y));
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (var circle in storage) circle.Draw(e.Graphics);
        }
    }
}