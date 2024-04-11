using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;


public class EnemyBehavior : MonoBehaviour
{
    private AEnemyState m_CurrentState;
    private Dictionary<EEnemyState, AEnemyState> m_States;

    [SerializeField] EEnemyState m_CurrentStateId;

    
    void Start()
    {
        m_States = new Dictionary<EEnemyState, AEnemyState>();
        m_States.Add(EEnemyState.Idle, new EnemyStateIdle(this));
        m_States.Add(EEnemyState.Patrol, new EnemyStatePatrolling(this));
        m_States.Add(EEnemyState.Down, new EnemyStateDown(this));

        m_CurrentStateId = EEnemyState.Idle;
        m_CurrentState = m_States[m_CurrentStateId];
    }

    private void Update()
    {
        m_CurrentState.Execute();
    }

    public void ChangeState(EEnemyState stateId)
    {
        m_CurrentState.Exit();
        m_CurrentState = m_States[stateId];
        m_CurrentState.Enter();
    }

}
