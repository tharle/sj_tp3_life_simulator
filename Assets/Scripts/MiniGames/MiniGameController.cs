using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject m_ItemData;

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameEventMessage eventMessage = new GameEventMessage();
            eventMessage.Add(EGameEventMessage.Item, m_ItemData.Item);

            GameEventSystem.Instance.TriggerEvent(EGameEvent.MiniGameEnd, eventMessage);
        }
    }
}
