using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMiniGameMeat : APlayerState
{
    MiniGameMeatController m_Controller;
    public PlayerStateMiniGameMeat(PlayerBehaviorManager attachedBehavior) : base(attachedBehavior, EPlayerState.MiniGameMeat)
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
        m_PlayerBehavior.ChangeState(EPlayerState.Run);
    }

    public override void Exit()
    {
        Debug.Log("EXIT Mini Game MEAT");
    }
}
