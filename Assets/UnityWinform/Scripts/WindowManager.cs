using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PurpacaGames.UnityWinform
{
    public class WindowsManager : AutoInstantiateSingletonMonoBehaviour<WindowsManager>
    {
        private static WindowConfig config;

        #region 属性
        /// <summary>
        /// 当前应用程序的窗口配置信息
        /// </summary>
        public static WindowConfig CurrentWindowConfig
        {
            get 
            {
                if(config == null) 
                {
                    config = new WindowConfig();
                }

                return config;
            }
        }

        /// <summary>
        /// 是否允许最大化窗口？
        /// </summary>
        public static bool AllowMaximizeWindow { get; set; } = true;
        #endregion

        #region Public 方法
        /// <summary>
        /// 设置标题栏的显隐
        /// </summary>
        /// <param name="isVisible">是否显示标题栏？</param>
        public static void SetTitleBarVisibility(bool isVisible)
        {
            IntPtr hwd = WindowsAPI.GetForegroundWindow();
            long wl = WindowsAPI.GetWindowLong(hwd, WindowsAPI.GWL_STYLE);
            wl = isVisible ? wl | WindowsAPI.WS_CAPTION : wl & ~WindowsAPI.WS_CAPTION;
            WindowsAPI.SetWindowLong(hwd, WindowsAPI.GWL_STYLE, wl);

            config.isTitleBarVisible = isVisible;
        }

        /// <summary>
        /// 设置标题栏菜单按钮（最小化、最大化以及关闭按钮的显隐）
        /// </summary>
        /// <param name="isVisible">是否显示标题栏菜单按钮？</param>
        public static void SetTitleMenuVisibility(bool isVisible)
        {
            IntPtr hwd = WindowsAPI.GetForegroundWindow();
            var wl = WindowsAPI.GetWindowLong(hwd, WindowsAPI.GWL_STYLE);
            wl = isVisible ? wl | WindowsAPI.WS_SYSMENU : wl & ~WindowsAPI.WS_SYSMENU;
            WindowsAPI.SetWindowLong(hwd, WindowsAPI.GWL_STYLE, wl);

            config.isTitleMenuVisible = isVisible;
        }

        /// <summary>
        /// 最大化窗口
        /// </summary>
        public static void MaximizeWindow() 
        {
            if (AllowMaximizeWindow)
            {
                IntPtr hwd = WindowsAPI.GetForegroundWindow();
                WindowsAPI.ShowWindow(hwd, WindowsAPI.SW_SHOWMAXIMIZED);
            }
        }

        /// <summary>
        /// 最小化窗口
        /// </summary>
        public static void MinimizeWindow() 
        {
            IntPtr hwd = WindowsAPI.GetForegroundWindow();
            WindowsAPI.ShowWindow(hwd, WindowsAPI.SW_SHOWMINIMIZED);
        }

        /// <summary>
        /// 恢复窗口
        /// </summary>
        public static void RestoreWindow() 
        {
            instance.StartCoroutine(RestoreWindowCoroutine());
        }

        /// <summary>
        /// 当窗口拖动发生时，移动窗口
        /// </summary>
        public static void WindowDragToMove() 
        {
            IntPtr hwd = WindowsAPI.GetForegroundWindow();
            WindowsAPI.ReleaseCapture();
            WindowsAPI.SendMessage(hwd, 0xA1, 0x02, 0);
            WindowsAPI.SendMessage(hwd, 0x0202, 0, 0);
        }
        #endregion

        #region Private 方法
        /// <summary>
        /// 自动初始化窗口模式
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void InitializeWindowViaPreviousSettings()
        {
            float resolutionRatio = 0.65f;

            config = new WindowConfig();
            config.isTitleBarVisible = false;
            config.isTitleMenuVisible = false;
            config.width = (int)(Screen.mainWindowDisplayInfo.width * resolutionRatio);
            config.height = (int)(Screen.mainWindowDisplayInfo.height * resolutionRatio);

            Screen.SetResolution(config.width, config.height, FullScreenMode.Windowed);
            SetTitleBarVisibility(config.isTitleBarVisible);
            SetTitleMenuVisibility(config.isTitleMenuVisible);
        }

        private static IEnumerator RestoreWindowCoroutine() 
        {
            Screen.SetResolution(config.width, config.height, FullScreenMode.Windowed);
            yield return null;
            SetTitleBarVisibility(config.isTitleBarVisible);
        }
        #endregion

        #region Unity 消息
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this.gameObject);
        }
        #endregion
    }
}