using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMiniGameBread : AGameState
{
    MiniGameBreadController m_Controller;
    public GameStateMiniGameBread(GameStateManager attachedBehavior) : base(attachedBehavior, EGameState.MiniGameBread)
    {
        m_Controller = MiniGameBreadController.Instance;
    }

    public override void Enter()
    {
        Debug.Log("ENTER Mini Game Bread");
    }

    public override void Execute()
    {
        m_Controller.Execute();
        m_AttachedBehavior.ChangeState(EGameState.Run);
    }

    public override void Exit()
    {
        Debug.Log("EXIT Mini Game Bread");
    }
}
