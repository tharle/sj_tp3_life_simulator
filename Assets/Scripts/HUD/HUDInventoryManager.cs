using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDInventoryManager : MonoBehaviour
{
    [SerializeField] private Image[] m_Slots = new Image[5];

    private void OnEnable()
    {
        SubscribeAll();
    }

    private void OnDisable()
    {
        UnsubscribeAll();
    }


    private void SubscribeAll()
    {
        GameEventSystem.Instance.SubscribeTo(EGameEvent.InventoryChanged, OnInventoryChanged);
    }

    private void UnsubscribeAll()
    {
        GameEventSystem.Instance.UnsubscribeFrom(EGameEvent.InventoryChanged, OnInventoryChanged);
    }

    private void OnInventoryChanged(GameEventMessage message)
    {
        if(message.Contains<List<ItemData>>(EGameEventMessage.Inventory, out List<ItemData> items))
        {
            Refresh(items);
        }
    }

    private void Refresh(List<ItemData> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            m_Slots[i].sprite = items[i].Sprite;
        }
    }
}