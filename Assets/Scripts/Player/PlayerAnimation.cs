using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator m_Animator;

    private static PlayerAnimation m_Instance;

    public static PlayerAnimation Instance { 
        get
        {
            return m_Instance;
        }
    }

    private void Awake()
    {
        if(m_Instance != null) Destroy(gameObject);

        m_Instance = this;
    }

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void Idle() 
    {
        m_Animator.SetTrigger(GameParameters.AnimationPlayer.TRIGGER_IDLE);
    }

    public void Interract() 
    {
        m_Animator.SetTrigger(GameParameters.AnimationPlayer.TRIGGER_INTERACT);
    }

    public void Fishing()
    {
        m_Animator.SetTrigger(GameParameters.AnimationPlayer.TRIGGER_FISHING);
    }

    public void Lose()
    {
        AudioManager.Instance.Play(EAudio.SFXMiniGameLose, transform.position);
        m_Animator.SetTrigger(GameParameters.AnimationPlayer.TRIGGER_LOSE);
    }
    public void Win()
    {
        AudioManager.Instance.Play(EAudio.SFXMiniGameWin, transform.position);
        m_Animator.SetTrigger(GameParameters.AnimationPlayer.TRIGGER_WIN);
    }

    // pour l'animation de marcher
    public void PlayWalkSound()
    {
        AudioManager.Instance.Play(EAudio.SFXWalkDirty, transform.position, true, 0.5f);
    }

    public void StopWalkSound()
    {
        AudioManager.Instance.StopAllLooping();
    }
}
