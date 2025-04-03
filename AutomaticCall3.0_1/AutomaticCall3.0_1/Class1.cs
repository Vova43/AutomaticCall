using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace AutomaticCall3._0_1
{
    public class Class1 : System.Windows.Forms.Control
    {
        private StringFormat Sf = new StringFormat();
        private bool MouseEnter_ = false;
        private bool MouseDown_ = false;
        public Class1()
        {
            InitializeComponent();
            Size = new Size(10, 20);
        }

        private void InitializeComponent()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Sf.Alignment = StringAlignment.Center;
            Sf.LineAlignment = StringAlignment.Center;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //g.Clear(Color.Blue);

            Rectangle Rectangle_ = new Rectangle(0, 0, Width - 1, Height - 1);
            g.DrawRectangle(new Pen(BackColor), Rectangle_);
            g.FillRectangle(new SolidBrush(BackColor), Rectangle_);

            if (MouseEnter_)
            {
                g.DrawRectangle(new Pen(Color.FromArgb(60, Color.White)), Rectangle_);
                g.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.White)), Rectangle_);
            }

            if (MouseDown_)
            {
                g.DrawRectangle(new Pen(Color.FromArgb(30, Color.Black)), Rectangle_);
                g.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), Rectangle_);
            }
            
            g.DrawString(Text, Font, new SolidBrush(ForeColor), Rectangle_, Sf);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseEnter_ = true;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseEnter_ = false;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MouseDown_ = false;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MouseDown_ = true;
            Invalidate();
        }
    }
}
