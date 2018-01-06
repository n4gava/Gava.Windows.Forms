using Gava.Windows.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Gava.Windows.Forms
{

    public class GavaButton : Button
    {
        EButtonTypes _buttonType;
        PushButtonState _state = PushButtonState.Normal;
        
        bool _mouseOver = false;
        bool _mouseDown = false;
        Color _disabledBackColor;
        Color _disabledForeColor;


        [Category("Appearance")]
        public string ToolTip { get; set; }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = ButtonTheme == null ? value : ButtonTheme.BackColor; }
        }

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = ButtonTheme == null ? value : ButtonTheme.ForeColor; }
        }

        [Category("Appearance")]
        public Color DisabledBackColor
        {
            get { return _disabledBackColor; }
            set { _disabledBackColor = ButtonTheme == null ? value : ButtonTheme.DisabledBackColor; }
        }

        [Category("Appearance")]
        public Color DisabledForeColor
        {
            get { return _disabledForeColor; }
            set { _disabledForeColor = ButtonTheme == null ? value : ButtonTheme.DisabledForeColor; }
        }

        [Browsable(false)]
        public new FlatButtonAppearance FlatAppearance
        {
            get { return base.FlatAppearance; }
        }

        [Category("Appearance")]
        public Color MouseOverBackColor
        {
            get { return base.FlatAppearance.MouseOverBackColor; }
            set { base.FlatAppearance.MouseOverBackColor = ButtonTheme == null ? value : ButtonTheme.MouseOverBackColor; }
        }

        [Category("Appearance")]
        public Color MouseDownBackColor
        {
            get { return base.FlatAppearance.MouseDownBackColor; }
            set { base.FlatAppearance.MouseDownBackColor = ButtonTheme == null ? value : ButtonTheme.MouseDownColor; }
        }

        [Category("Appearance")]
        public int BorderSize
        {
            get { return base.FlatAppearance.BorderSize; }
            set { base.FlatAppearance.BorderSize = ButtonTheme == null ? value : ButtonTheme.BorderSize; }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get { return base.FlatAppearance.BorderColor; }
            set { base.FlatAppearance.BorderColor = ButtonTheme == null ? value : ButtonTheme.BorderColor; }
        }

        [Category("Appearance")]
        [DisplayName("ButtonType")]
        [DefaultValue(EButtonTypes.Form)]
        public EButtonTypes ButtonType
        {
            get { return _buttonType; }
            set
            {
                _buttonType = value;
                UpdateTheme();
            }
        }

        public ButtonTheme ButtonTheme
        {
            get {
                switch (_buttonType)
                {
                    case EButtonTypes.Form:
                        return ThemeManager.Instance.CurrentTheme.ButtonFormTheme;
                    case EButtonTypes.Main:
                        return ThemeManager.Instance.CurrentTheme.ButtonMainTheme;
                    case EButtonTypes.Label:
                        return ThemeManager.Instance.CurrentTheme.ButtonLabelTheme;
                    default:
                        return null;
                }
            }
        }


        public GavaButton() : base()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.EnabledChanged += CustomButton_EnabledChanged;
            base.MouseEnter += (obj, e) =>
            {
                if (!string.IsNullOrWhiteSpace(ToolTip))
                    ((Control)obj).SetToolTip(ToolTip);
            };

            UpdateTheme();
        }

        void UpdateTheme()
        {
            if (ButtonTheme != null)
            {
                base.BackColor = ButtonTheme.BackColor;
                base.ForeColor = ButtonTheme.ForeColor;
                _disabledBackColor = ButtonTheme.DisabledBackColor;
                _disabledForeColor = ButtonTheme.DisabledForeColor;
                base.FlatAppearance.MouseOverBackColor = ButtonTheme.MouseOverBackColor;
                base.FlatAppearance.MouseDownBackColor = ButtonTheme.MouseDownColor;
                base.FlatAppearance.BorderSize = ButtonTheme.BorderSize;
                base.FlatAppearance.BorderColor = ButtonTheme.BorderColor;
            }

            this.Invalidate();
        }

        void ChangeState()
        {
            if (!this.Enabled)
                _state = PushButtonState.Disabled;
            else if (_mouseDown)
                _state = PushButtonState.Pressed;
            else if (_mouseOver)
                _state = PushButtonState.Hot;
            else
                _state = PushButtonState.Normal;

            this.Invalidate();
        }

        void CustomButton_EnabledChanged(object sender, EventArgs e)
        {
            ChangeState();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _mouseOver = true;
            ChangeState();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _mouseOver = false;
            ChangeState();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            _mouseDown = true;
            ChangeState();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _mouseDown = false;
            ChangeState();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Color backColor = base.BackColor;
            Color foreColor = base.ForeColor;

            switch (_state)
            {
                case PushButtonState.Disabled:
                    backColor = this.DisabledBackColor;
                    foreColor = this.DisabledForeColor;
                    break;
                case PushButtonState.Hot:
                    backColor = FlatAppearance.MouseOverBackColor;
                    break;
                case PushButtonState.Pressed:
                    backColor = FlatAppearance.MouseDownBackColor;
                    break;
                default:
                    break;
            }

            using (SolidBrush brush = new SolidBrush(backColor))
            {
                pevent.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            if (this.FlatAppearance.BorderSize > 0)
            {
                using (var pen = new Pen(FlatAppearance.BorderColor, this.FlatAppearance.BorderSize))
                {
                    Rectangle rect = new Rectangle(this.ClientRectangle.Location, new Size(this.ClientRectangle.Size.Width - 1, this.ClientRectangle.Size.Height - 1));
                    pevent.Graphics.DrawRectangle(pen, rect);
                }
            }

            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, foreColor, flags);
        }
    }
}
