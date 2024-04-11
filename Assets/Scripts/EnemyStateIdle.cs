using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateIdle : AEnemyState
{
    public EnemyStateIdle(EnemyBehavior attachedBehavior) : base(attachedBehavior)
    {
    }

    public override void Enter()
    {
        Debug.Log("ENTER IDLE");
    }

    public override void Execute()
    {
        Debug.Log("IS IDLE");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_AttachedBehavior.ChangeState(EEnemyState.Patrol);
        }
    }

    public override void Exit()
    {
        Debug.Log("EXIT IDLE");
    }

    public override EEnemyState GetEnemyStateId()
    {
        return EEnemyState.Idle;
    }
}
