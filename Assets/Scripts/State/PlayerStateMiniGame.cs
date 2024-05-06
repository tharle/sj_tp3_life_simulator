using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerStateMiniGame : APlayerState
{
    public PlayerStateMiniGame(PlayerBehaviorManager attachedBehavior) : base(attachedBehavior, EPlayerState.MiniGame)
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
