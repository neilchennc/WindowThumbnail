using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowThumbnail
{
    public partial class MainForm : Form
    {
        #region Constants

        static readonly int GWL_STYLE = -16;
        static readonly int GWL_EXSTYLE = -20;

        static readonly int DWM_TNP_VISIBLE = 0x8;
        static readonly int DWM_TNP_OPACITY = 0x4;
        static readonly int DWM_TNP_RECTDESTINATION = 0x1;

        static readonly ulong WS_VISIBLE = 0x10000000L;
        static readonly ulong WS_BORDER = 0x00800000L;
        static readonly ulong WS_EX_TOOLWINDOW = 0x00000080L;
        static readonly ulong TARGETWINDOW = WS_BORDER | WS_VISIBLE;

        #endregion

        #region DWM functions

        [DllImport("dwmapi")]
        static extern int DwmRegisterThumbnail(IntPtr dest, IntPtr src, out IntPtr thumb);

        [DllImport("dwmapi")]
        static extern int DwmUnregisterThumbnail(IntPtr thumb);

        [DllImport("dwmapi")]
        static extern int DwmQueryThumbnailSourceSize(IntPtr thumb, out PSIZE size);

        [DllImport("dwmapi")]
        static extern int DwmUpdateThumbnailProperties(IntPtr hThumb, ref DWM_THUMBNAIL_PROPERTIES props);

        #endregion

        #region Win32 helper functions

        [DllImport("user32", CharSet = CharSet.Unicode)]
        static extern ulong GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32")]
        static extern int EnumWindows(EnumWindowsCallback lpEnumFunc, int lParam);
        delegate bool EnumWindowsCallback(IntPtr hwnd, int lParam);

        [DllImport("user32", CharSet = CharSet.Unicode)]
        public static extern void GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        #endregion

        private IntPtr Thumb;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetWindows();
        }

        #region Retrieve list of windows

        private void GetWindows()
        {
            WindowListControl.Items.Clear();
            EnumWindows(EnumWindowCallback, 0);
        }

        private bool EnumWindowCallback(IntPtr hwnd, int lParam)
        {
            //if (this.Handle != hwnd && (GetWindowLong(hwnd, GWL_STYLE) & TARGETWINDOW) == TARGETWINDOW)
            if (this.Handle != hwnd && (GetWindowLong(hwnd, GWL_STYLE) & WS_VISIBLE) != 0 && (GetWindowLong(hwnd, GWL_EXSTYLE) & WS_EX_TOOLWINDOW) == 0)
            {
                StringBuilder sb = new StringBuilder(256);
                GetWindowText(hwnd, sb, sb.Capacity);

                WindowListControl.Items.Add(new Window
                {
                    Handle = hwnd,
                    Title = sb.ToString()
                });
            }

            return true; // continue enumeration
        }

        #endregion

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            if (Thumb != IntPtr.Zero)
                DwmUnregisterThumbnail(Thumb);

            GetWindows();
        }

        private void WindowListControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Window w = (Window)WindowListControl.SelectedItem;

            if (Thumb != IntPtr.Zero)
                DwmUnregisterThumbnail(Thumb);

            int i = DwmRegisterThumbnail(this.Handle, w.Handle, out Thumb);

            if (i == 0)
                UpdateThumb();
        }

        #region Update thumbnail properties

        private void UpdateThumb()
        {
            if (Thumb != IntPtr.Zero)
            {
                DwmQueryThumbnailSourceSize(Thumb, out PSIZE size);

                DWM_THUMBNAIL_PROPERTIES props = new DWM_THUMBNAIL_PROPERTIES
                {
                    fVisible = true,
                    dwFlags = DWM_TNP_VISIBLE | DWM_TNP_RECTDESTINATION | DWM_TNP_OPACITY,
                    //opacity = (byte)opacity.Value,
                    opacity = 255,
                    rcDestination = new Rect(ThumbnailControl.Left, ThumbnailControl.Top, ThumbnailControl.Right, ThumbnailControl.Bottom)
                };

                if (size.x < ThumbnailControl.Width)
                    props.rcDestination.Right = props.rcDestination.Left + size.x;

                if (size.y < ThumbnailControl.Height)
                    props.rcDestination.Bottom = props.rcDestination.Top + size.y;

                DwmUpdateThumbnailProperties(Thumb, ref props);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            UpdateThumb();
        }

        #endregion
    }

    internal class Window
    {
        public string Title;
        public IntPtr Handle;

        public override string ToString()
        {
            return Title;
        }
    }

    #region Interop structs

    [StructLayout(LayoutKind.Sequential)]
    internal struct DWM_THUMBNAIL_PROPERTIES
    {
        public int dwFlags;
        public Rect rcDestination;
        public Rect rcSource;
        public byte opacity;
        public bool fVisible;
        public bool fSourceClientAreaOnly;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct Rect
    {
        internal Rect(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PSIZE
    {
        public int x;
        public int y;
    }

    #endregion
}