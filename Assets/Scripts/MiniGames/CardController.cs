using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    [SerializeField] private Image m_CardFrontImage;
    [SerializeField] private TextMeshProUGUI m_CardBackText;
    [SerializeField] private int m_Index;

    private Animator m_Animator;

    private Item m_Item;
    private bool m_IsBlockClick;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        SubscribeAll();
    }

    private void OnDisable()
    {
        HideCard();
    }

    private void HideCard()
    {
        m_CardBackText.gameObject.SetActive(true);
        m_CardFrontImage.color = new Color(1, 1, 1, 0);
    }

    private void SubscribeAll()
    {
        GameEventSystem.Instance.SubscribeTo(EGameEvent.MiniGameMemoryInitCard, OnStartMiniGame);
    }

    private void OnStartMiniGame(GameEventMessage message)
    {
        if(message.Contains<List<Item>>(EGameEventMessage.ItemList, out List<Item> itens))
        {
            m_Item = m_Index < itens.Count ? itens[m_Index] : itens[0];
        }

        StartCoroutine(ChangeCardSprite());
    }

    public void OnClickCard()
    {
        if (m_IsBlockClick) return;

        AnimationBackToFront();
        m_IsBlockClick = true;
        GameEventSystem.Instance.TriggerEvent(EGameEvent.MiniGameMemoryEnd, new GameEventMessage(EGameEventMessage.Item, m_Item));
    }

    private void AnimationBackToFront()
    {
        m_Animator.SetTrigger(GameParameters.AnimationCard.TRIGGER_Card_To_Front);
    }

    private void AnimationFrontToBack()
    {
        m_Animator.SetTrigger(GameParameters.AnimationCard.TRIGGER_Card_To_Back);
    }

    public void AnimationShowHideCard()
    {

        StartCoroutine(ChangeCardSprite());
    }

    private IEnumerator ChangeCardSprite()
    {
        m_IsBlockClick = true;
        yield return null;
        AnimationBackToFront();
        m_CardFrontImage.sprite = m_Item.Sprite;

        yield return new WaitForSeconds(1.5f);
        AnimationFrontToBack();
        yield return new WaitForSeconds(0.5f);
        m_IsBlockClick = false;
    }
}
