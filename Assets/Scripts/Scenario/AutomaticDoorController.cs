using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoorController : MonoBehaviour
{
    private Animator m_Animator;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameParameters.TagName.PLAYER))
        {
            AudioManager.Instance.Play(EAudio.SFXEnterWellcome, transform.position, false, 0.1f);
            m_Animator.SetTrigger(GameParameters.AnimationScenario.TRIGGER_AUTOMATIC_DOOR_OPEN);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameParameters.TagName.PLAYER))
        {
            m_Animator.SetTrigger(GameParameters.AnimationScenario.TRIGGER_AUTOMATIC_DOOR_CLOSE);
        }
    }
}
