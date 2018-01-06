using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gava.Windows.Themes
{
    public class ThemeManager
    {
        private static ThemeManager _instance;

        public static ThemeManager Instance => _instance ?? (_instance = new ThemeManager());

        public List<Theme> Themes { get; set; }

        public Theme CurrentTheme { get; set; }

        public ThemeManager()
        {
            LoadDefaultTheme();
        }

        public virtual void LoadDefaultTheme()
        {
            Themes = new List<Theme>();

            Theme lightTheme = new Theme();
            lightTheme.ThemeName = "Default Theme";
            lightTheme.WindowTheme.BackColor = Color.FromArgb(41, 57, 85);
            lightTheme.WindowTheme.HeaderBackColor = Color.FromArgb(214, 219, 233);
            lightTheme.WindowTheme.HeaderHeight = 30;
            lightTheme.WindowTheme.TitleColor = Color.Black;

            lightTheme.WindowTheme.ButtonColor = Color.Black;
            lightTheme.WindowTheme.ButtonHoverColor = Color.Black;
            lightTheme.WindowTheme.ButtonHoverBackColor = Color.FromArgb(255, 252, 244);
            lightTheme.WindowTheme.ButtonHoverBorderColor = Color.FromArgb(229, 195, 101);
            lightTheme.WindowTheme.ButtonDownColor = Color.Black;
            lightTheme.WindowTheme.ButtonDownBackColor = Color.FromArgb(255, 232, 166);
            lightTheme.WindowTheme.ButtonDownBorderColor = Color.FromArgb(229, 195, 101);

            lightTheme.ButtonFormTheme.BackColor = Color.FromArgb(217, 218, 222);
            lightTheme.ButtonFormTheme.ForeColor = Color.FromArgb(73, 80, 87);
            lightTheme.ButtonFormTheme.DisabledBackColor = Color.FromArgb(222, 223, 226);
            lightTheme.ButtonFormTheme.DisabledForeColor = Color.FromArgb(159, 167, 174);
            lightTheme.ButtonFormTheme.MouseOverBackColor = Color.FromArgb(195, 196, 199);
            lightTheme.ButtonFormTheme.MouseDownColor = Color.FromArgb(213, 213, 215);
            lightTheme.ButtonFormTheme.BorderSize = 1;
            lightTheme.ButtonFormTheme.BorderColor = Color.FromArgb(204, 205, 210);

            lightTheme.ButtonMainTheme.BackColor = Color.FromArgb(37, 138, 228);
            lightTheme.ButtonMainTheme.ForeColor = Color.White;
            lightTheme.ButtonMainTheme.DisabledBackColor = Color.FromArgb(166, 197, 255);
            lightTheme.ButtonMainTheme.DisabledForeColor = Color.White;
            lightTheme.ButtonMainTheme.MouseOverBackColor = Color.FromArgb(33, 124, 205);
            lightTheme.ButtonMainTheme.MouseDownColor = Color.FromArgb(133, 177, 216);
            lightTheme.ButtonMainTheme.BorderSize = 0;
            lightTheme.ButtonMainTheme.BorderColor = Color.FromArgb(37, 138, 228);

            lightTheme.ButtonLabelTheme.BackColor = Color.White;
            lightTheme.ButtonLabelTheme.ForeColor = Color.FromArgb(73, 80, 87);
            lightTheme.ButtonLabelTheme.DisabledBackColor = Color.White;
            lightTheme.ButtonLabelTheme.DisabledForeColor = Color.Black;
            lightTheme.ButtonLabelTheme.MouseOverBackColor = Color.FromArgb(229, 229, 229);
            lightTheme.ButtonLabelTheme.MouseDownColor = Color.FromArgb(229, 229, 229);
            lightTheme.ButtonLabelTheme.BorderSize = 0;
            lightTheme.ButtonLabelTheme.BorderColor = Color.White;

            Themes.Add(lightTheme);
            CurrentTheme = lightTheme;
        }
    }
}
