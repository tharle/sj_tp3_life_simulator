using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatePauseMenu : APlayerState
{
    public PlayerStatePauseMenu(PlayerBehaviorManager attachedBehavior) : base(attachedBehavior, EPlayerState.PauseMenu)
    {
    }

    public override void Enter()
    {
        GameEventMessage message = new GameEventMessage(EGameEventMessage.Toggle, true);
        message.Add(EGameEventMessage.IsInventoryFull, m_PlayerBehavior.IsInventoryFull());
        GameEventSystem.Instance.TriggerEvent(EGameEvent.GameMenuToggle, message);
        Time.timeScale = 0f;
        SubscribeAll();
    }

    private void SubscribeAll()
    {
        GameEventSystem.Instance.SubscribeTo(EGameEvent.GameMenuEndGame, OnGameMenuEndGame);
        GameEventSystem.Instance.SubscribeTo(EGameEvent.LoadGame, OnLoadGame);
    }

    public override void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_PlayerBehavior.ChangeState(EPlayerState.Run);
        }
    }

    public override void Exit()
    {
        Time.timeScale = 1f;
        GameEventSystem.Instance.TriggerEvent(EGameEvent.GameMenuToggle, new GameEventMessage(EGameEventMessage.Toggle, false));
        UnsubscribeAll();
    }

    private void UnsubscribeAll()
    {
        GameEventSystem.Instance.UnsubscribeFrom(EGameEvent.GameMenuEndGame, OnGameMenuEndGame);
        GameEventSystem.Instance.UnsubscribeFrom(EGameEvent.LoadGame, OnLoadGame);
    }

    private void OnGameMenuEndGame(GameEventMessage message)
    {
        // Ignorer le message, elle est vide
        m_PlayerBehavior.ChangeState(EPlayerState.Win);
    }

    private void OnLoadGame(GameEventMessage message)
    {
        if(message.Contains<bool>(EGameEventMessage.Enter, out bool enter) && enter)
        {
            m_PlayerBehavior.LoadGame();
            m_PlayerBehavior.ChangeState(EPlayerState.Run);
        }
    }
}
