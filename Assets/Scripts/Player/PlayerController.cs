using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int m_InventorySlotMax = 5;
    private List<ItemData> m_Inventory;

    private PlayerMoveController m_PlayerMoveController;
    private GameEventSystem m_EventSystem;
    private AMiniGameController m_MiniGameController;
    public AMiniGameController MiniGameControleValue { get => m_MiniGameController; }


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
        m_MiniGameController = null;

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

    private void OnTriggerEnter(Collider other)
    {
        AMiniGameController miniGameController = other.GetComponent<AMiniGameController>();

        if(miniGameController != null)
        {
            m_MiniGameController = miniGameController;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        AMiniGameController miniGameController = other.GetComponent<AMiniGameController>();

        if (miniGameController != null)
        {
            m_MiniGameController = null;
        }
    }


    private void OnMiniGameEnd(GameEventMessage message)
    {
        if (message.Contains<ItemData>(EGameEventMessage.Item, out ItemData item) && !IsInventoryFull())
        {
            m_Inventory.Add(item);
            m_EventSystem.TriggerEvent(EGameEvent.InventoryChanged, new GameEventMessage(EGameEventMessage.Inventory, m_Inventory));
        }

    }

    private bool IsInventoryFull()
    {
        return m_Inventory.Count >= m_InventorySlotMax;
    }

    public void Execute()
    {
        m_PlayerMoveController.Execute();
    }
}
