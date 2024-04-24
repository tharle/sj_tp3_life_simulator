using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateWin : APlayerState
{
    public PlayerStateWin(PlayerBehaviorManager attachedBehavior) : base(attachedBehavior, EPlayerState.Win)
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
            m_AttachedBehavior.ChangeState(EPlayerState.MiniGameBread);
        }
    }

    public override void Exit()
    {
        Debug.Log("EXIT WIN");
    }
}
