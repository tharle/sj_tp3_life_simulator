using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private List<ItemData> m_Inventory;

    private PlayerMoveController m_PlayerMoveController;
    private GameEventSystem m_EventSystem;


    private static PlayerController m_Instance;
    public static PlayerController Instance { get { return m_Instance; } }

    private void Awake()
    {
        if (m_Instance != null && m_Instance != this)
            Destroy(gameObject);

        m_Instance = this;
    }

    private void Start()
    {
        m_PlayerMoveController = GetComponent<PlayerMoveController>();
        m_EventSystem = GameEventSystem.Instance;
        m_Inventory = new List<ItemData>();

        SubscribeAll();
    }

    private void OnDisable()
    {
        UnsubscribeAll();
    }

    private void SubscribeAll()
    {
        m_EventSystem.SubscribeTo(EGameEvent.MiniGameEnd, OnMiniGameEnd);
    }

    private void UnsubscribeAll()
    {
        m_EventSystem.UnsubscribeFrom(EGameEvent.MiniGameEnd, OnMiniGameEnd);
    }

    private void OnMiniGameEnd(GameEventMessage message)
    {
        if (message.Contains<ItemData>(EGameEventMessage.Item, out ItemData item))
        {
            m_Inventory.Add(item);
            m_EventSystem.TriggerEvent(EGameEvent.InventoryChanged, new GameEventMessage(EGameEventMessage.Inventory, m_Inventory));
        }

    }

    public void Execute()
    {
        m_PlayerMoveController.Execute();
    }
}
