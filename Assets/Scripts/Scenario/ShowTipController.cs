using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTipController : MonoBehaviour
{
    private void OnEnable()
    {
        GameEventSystem.Instance.SubscribeTo(EGameEvent.ToggleTips, OnToggleTips);
    }

    private void OnDisable()
    {
        GameEventSystem.Instance.UnsubscribeFrom(EGameEvent.ToggleTips, OnToggleTips);
    }

    private void OnToggleTips(GameEventMessage message)
    {
        if(message.Contains<bool>(EGameEventMessage.Toggle, out bool show))
        {
            if (show) GetComponent<Animator>().SetTrigger(GameParameters.AnimationTips.TRIGGER_SHOW);
            else GetComponent<Animator>().SetTrigger(GameParameters.AnimationTips.TRIGGER_HIDE);
        }
    }
}
