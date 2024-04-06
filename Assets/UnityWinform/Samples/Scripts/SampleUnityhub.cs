using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using PurpacaGames.UnityWinform;

namespace Sample
{
    public class SampleUnityhub : MonoBehaviour
    {
        [SerializeField]
        RectTransform m_topbar;
        [SerializeField]
        Button m_minimizeButton;
        [SerializeField]
        Button m_maximizeButton;
        [SerializeField]
        Button m_closeButton;

        bool isMaxWindow = false;

        private void Awake()
        {
            WindowsManager.SetTitleBarVisibility(false);

            IntPtr hwd = WindowsAPI.GetForegroundWindow();

            EventTrigger eventTrigger = m_topbar.gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry beginDragEntry = new EventTrigger.Entry();
            beginDragEntry.eventID = EventTriggerType.Drag;
            beginDragEntry.callback.AddListener((data) =>
            {
                WindowsManager.WindowDragToMove();
            });
            eventTrigger.triggers.Add(beginDragEntry);

            m_closeButton.onClick.AddListener(() => Application.Quit());
            m_minimizeButton.onClick.AddListener(() => WindowsManager.MinimizeWindow());
            m_maximizeButton.onClick.AddListener(() =>
            {
                isMaxWindow = !isMaxWindow;

                if (isMaxWindow)
                {
                    WindowsManager.MaximizeWindow();
                }
                else
                {
                    WindowsManager.RestoreWindow();
                }
            });
        }
    }
}