using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    
    private Animator m_Animator;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        m_Animator.SetTrigger(GameParameters.AnimationEnemy.TRIGGER_ATTACK);
    }

    public void Die()
    {
        m_Animator.SetTrigger(GameParameters.AnimationEnemy.TRIGGER_DIE);
    }

    public void UpdateVelocity(Vector3 velocity)
    {
        m_Animator.SetFloat(GameParameters.AnimationEnemy.FLOAT_VELOCITY, velocity.magnitude);
    }
}
