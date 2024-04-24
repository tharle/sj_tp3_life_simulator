using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMiniGameBread : APlayerState
{
    MiniGameBreadController m_Controller;
    public PlayerStateMiniGameBread(PlayerBehaviorManager attachedBehavior) : base(attachedBehavior, EPlayerState.MiniGameBread)
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
        m_AttachedBehavior.ChangeState(EPlayerState.Run);
    }

    public override void Exit()
    {
        Debug.Log("EXIT Mini Game Bread");
    }
}
