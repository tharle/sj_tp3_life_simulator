using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTipController : MonoBehaviour
{
    private Animator m_Animator;
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        GameEventSystem.Instance.SubscribeTo(EGameEvent.ToggleTips, OnToggleTips);
    }

    private void OnToggleTips(GameEventMessage message)
    {
        if(message.Contains<bool>(EGameEventMessage.Toggle, out bool show))
        {
            if (show) m_Animator.SetTrigger(GameParameters.AnimationTips.TRIGGER_SHOW);
            else m_Animator.SetTrigger(GameParameters.AnimationTips.TRIGGER_HIDE);
        }
    }
}
