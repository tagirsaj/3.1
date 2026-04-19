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
            Pen p = IsSelected ? new Pen(Color.Red, 3) : new Pen(Color.Black, 2);
            g.DrawEllipse(p, X - 30, Y - 30, 60, 60);
        }
        public bool HitTest(Point p) => (X - p.X) * (X - p.X) + (Y - p.Y) * (Y - p.Y) <= 900;
    }

    public partial class Form1 : Form
    {
        private List<CCircle> storage = new List<CCircle>();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Лаб 3.1";
            this.DoubleBuffered = true;
            this.KeyPreview = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            bool ctrl = ModifierKeys.HasFlag(Keys.Control);
            bool hit = false;

            for (int i = storage.Count - 1; i >= 0; i--)
            {
                if (storage[i].HitTest(e.Location))
                {
                    if (!ctrl) DeselectAll();
                    storage[i].IsSelected = ctrl ? !storage[i].IsSelected : true;
                    hit = true; break;
                }
            }
            if (!hit)
            {
                if (!ctrl) DeselectAll();
                storage.Add(new CCircle(e.X, e.Y));
            }
            this.Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                storage.RemoveAll(x => x.IsSelected);
                this.Invalidate();
            }
        }

        private void DeselectAll() => storage.ForEach(x => x.IsSelected = false);

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var circle in storage) circle.Draw(e.Graphics);
        }
    }
}