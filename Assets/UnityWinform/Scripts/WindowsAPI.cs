#if UNITY_STANDALONE_WIN

using System;
using System.Runtime.InteropServices;

namespace PurpacaGames.UnityWinform
{
    /// <summary>
    /// 外部的WindowsAPI
    /// </summary>
    public class WindowsAPI
    {
        #region 常量
        /// <summary>
        /// 最小化
        /// </summary>
        public const int SW_SHOWMINIMIZED = 2;

        /// <summary>
        /// 最大化
        /// </summary>
        public const int SW_SHOWMAXIMIZED = 3;

        /// <summary>
        /// 还原
        /// </summary>
        public const int SW_SHOWRESTORE = 1;

        /// <summary>
        /// 窗口风格
        /// </summary>
        public const int GWL_STYLE = -16;

        /// <summary>
        /// 标题栏
        /// </summary>
        public const int WS_CAPTION = 0x00c00000;

        /// <summary>
        /// 标题栏按钮
        /// </summary>
        public const int WS_SYSMENU = 0x00080000;
        #endregion

        #region 方法
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern long GetWindowLong(IntPtr hwd, int nIndex);

        [DllImport("user32.dll")]
        public static extern void SetWindowLong(IntPtr hwd, int nIndex, long dwNewLong);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hwd, int cmdShow);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        #endregion
    }
}
#endif