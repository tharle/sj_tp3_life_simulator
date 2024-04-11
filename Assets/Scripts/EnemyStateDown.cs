using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateDown : AEnemyState
{
    public EnemyStateDown(EnemyBehavior attachedBehavior) : base(attachedBehavior)
    {
    }

    public override void Enter()
    {
        Debug.Log("ENTER DOWN");
    }

    public override void Execute()
    {
        Debug.Log("IS DOWN");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_AttachedBehavior.ChangeState(EEnemyState.Idle);
        }
    }

    public override void Exit()
    {
        Debug.Log("EXIT DOWN");
    }

    public override EEnemyState GetEnemyStateId()
    {
        return EEnemyState.Down;
    }
}
