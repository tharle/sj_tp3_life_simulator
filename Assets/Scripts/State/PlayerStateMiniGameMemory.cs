using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerStateMiniGameMemory : APlayerState
{
    public PlayerStateMiniGameMemory(PlayerBehaviorManager attachedBehavior) : base(attachedBehavior, EPlayerState.MiniGameMemory)
    {
    }

    public override void Enter()
    {
        Debug.Log("ENTER Mini Game Memory");
        m_PlayerBehavior.CurrentMiniGame.StartMinigame();
        SubscribeAll();
    }

    public override void Execute()
    {
        m_PlayerBehavior.CurrentMiniGame.Execute();
        //m_AttachedBehavior.ChangeState(EPlayerState.Run);

        if (Input.GetKeyDown(KeyCode.E))
        {
            m_PlayerBehavior.CurrentMiniGame.EndMinigame();
            // TODO: add corroutine pour faire l'animation de "get bread"
            m_PlayerBehavior.ChangeState(EPlayerState.Run);
        }
    }

    public override void Exit()
    {
        Debug.Log("EXIT Mini Game Memory");
        UnsubscribeAll();
    }

    private void SubscribeAll()
    {
        GameEventSystem.Instance.SubscribeTo(EGameEvent.MiniGameEnd, OnMiniGameEnd);
    }

    private void UnsubscribeAll()
    {
        GameEventSystem.Instance.UnsubscribeFrom(EGameEvent.MiniGameEnd, OnMiniGameEnd);
    }

    private void OnMiniGameEnd(GameEventMessage message)
    {
        if (message.Contains<Item>(EGameEventMessage.Item, out Item item))
        {
            m_PlayerBehavior.AddItem(item);
        }

        m_PlayerBehavior.ChangeState(EPlayerState.Run);
    }
}
