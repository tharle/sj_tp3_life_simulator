using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatePauseMenu : AGameState
{
    public GameStatePauseMenu(GameStateManager attachedBehavior) : base(attachedBehavior, EGameState.PauseMenu)
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
            m_AttachedBehavior.ChangeState(EGameState.PauseMenu);
        }
    }

    public override void Exit()
    {
        Debug.Log("EXIT PauseMenu");
    }
}
