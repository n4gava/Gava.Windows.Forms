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
            LoadThemes();
        }

        public void LoadThemes()
        {
            // Load all themes
            // TODO: load themes from xml files
            Themes = new List<Theme>();

            Theme lightTheme = new Theme();
            lightTheme.ThemeName = "Light Theme";
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

            Themes.Add(lightTheme);
            // TODO: save selected theme
            CurrentTheme = Themes.First();
        }
    }
}
