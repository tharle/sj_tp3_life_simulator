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
        Debug.Log("ENTER Mini Game");
        
        if (m_PlayerBehavior.CurrentMiniGame.PlayerSpot != null)
        {
            m_PlayerBehavior.transform.forward = m_PlayerBehavior.CurrentMiniGame.PlayerSpot.forward;
            m_PlayerBehavior.transform.position = m_PlayerBehavior.CurrentMiniGame.PlayerSpot.position;
        }

        m_PlayerBehavior.CurrentMiniGame.StartMinigame();
        SubscribeAll();
    }

    public override void Execute()
    {
        m_PlayerBehavior.CurrentMiniGame.Execute();
    }

    public override void Exit()
    {
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
            PlayerAnimation.Instance.Win();
            m_PlayerBehavior.AddItem(item);
        } else
        {
            PlayerAnimation.Instance.Lose();
        }

        m_PlayerBehavior.ChangeState(EPlayerState.Run);
    }
}
