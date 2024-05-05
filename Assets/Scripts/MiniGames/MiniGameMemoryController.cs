using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class MiniGameMemoryController : AMiniGameController
{

    private List<Item> m_Itens;
    [SerializeField] private GameObject m_CardsPanel;

    private void Awake()
    {
    }

    protected override void AfterStart()
    {
        base.AfterStart();
        m_CardsPanel.SetActive(false);

        LoadItens();
    }
    private void LoadItens()
    {
        // TODO add random itens and randomize the list
        //m_Itens = ItemLoader.Instance.Get(m_)
        m_Itens = ItemLoader.Instance.GetAll(false);
        m_Itens = m_Itens.OrderBy(item => Random.Range(0, m_Itens.Count)).ToList<Item>();
        m_Item = m_Itens[Random.Range(0, 16)]; // Qnté des slots
    }


    private void OnMiniGameMemoryEnd(GameEventMessage message)
    {
        if(message.Contains<Item>(EGameEventMessage.Item, out Item item))
        {
            m_IsWin = m_Item.Name == item.Name;

            if(m_IsWin) Debug.Log($"YOU GOT THE {m_Item.Name}");
            else Debug.Log($"NO! YOU MISS THE {m_Item.Name}");
        }


        StartCoroutine(EndMinigameRoutine());
    }
    public override void StartMinigame()
    {
        base.StartMinigame();
        SubscribeAll();
        StartCoroutine(StartMinigameRoutine());
    }

    public override void EndMinigame()
    {
        UnsubscribeAll();
        m_CardsPanel.SetActive(false);
        base.EndMinigame();
    }

    private void SubscribeAll()
    {
        GameEventSystem.Instance.SubscribeTo(EGameEvent.MiniGameMemoryEnd, OnMiniGameMemoryEnd);
    }

    private void UnsubscribeAll()
    {
        GameEventSystem.Instance.UnsubscribeFrom(EGameEvent.MiniGameMemoryEnd, OnMiniGameMemoryEnd);
    }


    private IEnumerator StartMinigameRoutine()
    {
        yield return new WaitForSeconds(2f);

        m_CardsPanel.SetActive(true);
        yield return null;
        GameEventMessage messsage = new GameEventMessage(EGameEventMessage.ItemList, m_Itens);
        messsage.Add(EGameEventMessage.Item, m_Item); // Pour le titre
        messsage.Add(EGameEventMessage.MiniGameTitle, "Memory"); // Pour le titre
        GameEventSystem.Instance.TriggerEvent(EGameEvent.MiniGameMemoryInitCard, messsage);
        yield return new WaitForSeconds(0.1f);

        yield return new WaitForSeconds(2f);



    }

    private IEnumerator EndMinigameRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        EndMinigame();
    }
}
