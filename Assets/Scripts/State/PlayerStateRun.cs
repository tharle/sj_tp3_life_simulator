using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateRun : APlayerState
{
    Color m_EmissionColor = new Color(0, 1, 1, 0.1f);
    private PlayerMoveController m_PlayerMoveController;

    public PlayerStateRun(PlayerBehaviorManager attachedBehavior) : base(attachedBehavior, EPlayerState.Run)
    {
        m_PlayerMoveController = attachedBehavior.GetComponent<PlayerMoveController>();
    }

    public override void Enter()
    {
        base.Enter();
        PlayerAnimation.Instance.Idle();
    }

    public override void Execute()
    {
        if (Input.GetKeyDown(GameParameters.InputName.GAME_MENU))
        {
            m_PlayerBehavior.ChangeState(EPlayerState.PauseMenu);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && m_PlayerBehavior.CurrentMiniGame != null)
        {
            PlayerAnimation.Instance.Interract();
            PlayMiniGame();
            return;
        }

        m_PlayerMoveController.Execute();
    }

    public override void OnTriggerEnter(Collider other)
    {
        AMiniGameController miniGameController = other.GetComponent<AMiniGameController>();

        if (miniGameController != null)
        {
            Material emission = miniGameController.gameObject.GetComponentInParent<MeshRenderer>().material;
            emission.SetColor("_EmissionColor", m_EmissionColor);
            emission.EnableKeyword("_EMISSION");

            m_PlayerBehavior.CurrentMiniGame = miniGameController;
            GameEventSystem.Instance.TriggerEvent(EGameEvent.ToggleTips, new GameEventMessage(EGameEventMessage.Toggle, true));
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        AMiniGameController miniGameController = other.GetComponent<AMiniGameController>();

        if (miniGameController != null && m_PlayerBehavior.CurrentMiniGame != null)
        {
            m_PlayerBehavior.CurrentMiniGame.gameObject.GetComponentInParent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            m_PlayerBehavior.CurrentMiniGame = null;
            GameEventSystem.Instance.TriggerEvent(EGameEvent.ToggleTips, new GameEventMessage(EGameEventMessage.Toggle, false));
        }
    }

    private void PlayMiniGame()
    {
        m_PlayerBehavior.CurrentMiniGame.gameObject.GetComponentInParent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        GameEventSystem.Instance.TriggerEvent(EGameEvent.ToggleTips, new GameEventMessage(EGameEventMessage.Toggle, false));
        m_PlayerBehavior.ChangeState(EPlayerState.MiniGame);
    }
}
