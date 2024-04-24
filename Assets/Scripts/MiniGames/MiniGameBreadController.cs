using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameBreadController : AMiniGameController
{

    private static MiniGameBreadController m_Instance;
    public static MiniGameBreadController Instance { get { return m_Instance; } }

    public MiniGameBreadController() : base(EMiniGame.Bread)
    {
    }

    private void Awake()
    {
        if (m_Instance != null)
            Destroy(gameObject);

        m_Instance = this;
    }

    public override void Execute()
    {
        GameEventMessage eventMessage = new GameEventMessage();
        eventMessage.Add(EGameEventMessage.Item, ItemData.Item);

        GameEventSystem.Instance.TriggerEvent(EGameEvent.MiniGameEnd, eventMessage);
    }
}
