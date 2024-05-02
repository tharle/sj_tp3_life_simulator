using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    [SerializeField] private Image m_Image;

    private Animator m_Animator;

    private Item m_Item;
    private bool m_IsClicked;

    public Item ItemData { 
        get 
        { 
            return m_Item; 
        } 
        set
        { 
            m_Item = value;
            m_IsClicked = false;
           StartCoroutine(ChangeCardSprite());
        }
    }

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void OnClickCard()
    {
        if (m_IsClicked) return;

        AnimationBackToFront();
        m_IsClicked = true;
        GameEventSystem.Instance.TriggerEvent(EGameEvent.MiniGameMemoryItemSelect, new GameEventMessage(EGameEventMessage.Item, m_Item));
    }

    private void AnimationBackToFront()
    {
        m_Animator.SetTrigger(GameParameters.AnimationCard.TRIGGER_Card_To_Front);
    }

    private void AnimationFrontToBack()
    {
        m_Animator.SetTrigger(GameParameters.AnimationCard.TRIGGER_Card_To_Back);
    }

    private IEnumerator ChangeCardSprite()
    {
        yield return null;
        AnimationBackToFront();
        m_Image.sprite = m_Item.Sprite;

        yield return new WaitForSeconds(0.5f);
        AnimationFrontToBack();
    }
}
