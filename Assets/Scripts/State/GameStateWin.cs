using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateWin : AGameState
{
    public GameStateWin(GameStateManager attachedBehavior) : base(attachedBehavior, EGameState.Win)
    {
    }

    public override void Enter()
    {
        Debug.Log("ENTER WIN");
    }

    public override void Execute()
    {
        Debug.Log("IS WIN");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_AttachedBehavior.ChangeState(EGameState.MemoryGame);
        }
    }

    public override void Exit()
    {
        Debug.Log("EXIT WIN");
    }
}
