using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gava.Windows.Themes
{
    public enum EButtonTypes
    {
        Form,
        Main,
        Label,
        Custom
    }

    public class ButtonTheme
    {
        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }
        public Color DisabledBackColor { get; set; }
        public Color DisabledForeColor { get; set; }
        public Color MouseOverBackColor { get; set; }
        public Color MouseDownColor { get; set; }
        public int BorderSize { get; set; }
        public Color BorderColor { get; set; }
    }
}
