using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateRun : APlayerState
{
    private PlayerMoveController m_PlayerMoveController;
    private AMiniGameController m_MiniGameController;

    public PlayerStateRun(PlayerBehaviorManager attachedBehavior) : base(attachedBehavior, EPlayerState.Run)
    {
        m_PlayerMoveController = attachedBehavior.GetComponent<PlayerMoveController>();
        m_MiniGameController = null;
    }

    public override void Execute()
    {
        Debug.Log("IS GAME");
        if (Input.GetKeyDown(GameParameters.InputName.GAME_MENU))
        {
            m_PlayerBehavior.ChangeState(EPlayerState.PauseMenu);
            return;
        }

        if (Input.GetKey(KeyCode.Space) && m_MiniGameController != null)
        {
            PlayMiniGame(m_MiniGameController);
        }

        m_PlayerMoveController.Execute();
    }

    public override void OnTriggerEnter(Collider other)
    {
        AMiniGameController miniGameController = other.GetComponent<AMiniGameController>();

        if (miniGameController != null)
        {
            m_MiniGameController = miniGameController;
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        AMiniGameController miniGameController = other.GetComponent<AMiniGameController>();

        if (miniGameController != null)
        {
            m_MiniGameController = null;
        }
    }

    private void PlayMiniGame(AMiniGameController controller)
    {
        if (controller is MiniGameMemoryController) m_PlayerBehavior.ChangeState(EPlayerState.MiniGameMemory);
        if (controller is MiniGameMeatController) m_PlayerBehavior.ChangeState(EPlayerState.MiniGameMeat);
    }
}
