using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gava.Windows.Forms
{
    public class GavaStatusStrip : StatusStrip
    {
        protected override void WndProc(ref Message m)
        {
            if (!TransparentControl.WndProc(DesignMode, ref m))
            {
                base.WndProc(ref m);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle borderRectangle = this.ClientRectangle;
            using (Pen pen = new Pen(this.BackColor))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, borderRectangle.Width - 1, borderRectangle.Height - 1));
            }
        }
    }
}
