using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float m_Speed = 5.0f;
    [SerializeField] private Transform m_CameraTransform;

    private Animator m_Animator;
    private Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponentInChildren<Animator>();
    }

    public void Execute()
    {
        Move();
    }

    private void Move()
    {
        // obtient les valeurs des touches horizontales et verticales
        float hDeplacement = Input.GetAxis(GameParameters.InputName.AXIS_HORIZONTAL);
        float vDeplacement = Input.GetAxis(GameParameters.InputName.AXIS_VERTICAL);

        //obtient la nouvelle direction ( (avant/arrièrre) + (gauche/droite) )
        Vector3 directionDep = GetCameraTransform().forward * vDeplacement + GetCameraTransform().right * hDeplacement;
        directionDep.y = 0; //pas de valeur en y , le cas où la caméra regarde vers le bas ou vers le haut
        Vector3 velocity = Vector3.zero;
        if (directionDep != Vector3.zero) //change de direction s’il y a un changement
        {
            //Oriente le personnage vers la direction de déplacement et applique la vélocité dans la même direction
            transform.forward = directionDep;
            
            velocity = directionDep * m_Speed;
        }
        m_Animator.SetFloat(GameParameters.AnimationPlayer.FLOAT_VELOCITY, velocity.magnitude);
        velocity.y = m_Rigidbody.velocity.y;
        m_Rigidbody.velocity = velocity;
    }

    private Transform GetCameraTransform()
    {
        // return m_CinemachineBrain.transform;
        return m_CameraTransform;
    }
}
