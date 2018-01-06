using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gava.Windows.Forms
{
    public static class GavaCustomTooltip
    {
        private static ToolTip toolTip;

        public static void Set(Control control, string toolTipText)
        {
            if (toolTip == null)
            {
                toolTip = new ToolTip();
                toolTip.InitialDelay = 0;
                toolTip.ShowAlways = true;
            }
            toolTip.RemoveAll();
            toolTip.SetToolTip(control, toolTipText);

        }

        public static void SetToolTip(this Control control, string toolTipText)
        {
            GavaCustomTooltip.Set(control, toolTipText);
        }
    }
}
