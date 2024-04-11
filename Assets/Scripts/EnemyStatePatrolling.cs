using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatePatrolling : AEnemyState
{
    public EnemyStatePatrolling(EnemyBehavior attachedBehavior) : base(attachedBehavior)
    {
    }

    public override void Enter()
    {
        Debug.Log("ENTER PATROLLING");
    }

    public override void Execute()
    {
        Debug.Log("IS PATROLLING");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_AttachedBehavior.ChangeState(EEnemyState.Down);
        }
    }

    public override void Exit()
    {
        Debug.Log("EXIT PATROLLING");
    }

    public override EEnemyState GetEnemyStateId()
    {
        return EEnemyState.Patrol;
    }
}
