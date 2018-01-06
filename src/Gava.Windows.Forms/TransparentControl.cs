using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gava.Windows.Forms
{
    static class TransparentControl
    {
        public static bool WndProc(bool designMode, ref Message m)
        {
            if (designMode)
                return false;

            switch (m.Msg)
            {
                case (int)WindowMessages.WM_NCHITTEST:
                    m.Result = (IntPtr)HitTestValues.HTTRANSPARENT;
                    return true;
                default:
                    return false;
            }
        }
    }
}
