using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMoveController m_PlayerMoveController;


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
