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
        m_Animator.SetTrigger(GameParameters.AnimationPlayer.TRIGGER_LOSE);
    }
    public void Win()
    {
        m_Animator.SetTrigger(GameParameters.AnimationPlayer.TRIGGER_WIN);
    }


    public void UpdateVelocity(Vector3 velocity)
    {
        m_Animator.SetFloat(GameParameters.AnimationPlayer.FLOAT_VELOCITY, velocity.magnitude);
    }
}
