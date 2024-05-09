using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameTitleController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TitleMiniGameGeral;
    [SerializeField] TextMeshProUGUI m_TitleMiniGameDescription;
    [SerializeField] Image m_TitleItem;

    private void OnEnable()
    {
        SubscribeAll();
    }

    private void SubscribeAll()
    {
        GameEventSystem.Instance.SubscribeTo(EGameEvent.MiniGameMemoryInitCard, OnMiniGameStart);
    }

    private void OnDisable()
    {
        GameEventSystem.Instance.UnsubscribeFrom(EGameEvent.MiniGameMemoryInitCard, OnMiniGameStart);
    }

    private void OnMiniGameStart(GameEventMessage message)
    {
        if(message.Contains<Item>(EGameEventMessage.Item, out Item item))
        {
            m_TitleItem.sprite = item.Sprite;
            m_TitleMiniGameDescription.text = $"Find the {item.Name}:";
        }

        if (message.Contains<string>(EGameEventMessage.MiniGameTitle, out string title))
        {
            m_TitleMiniGameGeral.text = $"Mini Game <b><i>{title}</i></b>";
        }
    }
}
