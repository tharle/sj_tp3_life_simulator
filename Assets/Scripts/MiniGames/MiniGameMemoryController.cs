using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameMemoryController : AMiniGameController
{
    #region Singleton
    private static MiniGameMemoryController m_Instance;
    public static MiniGameMemoryController Instance { get { return m_Instance; } }
    #endregion

    [SerializeField] private List<CardController> m_Cards;
    [SerializeField] private GameObject m_CardsPanel;

    public MiniGameMemoryController() : base()
    {
        //m_CardsPanel?.SetActive(false);
        
    }

    private void Awake()
    {
        if (m_Instance != null)
            Destroy(gameObject);

        m_Instance = this;
        SubscribeAll();
    }

    private void SubscribeAll()
    {
        GameEventSystem.Instance.SubscribeTo(EGameEvent.MiniGameMemoryItemSelect, OnMiniGameMemoryItemSelect);
    }

    private void OnMiniGameMemoryItemSelect(GameEventMessage message)
    {
        if(message.Contains<Item>(EGameEventMessage.Item, out Item item))
        {
            m_IsWin = m_Item.ItemId == item.ItemId;

            if(m_IsWin) Debug.Log($"YOU GOT THE {item.Name}");
            else Debug.Log($"NO! YOU MISS THE {item.Name}");
        }


        StartCoroutine(EndMinigameRoutine());
    }
    public override void StartMinigame()
    {
        base.StartMinigame();
        StartCoroutine(StartMinigameRoutine());
    }

    public override void EndMinigame()
    {
        m_CardsPanel.SetActive(false);
        base.EndMinigame();
    }

    private IEnumerator StartMinigameRoutine()
    {
        yield return new WaitForSeconds(2f);
        m_CardsPanel.SetActive(true);
        foreach (CardController card in m_Cards)
        {
            card.ItemData = m_Item;
        }
    }

    private IEnumerator EndMinigameRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        EndMinigame();
    }
}
