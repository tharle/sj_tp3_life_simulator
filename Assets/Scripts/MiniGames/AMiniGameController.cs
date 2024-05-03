using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMiniGameController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera m_Camera;
    [SerializeField] private EItem m_ItemId;

    protected Item m_Item;
    protected bool m_IsWin;
    private ICinemachineCamera m_CameraOld;

    private void Start()
    {
        m_IsWin = true;
        LoadItem(m_ItemId);
        AfterStart();
    }

    protected virtual void AfterStart() {}

    private void LoadItem(EItem itemId)
    {
        m_Item = ItemLoader.Instance.Get(itemId);
    }

    private CinemachineBrain GetCinemachineBrain()
    {
        return CinemachineCore.Instance.GetActiveBrain(0);
    }

    private void ChangeCamera() 
    {
        m_CameraOld = GetCinemachineBrain().ActiveVirtualCamera;
        m_CameraOld.Priority = 0;
        m_Camera.Priority = 1;
    }

    private void ResetCamera()
    {
        m_CameraOld.Priority = 1;
        m_Camera.Priority = 0;
    }

    public virtual void EndMinigame()
    {
        ResetCamera();

        GameEventMessage eventMessage = new GameEventMessage();

        // Se tu as perdu, il ne faut que ne pas envoyer l'item
        if (m_IsWin) eventMessage.Add(EGameEventMessage.Item, m_Item);

        GameEventSystem.Instance.TriggerEvent(EGameEvent.MiniGameEnd, eventMessage);
    }

    public virtual void StartMinigame()
    {
        ChangeCamera();
    }

    public virtual void Execute()
    {
    }
}
