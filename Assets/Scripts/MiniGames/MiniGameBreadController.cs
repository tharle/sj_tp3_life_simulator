using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameBreadController : AMiniGameController
{
    #region Singleton
    private static MiniGameBreadController m_Instance;
    public static MiniGameBreadController Instance { get { return m_Instance; } }
    #endregion

    [SerializeField] private List<CardController> m_Cards;
    [SerializeField] private GameObject m_CardsPanel;

    public MiniGameBreadController() : base()
    {
        //m_CardsPanel?.SetActive(false);
    }

    private void Awake()
    {
        if (m_Instance != null)
            Destroy(gameObject);

        m_Instance = this;
    }

    public override void StartMinigame()
    {
        base.StartMinigame();
        m_CardsPanel.SetActive(true);
        foreach (CardController card in m_Cards)
        {
            card.ItemData = m_Item;
        }

    }

    /*private IEnumerator InitCard()
    {
        foreach (CardController card in m_Cards)
        { 
            yield return new WaitForSeconds(0.5f); // attends le prochain frame
            card.ItemData = m_Item;
            //card.AnimationBackToFront();
        }
    }*/

    public override void Execute()
    {
        base.Execute();
    }
}
