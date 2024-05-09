using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateWin : APlayerState
{
    public PlayerStateWin(PlayerBehaviorManager attachedBehavior) : base(attachedBehavior, EPlayerState.Win)
    {
    }

    public override void Enter()
    {
        base.Enter();
        GameEventSystem.Instance.TriggerEvent(EGameEvent.GameEndDisplay, new GameEventMessage(EGameEventMessage.ItemList, m_PlayerBehavior.Inventory));
    }
}
