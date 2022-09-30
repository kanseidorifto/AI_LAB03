using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_LAB02
{
    public partial class TileControl : UserControl
    {
        bool state;
        int X;
        int Y;
        
        public TileControl()
        {
            this.state = false;
            X = 0;
            Y = 0;
            Size = new Size(50,50);
            
        }
        //bool state = false, int x = 0, int y = 0, int w = 30, int h = 30
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            state = !state;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            if (state)

                g.FillRectangle(Brushes.Yellow, X, Y, Size.Width, Size.Height);
            else
                g.FillRectangle(Brushes.Gray, X, Y, Size.Width, Size.Height);

        }
        public bool GetState()
        {
            return state;
        }
        public void SetState(bool state)
        {
            this.state = state;
            Invalidate();
        }
    }
}
