using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EEnemyState
{
    Idle,
    Patrol,
    Down
}
public abstract class AEnemyState
{
    protected EnemyBehavior m_AttachedBehavior;

    public AEnemyState(EnemyBehavior attachedBehavior)
    {
        m_AttachedBehavior = attachedBehavior;
    }
    public abstract EEnemyState GetEnemyStateId();

    public abstract void Enter();

    public abstract void Execute();

    public abstract void Exit();


}
