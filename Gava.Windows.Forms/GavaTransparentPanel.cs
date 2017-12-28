using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gava.Windows.Forms
{
    public class GavaTransparentPanel : GavaPanel
    {
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)WindowMessages.WM_NCHITTEST:
                    m.Result = (IntPtr)HitTestValues.HTTRANSPARENT;
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}
