using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gava.Windows.Themes
{
    public class Theme
    {
        public string ThemeName { get; set; }

        public WindowTheme WindowTheme { get; set; }
        public ButtonTheme ButtonFormTheme { get; set; }
        public ButtonTheme ButtonMainTheme { get; set; }
        public ButtonTheme ButtonLabelTheme { get; set; }

        public Theme()
        {
            WindowTheme = new WindowTheme();
            ButtonFormTheme = new ButtonTheme();
            ButtonMainTheme = new ButtonTheme();
            ButtonLabelTheme = new ButtonTheme();
        }

    }
}
