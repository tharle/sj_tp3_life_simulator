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

    private List<Item> m_Itens;
    [SerializeField] private GameObject m_CardsPanel;

    private void Awake()
    {
        if (m_Instance != null)
            Destroy(gameObject);

        m_Instance = this;
        SubscribeAll();
    }

    protected override void AfterStart()
    {
        base.AfterStart();
        m_CardsPanel.SetActive(false);

        LoadItens();
    }
    private void SubscribeAll()
    {
        GameEventSystem.Instance.SubscribeTo(EGameEvent.MiniGameMemoryEnd, OnMiniGameMemoryEnd);
    }

    private void LoadItens()
    {
        // TODO add random itens and randomize the list
        //m_Itens = ItemLoader.Instance.Get(m_)
        m_Itens = new List<Item>() { m_Item };
    }


    private void OnMiniGameMemoryEnd(GameEventMessage message)
    {
        if(message.Contains<Item>(EGameEventMessage.Item, out Item item))
        {
            m_IsWin = m_Item.ItemId == item.ItemId;

            if(m_IsWin) Debug.Log($"YOU GOT THE {m_Item.Name}");
            else Debug.Log($"NO! YOU MISS THE {m_Item.Name}");
        }


        StartCoroutine(EndMinigameRoutine());
    }
    public override void StartMinigame()
    {
        m_CardsPanel.SetActive(true);
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
        m_CardsPanel.SetActive(true);
        yield return null;
        GameEventSystem.Instance.TriggerEvent(EGameEvent.MiniGameMemoryStart, new GameEventMessage(EGameEventMessage.ItemList, m_Itens));
        yield return new WaitForSeconds(0.1f);

        yield return new WaitForSeconds(2f);



    }

    private IEnumerator EndMinigameRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        EndMinigame();
    }
}
