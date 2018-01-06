using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gava.Windows.Forms
{
    public class GavaBorderlessForm : Form
    {
        private bool _isLoaded = false;
        private bool aeroEnabled;
        const int RESIZE_HANDLE_SIZE = 10;
        const int BORDER_SIZE = 1;

        public Color WindowBorderColor { get; set; }

        public int HeaderHeight { get; set; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new FormBorderStyle FormBorderStyle
        {
            get { return base.FormBorderStyle; }
        }


        public FormWindowState MinMaxState
        {
            get
            {
                if (!_isLoaded) return FormWindowState.Normal;

                var s = NativeMethods.GetWindowLong(Handle, NativeConstants.GWL_STYLE);

                var max = (s & (int)WindowStyle.WS_MAXIMIZE) > 0;
                if (max) return FormWindowState.Maximized;
                var min = (s & (int)WindowStyle.WS_MINIMIZE) > 0;
                if (min) return FormWindowState.Minimized;
                return FormWindowState.Normal;
            }
        }

        public GavaBorderlessForm()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            WindowBorderColor = Color.Black;
            HeaderHeight = 40;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                base.FormBorderStyle = FormBorderStyle.Sizable;
            else
                base.FormBorderStyle = FormBorderStyle.Sizable;

            _isLoaded = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CheckAeroEnabled();
                var cp = base.CreateParams;

                if (!aeroEnabled)
                {
                    cp.ClassStyle = cp.ClassStyle | NativeConstants.CS_DROPSHADOW;
                    return cp;
                }
                else
                {
                    return cp;
                }
            }
        }

        private void CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                int response = NativeMethods.DwmIsCompositionEnabled(ref enabled);
                aeroEnabled = (enabled == 1) ? true : false;
            }
            else
            {
                aeroEnabled = false;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (DesignMode)
            {
                base.WndProc(ref m);
                return;
            }
                
            switch (m.Msg)
            {
                case (int)WindowMessages.WM_NCPAINT:
                    WmNCPaint(ref m);
                    break;
                case (int)WindowMessages.WM_NCCALCSIZE:
                    WmNCCalcSize(ref m);
                    break;
                case (int)WindowMessages.WM_NCHITTEST:
                    WmNCHistTest(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }

        }

        private void WmNCHistTest(ref Message msg)
        {
            base.WndProc(ref msg);

            Size formSize = this.Size;
            Point screenPoint = new Point(msg.LParam.ToInt32());
            Point clientPoint = this.PointToClient(screenPoint);

            bool onLeft = clientPoint.X < RESIZE_HANDLE_SIZE;
            bool onRight = clientPoint.X > Width - RESIZE_HANDLE_SIZE;
            bool onBottom = clientPoint.Y > Height - RESIZE_HANDLE_SIZE;
            bool onTop = clientPoint.Y < ( RESIZE_HANDLE_SIZE - 4);
            bool onHeader = clientPoint.Y < HeaderHeight;
            bool onRightBottom = ((clientPoint.X > Width - (RESIZE_HANDLE_SIZE + 5)) && (clientPoint.Y > Height - (RESIZE_HANDLE_SIZE + 5)));

            if (onRightBottom)
                msg.Result = (IntPtr)HitTestValues.HTBOTTOMRIGHT;
            else if (onBottom && onLeft)
                msg.Result = (IntPtr)HitTestValues.HTBOTTOMLEFT;
            else if (onTop && onRight)
                msg.Result = (IntPtr)HitTestValues.HTTOPRIGHT;
            else if (onTop && onLeft)
                msg.Result = (IntPtr)HitTestValues.HTTOPLEFT;
            else if (onBottom)
                msg.Result = (IntPtr)HitTestValues.HTBOTTOM;
            else if (onRight)
                msg.Result = (IntPtr)HitTestValues.HTRIGHT;
            else if (onTop)
                msg.Result = (IntPtr)HitTestValues.HTTOP;
            else if (onLeft)
                msg.Result = (IntPtr)HitTestValues.HTLEFT;
            else if (onHeader)
                msg.Result = (IntPtr)HitTestValues.HTCAPTION;
        }

        private void WmNCCalcSize(ref Message msg)
        {
            var r = (RECT)Marshal.PtrToStructure(msg.LParam, typeof(RECT));

            if (MinMaxState == FormWindowState.Maximized)
            {
                var x = NativeMethods.GetSystemMetrics(NativeConstants.SM_CXSIZEFRAME);
                var y = NativeMethods.GetSystemMetrics(NativeConstants.SM_CYSIZEFRAME);
                var p = NativeMethods.GetSystemMetrics(NativeConstants.SM_CXPADDEDBORDER);

                Rectangle screen = Screen.GetWorkingArea(this);
                var w = x + p;
                var h = y + p;

                r.left += w;
                r.top += h;
                r.right -= w;
                r.bottom -= h;

                var appBarData = new APPBARDATA();
                appBarData.cbSize = Marshal.SizeOf(typeof(APPBARDATA));
                var autohide = (NativeMethods.SHAppBarMessage(NativeConstants.ABM_GETSTATE, ref appBarData) & NativeConstants.ABS_AUTOHIDE) != 0;
                if (autohide) r.bottom -= 1;

                Marshal.StructureToPtr(r, msg.LParam, true);
            }

            msg.Result = IntPtr.Zero;
        }
        private void WmNCPaint(ref Message msg)
        {
            if (aeroEnabled)
            {
                var var = 2;
                NativeMethods.DwmSetWindowAttribute(Handle, 2, ref var, 4);

                int shadow = 1;
                if (MinMaxState == FormWindowState.Maximized)
                    shadow = 0;

                MARGINS margins = new MARGINS()
                {
                    bottomHeight = shadow,
                    leftWidth = 0,
                    rightWidth = 0,
                    topHeight = 0
                };



                NativeMethods.DwmExtendFrameIntoClientArea(Handle, ref margins);
            }

            msg.Result = NativeConstants.TRUE;
            base.WndProc(ref msg);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (WindowState != FormWindowState.Maximized)
                this.Padding = new Padding(BORDER_SIZE);
            else
                this.Padding = new Padding(0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!DesignMode)
            {
                if (WindowState != FormWindowState.Maximized)
                {
                    Rectangle borderRectangle = this.ClientRectangle;
                    using (Pen pen = new Pen(WindowBorderColor))
                    {
                        e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, borderRectangle.Width - 1, borderRectangle.Height - 1));
                    }
                }
            }
            base.OnPaint(e);
        }


    }
}
