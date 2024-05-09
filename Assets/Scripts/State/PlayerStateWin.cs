using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerStateWin : APlayerState
{
    public PlayerStateWin(PlayerBehaviorManager attachedBehavior) : base(attachedBehavior, EPlayerState.Win)
    {
    }

    public override void Enter()
    {
        base.Enter();
        AudioManager.Instance.Play(EAudio.SFXWinGame, m_PlayerBehavior.transform.position);
        GameEventSystem.Instance.TriggerEvent(EGameEvent.GameEndDisplay, new GameEventMessage(EGameEventMessage.ItemList, m_PlayerBehavior.Inventory));
    }
}
