using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMiniGameMeat : AGameState
{
    MiniGameMeatController m_Controller;
    public GameStateMiniGameMeat(GameStateManager attachedBehavior) : base(attachedBehavior, EGameState.MiniGameMeat)
    {
        m_Controller = MiniGameMeatController.Instance;
    }

    public override void Enter()
    {
        Debug.Log("ENTER Mini Game MEAT");
    }

    public override void Execute()
    {
        m_Controller.Execute();
        m_AttachedBehavior.ChangeState(EGameState.Run);
    }

    public override void Exit()
    {
        Debug.Log("EXIT Mini Game MEAT");
    }
}
