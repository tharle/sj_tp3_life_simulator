using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum EEventType
{
    GameStatePauseMenu,
    GameStateRun,
    GameStateMiniGame1,
    GameStateMiniGame2,
    GameStateWon
}

public class EventSystem
{
    private Dictionary<EEventType, Action<EventMessage>> m_Events;

    #region Singleton
    private static EventSystem m_Instance;

    public static EventSystem Instance { 
        get 
        { 
            if (m_Instance == null)
            {
                m_Instance = new EventSystem();
            }

            return m_Instance;
        } 
    }
    #endregion

    private EventSystem()
    {
        m_Events = new Dictionary<EEventType, Action<EventMessage>>();
    }

    public void SubscribeTo(EEventType eventTypeId, Action<EventMessage> action)
    {
        if (m_Events.ContainsKey(eventTypeId)) m_Events.Add(eventTypeId, action);
        else m_Events[eventTypeId] += action;
    }

    public void UnsubscribeFrom(EEventType eventTypeId, Action<EventMessage> action)
    {
        if (!m_Events.ContainsKey(eventTypeId)) return;

        m_Events[eventTypeId] -= action;

        if (m_Events[eventTypeId] == null) m_Events.Remove(eventTypeId);
    }

    public void TriggerEvent(EEventType eventTypeId, EventMessage parameters)
    {
        m_Events[eventTypeId]?.Invoke(parameters);
    }
}
