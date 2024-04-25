using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EMiniGame
{
    Bread,
    Ham
}

public abstract class AMiniGameController : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject m_ItemData;
    [SerializeField] private CinemachineVirtualCamera m_Camera;
    private ICinemachineCamera m_CameraOld;

    private EMiniGame m_Minigame;

    public EMiniGame MiniGameId { get => m_Minigame; }
    public ItemScriptableObject ItemData { get => m_ItemData; }

    public AMiniGameController(EMiniGame miniGameId)
    {
        m_Minigame = miniGameId;
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
        eventMessage.Add(EGameEventMessage.Item, ItemData.Item);

        GameEventSystem.Instance.TriggerEvent(EGameEvent.MiniGameEnd, eventMessage);
    }

    public virtual void Execute()
    {
        ChangeCamera();
    }
}
