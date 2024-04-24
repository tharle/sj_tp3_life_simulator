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
        Debug.Log("ENTER PauseMenu");
    }

    public override void Execute()
    {
        Debug.Log("IS PauseMenu");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_AttachedBehavior.ChangeState(EPlayerState.PauseMenu);
        }
    }

    public override void Exit()
    {
        Debug.Log("EXIT PauseMenu");
    }
}
