using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EPlayerState
{
    PauseMenu,
    Run,
    MiniGame,
    Win
}
public abstract class APlayerState
{
    protected PlayerBehaviorManager m_PlayerBehavior;
    private EPlayerState m_StateId;
    public EPlayerState StateId { get => m_StateId; }

    public APlayerState(PlayerBehaviorManager attachedBehavior, EPlayerState stateId)
    {
        m_PlayerBehavior = attachedBehavior;
        m_StateId = stateId;
    }

    public virtual void OnTriggerEnter(Collider other){ }

    public virtual void OnTriggerExit(Collider other){ }

    public virtual void Enter() { }

    public abstract void Execute();

    public virtual void Exit() { }


}
