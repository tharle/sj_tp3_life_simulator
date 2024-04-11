using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EGameState
{
    PauseMenu,
    Run,
    MemoryGame,
    ReflexGame,
    Win
}
public abstract class AGameState
{
    protected GameStateManager m_AttachedBehavior;
    private EGameState m_StateId;
    public EGameState StateId { get => m_StateId; }

    public AGameState(GameStateManager attachedBehavior, EGameState stateId)
    {
        m_AttachedBehavior = attachedBehavior;
        m_StateId = stateId;
    }

    public abstract void Enter();

    public abstract void Execute();

    public abstract void Exit();


}
