using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateRun : AGameState
{
    PlayerController m_Controller;

    public GameStateRun(GameStateManager attachedBehavior) : base(attachedBehavior, EGameState.Run)
    {

        m_Controller = PlayerController.Instance;
    }

    public override void Enter()
    {
        Debug.Log("ENTER GAME");
    }

    public override void Execute()
    {
        Debug.Log("IS GAME");
        if (Input.GetKeyDown(GameParameters.InputName.GAME_MENU))
        {
            m_AttachedBehavior.ChangeState(EGameState.PauseMenu);
            return;
        }

        m_Controller.Execute();
    }

    public override void Exit()
    {
        Debug.Log("EXIT DOWN");
    }
}
