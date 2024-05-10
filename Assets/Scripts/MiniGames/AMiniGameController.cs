using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMiniGameController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera m_Camera;
    [SerializeField] private Transform m_PlayerSpot;

    public Transform PlayerSpot { get => m_PlayerSpot; }

    protected Item m_Item;
    protected bool m_IsWin;
    private ICinemachineCamera m_CameraOld;

    private void Start()
    {
        m_IsWin = true;
        AfterStart();
    }

    protected virtual void AfterStart() {}

    private CinemachineBrain GetCinemachineBrain()
    {
        return CinemachineCore.Instance.GetActiveBrain(0);
    }

    public virtual void StartMinigame()
    {
        ChangeCamera();
    }

    public virtual void Execute()
    {
    }

    protected virtual void EndMinigame()
    {
        ResetCamera();

        GameEventMessage eventMessage = new GameEventMessage();

        // Se tu as perdu, il ne faut que ne pas envoyer l'item
        if (m_IsWin) 
        { 
            eventMessage.Add(EGameEventMessage.Item, m_Item);
            GetComponentInParent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            Destroy(GetComponent<BoxCollider>()); // Enlever le minigame du jeu
            Destroy(GetComponentInChildren<ParticleSystem>());
        } else
        {
            GameEventSystem.Instance.TriggerEvent(EGameEvent.ToggleTips, new GameEventMessage(EGameEventMessage.Toggle, true));
        }

        GameEventSystem.Instance.TriggerEvent(EGameEvent.MiniGameEnd, eventMessage);
    }

    protected void SetupCamera(Vector3 offset, float rotation)
    {
        //m_OffsetCamera
        m_Camera.GetComponent<CinemachineCameraOffset>().m_Offset = offset;
        Vector3 rotationEuler = m_Camera.transform.localEulerAngles;
        rotationEuler.y = rotation;
        m_Camera.transform.localEulerAngles = rotationEuler;
    }

    private void ChangeCamera()
    {
        m_CameraOld = GetCinemachineBrain().ActiveVirtualCamera;
        m_CameraOld.Priority = 0;
        m_Camera.Follow = transform;
        m_Camera.Priority = 1;
    }

    private void ResetCamera()
    {
        m_CameraOld.Priority = 1;
        m_Camera.Priority = 0;
    }
}
