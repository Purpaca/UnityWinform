namespace PurpacaGames.UnityWinform
{
    /// <summary>
    /// 窗口的配置信息
    /// </summary>
    [System.Serializable]
    public class WindowConfig
    {
        /// <summary>
        /// 窗口的宽
        /// </summary>
        public int width;
        /// <summary>
        /// 窗口的高
        /// </summary>
        public int height;

        /// <summary>
        /// 窗口的标题栏是否可见？
        /// </summary>
        public bool isTitleBarVisible;
        /// <summary>
        /// 窗口的标题栏菜单按钮是否可见？
        /// </summary>
        public bool isTitleMenuVisible;
    }
}