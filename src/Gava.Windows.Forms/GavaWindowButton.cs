using Gava.Windows.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gava.Windows.Forms
{
    public enum EWindowButtonType
    {
        CloseButton,
        MinimizeButton,
        MaximizeButton
    }

    enum MouseState
    {
        Normal,
        Hover,
        Down
    }

    public class GavaWindowButton : Label
    {

        private Form _form;
        private EWindowButtonType _windowButtonType;
        private MouseState _currentMouseState;

        public static Color ActiveTextColor
        {
            get { return ThemeManager.Instance.CurrentTheme.WindowTheme.ButtonColor; }
        }

        public static Color InactiveTextColor
        {
            get { return ThemeManager.Instance.CurrentTheme.WindowTheme.ButtonInactiveColor; }
        }

        public static Color HoverBackColor
        {
            get { return ThemeManager.Instance.CurrentTheme.WindowTheme.ButtonHoverBackColor; }
        }

        public static Color HoverTextColor
        {
            get { return ThemeManager.Instance.CurrentTheme.WindowTheme.ButtonHoverColor; }
        }

        public static Color DownBackColor
        {
            get { return ThemeManager.Instance.CurrentTheme.WindowTheme.ButtonDownBackColor; }
        }

        public static Color DownTextColor
        {
            get { return ThemeManager.Instance.CurrentTheme.WindowTheme.ButtonDownColor; }
        }

        public static Color BorderHoverColor
        {
            get { return ThemeManager.Instance.CurrentTheme.WindowTheme.ButtonHoverBorderColor; }
        }

        public static Color BorderDownColor
        {
            get { return ThemeManager.Instance.CurrentTheme.WindowTheme.ButtonDownBorderColor; }
        }


        public EWindowButtonType WindowButtonType
        {
            get { return _windowButtonType; }
            set
            {
                _windowButtonType = value;
                UpdateText();
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }


        public GavaWindowButton()
        {
            WindowButtonType = EWindowButtonType.CloseButton;
            SetFont();
            MouseEnter += (s, e) => SetLabelColors((Control)s, MouseState.Hover);
            MouseLeave += (s, e) => SetLabelColors((Control)s, MouseState.Normal);
            MouseDown += (s, e) => SetLabelColors((Control)s, MouseState.Down);
        }

        private Form Form
        {
            get
            {
                if (_form == null)
                    LoadForm();

                return _form;
            }
        }


        private void LoadForm()
        {
            _form = this.FindForm();

            _form.SizeChanged += (obj, e) =>
            {
                if (_windowButtonType == EWindowButtonType.MaximizeButton)
                    Text = _form.WindowState == FormWindowState.Maximized ? "2" : "1";
            };
        }


        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            switch (_windowButtonType)
            {
                case EWindowButtonType.CloseButton:
                    Form.Close();
                    break;
                case EWindowButtonType.MinimizeButton:
                    Form.WindowState = FormWindowState.Minimized;
                    break;
                case EWindowButtonType.MaximizeButton:
                    Form.WindowState = _form.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
                    break;
                default:
                    break;
            }
        }


        protected override void OnParentBackColorChanged(EventArgs e)
        {
            BackColor = Parent.BackColor;
        }

        private void SetFont()
        {
            base.Font = new Font("Marlett", 8.5f);
            base.ForeColor = ActiveTextColor;
        }

        private void UpdateText()
        {
            switch (_windowButtonType)
            {
                case EWindowButtonType.CloseButton:
                    base.Text = "r";
                    break;
                case EWindowButtonType.MinimizeButton:
                    base.Text = "0";
                    break;
                case EWindowButtonType.MaximizeButton:
                    base.Text = "1";
                    break;
                default:
                    break;
            }
        }

        private void SetLabelColors(Control control, MouseState state)
        {
            _currentMouseState = state;
            Color textColor = ActiveTextColor;
            Color backColor = Parent.BackColor;

            switch (_currentMouseState)
            {
                case MouseState.Hover:
                    textColor = HoverTextColor;
                    backColor = HoverBackColor;
                    break;
                case MouseState.Down:
                    textColor = DownTextColor;
                    backColor = DownBackColor;
                    break;
            }

            ForeColor = textColor;
            base.BackColor = backColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color borderColor;
            switch (_currentMouseState)
            {
                case MouseState.Hover:
                    borderColor = BorderHoverColor;
                    break;
                case MouseState.Down:
                    borderColor = BorderDownColor;
                    break;
                default:
                    return;
                    break;
            }

            Rectangle buttonBorder = this.ClientRectangle;
            buttonBorder.Height--;
            buttonBorder.Width--;
            using (Pen pen = new Pen(borderColor))
            {
                e.Graphics.DrawLine(pen, new Point(0, 0), new Point(0, buttonBorder.Height));
                e.Graphics.DrawLine(pen, new Point(0, buttonBorder.Height), new Point(buttonBorder.Width, buttonBorder.Height));
                e.Graphics.DrawLine(pen, new Point(buttonBorder.Width, buttonBorder.Height), new Point(buttonBorder.Width, 0));
                
            }

        }
    }
}
