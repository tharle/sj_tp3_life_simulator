using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;


public class GameStateManager : MonoBehaviour
{
    private AGameState m_CurrentState;
    private Dictionary<EGameState, AGameState> m_States;

    [SerializeField] EGameState m_CurrentStateId;

    
    void Start()
    {
        m_States = new Dictionary<EGameState, AGameState>();
        m_States.Add(EGameState.Win, new GameStateWin(this));
        m_States.Add(EGameState.PauseMenu, new GameStatePauseMenu(this));
        m_States.Add(EGameState.Run, new GameStateRun(this));

        m_CurrentStateId = EGameState.Run;
        m_CurrentState = m_States[m_CurrentStateId];
    }

    private void Update()
    {
        m_CurrentState.Execute();
    }

    public void ChangeState(EGameState stateId)
    {
        m_CurrentState.Exit();
        m_CurrentState = m_States[stateId];
        m_CurrentState.Enter();
    }

}
