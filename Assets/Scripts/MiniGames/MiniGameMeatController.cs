using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameMeatController : AMiniGameController
{

    private static MiniGameMeatController m_Instance;
    public static MiniGameMeatController Instance { get { return m_Instance; } }


    public MiniGameMeatController() : base(EMiniGame.Ham)
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
