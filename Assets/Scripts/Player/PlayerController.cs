using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    PlayerMoveController m_PlayerMoveController;

    private bool m_IsPlaying = true;
    public bool IsPlaying { get { return m_IsPlaying; } }


    private static PlayerController m_Instance;
    public static PlayerController Instance { get { return m_Instance; } }

    private void Awake()
    {
        if (m_Instance != null && m_Instance != this)
            Destroy(gameObject);

        m_Instance = this;
    }

    private void Start()
    {
        m_PlayerMoveController = GetComponent<PlayerMoveController>();
    }

    public void Execute()
    {
        m_PlayerMoveController.Execute();
    }
}
