using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EPlayerState
{
    PauseMenu,
    Run,
    MiniGameBread,
    MiniGameMeat,
    Win
}
public abstract class APlayerState
{
    protected PlayerBehaviorManager m_AttachedBehavior;
    private EPlayerState m_StateId;
    public EPlayerState StateId { get => m_StateId; }

    public APlayerState(PlayerBehaviorManager attachedBehavior, EPlayerState stateId)
    {
        m_AttachedBehavior = attachedBehavior;
        m_StateId = stateId;
    }

    public virtual void OnTriggerEnter(Collider other){ }

    public virtual void OnTriggerExit(Collider other){ }

    public virtual void Enter() { }

    public abstract void Execute();

    public virtual void Exit() { }


}
