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

        public Theme()
        {
            WindowTheme = new WindowTheme();
        }

    }

    public class WindowTheme
    {
        public Color BackColor { get; set; }
        public Color HeaderBackColor { get; set; }
        public int HeaderHeight { get; set; }
        public Color TitleColor { get; set; }
        public Color InactiveTitleColor { get; set; }

        public Color ButtonColor { get; set; }
        public Color ButtonInactiveColor { get; set; }

        public Color ButtonHoverColor { get; set; }
        public Color ButtonHoverBackColor { get; set; }
        public Color ButtonHoverBorderColor { get; set; }
        public int ButtonHoverBorderWidth { get; set; }

        public Color ButtonDownColor { get; set; }
        public Color ButtonDownBackColor { get; set; }
        public Color ButtonDownBorderColor { get; set; }
        public int ButtonDownBorderWidth { get; set; }
    }
}
