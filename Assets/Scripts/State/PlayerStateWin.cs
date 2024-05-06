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
        Debug.Log("ENTER WIN");
    }

    public override void Execute()
    {
        // TODO change camera à la caisse
        Debug.Log("IS WIN");
        GameEventSystem.Instance.TriggerEvent(EGameEvent.GameEnd, new GameEventMessage(EGameEventMessage.ItemList, m_PlayerBehavior.Inventory));
    }

    public override void Exit()
    {
        Debug.Log("EXIT WIN");
    }
}
