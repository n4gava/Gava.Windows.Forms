using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gava.Windows.Forms
{
    public class GavaCloseWindowButton : GavaWindowButton
    {
        public GavaCloseWindowButton()
        {
            base.Text = "r";
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            this.Form.Close();
        }
    }
}
