
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameFishingDisplay : MonoBehaviour
{
    [SerializeField] GameObject m_MiniGameFishingPanel;
    [SerializeField] GameObject m_FishingRodPanel;

    private void Start()
    {
        SubscribeAll();
    }

    private void SubscribeAll()
    {
        GameEventSystem.Instance.SubscribeTo(EGameEvent.MiniGameFishingDisplay, OnMiniGameFishingDisplay);
    }

    private void OnMiniGameFishingDisplay(GameEventMessage message)
    {
        if(message.Contains<bool>(EGameEventMessage.Enter, out bool enter) && enter)
        {
            m_MiniGameFishingPanel.SetActive(true);
            m_FishingRodPanel.SetActive(false);
        }

        if (message.Contains<bool>(EGameEventMessage.Exit, out bool exit) && exit)
        {
            m_FishingRodPanel.SetActive(false);
            m_MiniGameFishingPanel.SetActive(false);
        }

        if (message.Contains<bool>(EGameEventMessage.FishingRodToggle, out bool show) && show)
        {
            m_FishingRodPanel.SetActive(show);
        }
    }
}
