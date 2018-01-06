using Gava.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gava.Windows.Forms
{
    public class GavaBaseForm : GavaBorderlessForm
    {
        private GavaTransparentPanel _headerPanel = new GavaTransparentPanel();
        private GavaTransparentPanel _clientArea = new GavaTransparentPanel();
        private GavaCloseWindowButton _buttonClose = new GavaCloseWindowButton();
        private GavaMinimizeWindowButton _buttonMinimize = new GavaMinimizeWindowButton();
        private GavaMaximizeWindowButton _buttonMaximize = new GavaMaximizeWindowButton();
        private GavaTransparentPanel _panelIcon = new GavaTransparentPanel();
        private GavaTransparentPictureBox _icon = new GavaTransparentPictureBox();
        private GavaTransparentLabel _titleText = new GavaTransparentLabel();

        protected virtual GavaTransparentPanel ClientArea
        {
            get { return _clientArea; }
        }

        protected virtual void CreateTitleText()
        {
            _titleText.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            _titleText.Text = this.Text;
            _titleText.ForeColor = ThemeManager.Instance.CurrentTheme.WindowTheme.TitleColor;
            _titleText.TextAlign = ContentAlignment.MiddleLeft;
            _titleText.Size = new Size(Int16.MaxValue, ThemeManager.Instance.CurrentTheme.WindowTheme.HeaderHeight);
            _titleText.Location = new Point(40, 0);
            _headerPanel.Controls.Add(_titleText);
        }

        protected virtual void CreateLogo()
        {
            int iconBorder = 4;
            _panelIcon.Dock = DockStyle.Left;
            _panelIcon.Size = new Size(ThemeManager.Instance.CurrentTheme.WindowTheme.HeaderHeight, 0);
            _panelIcon.Padding = new Padding(iconBorder);

            _icon.Image = this.Icon.ToBitmap();
            _icon.Dock = DockStyle.Fill;
            _icon.SizeMode = PictureBoxSizeMode.StretchImage;

            _panelIcon.Controls.Add(_icon);
            _headerPanel.Controls.Add(_panelIcon);
        }

        protected virtual void CreateWindowsButtons()
        {
            Size buttonsSize = new Size(ThemeManager.Instance.CurrentTheme.WindowTheme.HeaderHeight, 0);

            _buttonMinimize.Dock = DockStyle.Right;
            _buttonMinimize.Size = buttonsSize;
            _buttonMinimize.TextAlign = ContentAlignment.MiddleCenter;

            _buttonMaximize.Dock = DockStyle.Right;
            _buttonMaximize.Size = buttonsSize;
            _buttonMaximize.TextAlign = ContentAlignment.MiddleCenter;

            _buttonClose.Dock = DockStyle.Right;
            _buttonClose.Size = buttonsSize;
            _buttonClose.TextAlign = ContentAlignment.MiddleCenter;

            _headerPanel.Controls.Add(_buttonMinimize);
            _headerPanel.Controls.Add(_buttonMaximize);
            _headerPanel.Controls.Add(_buttonClose);
        }

        protected virtual void CreateHeaderPanel()
        {
            _headerPanel.Name = "headerPanel";
            _headerPanel.BackColor = ThemeManager.Instance.CurrentTheme.WindowTheme.HeaderBackColor;
            _headerPanel.Dock = DockStyle.Top;
            _headerPanel.Size = new Size(0, ThemeManager.Instance.CurrentTheme.WindowTheme.HeaderHeight);
        }

        protected virtual void InitializeComponent()
        {
            this._clientArea.SuspendLayout();
            this.SuspendLayout();

            CreateHeaderPanel();
            CreateWindowsButtons();
            CreateTitleText();
            CreateLogo();

            base.HeaderHeight = ThemeManager.Instance.CurrentTheme.WindowTheme.HeaderHeight;
            this.BackColor = ThemeManager.Instance.CurrentTheme.WindowTheme.BackColor;
            this.Controls.Add(_headerPanel);

            this.ResumeLayout(false);
            this._clientArea.ResumeLayout(false);
        }

        public GavaBaseForm()
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                InitializeComponent();
                
                foreach (Control control in this.Controls)
                {
                    control.Location = new Point(control.Location.X, control.Location.Y + ThemeManager.Instance.CurrentTheme.WindowTheme.HeaderHeight);
                }
                
            }
        }

    }
}
