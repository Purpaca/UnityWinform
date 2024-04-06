using UnityEngine;
using UnityEngine.UI;
using PurpacaGames.UnityWinform;
using UnityEngine.SceneManagement;

namespace Sample
{
    public class SampleTutorial : MonoBehaviour
    {
        public Button m_titlebarButton,m_titlemenuButton,m_maximizewindowButton,m_resizeButton;

        private void Awake()
        {

            m_titlebarButton.GetComponentInChildren<Text>().text = WindowsManager.CurrentWindowConfig.isTitleBarVisible ? "隐藏标题栏" : "显示标题栏";
            m_titlemenuButton.GetComponentInChildren<Text>().text = WindowsManager.CurrentWindowConfig.isTitleMenuVisible ? "隐藏标题栏按钮" : "显示标题栏按钮";

            m_titlebarButton.onClick.AddListener(() =>
            {
                WindowsManager.CurrentWindowConfig.isTitleBarVisible = !WindowsManager.CurrentWindowConfig.isTitleBarVisible;

                m_titlebarButton.GetComponentInChildren<Text>().text = WindowsManager.CurrentWindowConfig.isTitleBarVisible ? "隐藏标题栏" : "显示标题栏";
                WindowsManager.SetTitleBarVisibility(WindowsManager.CurrentWindowConfig.isTitleBarVisible);
            });

            m_titlemenuButton.onClick.AddListener(() =>
            {
                WindowsManager.CurrentWindowConfig.isTitleMenuVisible = !WindowsManager.CurrentWindowConfig.isTitleMenuVisible;

                m_titlemenuButton.GetComponentInChildren<Text>().text = WindowsManager.CurrentWindowConfig.isTitleMenuVisible ? "隐藏标题栏按钮" : "显示标题栏按钮";
                WindowsManager.SetTitleMenuVisibility(WindowsManager.CurrentWindowConfig.isTitleMenuVisible);
            });

            m_maximizewindowButton.onClick.AddListener(() =>
            {
                WindowsManager.MaximizeWindow();
            });

            m_resizeButton.onClick.AddListener(() =>
            {
                Screen.SetResolution(WindowsManager.CurrentWindowConfig.width, WindowsManager.CurrentWindowConfig.height, FullScreenMode.Windowed);
            });

        }

        public void ButtonGO()
        {
            SceneManager.LoadScene("Sample-Unityhub");
        }
    }
}