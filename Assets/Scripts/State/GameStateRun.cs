using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateRun : AGameState
{
    public GameStateRun(GameStateManager attachedBehavior) : base(attachedBehavior, EGameState.Run)
    {
    }

    public override void Enter()
    {
        Debug.Log("ENTER GAME");
    }

    public override void Execute()
    {
        Debug.Log("IS GAME");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_AttachedBehavior.ChangeState(EGameState.PauseMenu);
        }
    }

    public override void Exit()
    {
        Debug.Log("EXIT DOWN");
    }
}
