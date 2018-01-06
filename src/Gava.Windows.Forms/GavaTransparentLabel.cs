using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gava.Windows.Forms
{
    public class GavaTransparentLabel : GavaLabel
    {
        protected override void WndProc(ref Message m)
        {
            if (!TransparentControl.WndProc(DesignMode, ref m))
            {
                base.WndProc(ref m);
            }
        }
    }
}
