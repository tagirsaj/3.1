using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_Lab3
{
    public partial class Form1 : Form
    {
        // одна координата
        private Point? circlePos = null;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Этап 1: Рисуем один круг";
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            circlePos = e.Location;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (circlePos.HasValue)
            {
                // Крууг
                e.Graphics.DrawEllipse(Pens.Black, circlePos.Value.X - 30, circlePos.Value.Y - 30, 60, 60);
            }
        }
    }
}