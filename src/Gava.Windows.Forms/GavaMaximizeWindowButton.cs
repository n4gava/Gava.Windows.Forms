using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gava.Windows.Forms
{
    class GavaMaximizeWindowButton : GavaWindowButton
    {
        public GavaMaximizeWindowButton()
        {
            base.Text = "1";
        }

        public override void OnFormLoaded()
        {
            this.Form.SizeChanged += (objF, eF) =>
            {
                base.Text = this.Form.WindowState == FormWindowState.Maximized ? "2" : "1";
            };
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            Form.WindowState = this.Form.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }
    }
}
