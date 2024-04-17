using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EEventType
{
    PauseMenu,
    Run,
    MiniGame1,
    MiniGame2,
    Won
}

public class EventSystem
{
    private Dictionary<EEventType, Action<Dictionary<string, object>>> m_Events;

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
        m_Events = new Dictionary<EEventType, Action<Dictionary<string, object>>>();
    }

    public void SubscribeTo(EEventType eventTypeId, Action<Dictionary<string, object>> action)
    {
        if (m_Events.ContainsKey(eventTypeId)) m_Events.Add(eventTypeId, action);
        else m_Events[eventTypeId] += action;
    }

    public void UnsubscribeFrom(EEventType eventTypeId, Action<Dictionary<string, object>> action)
    {
        if (!m_Events.ContainsKey(eventTypeId)) return;

        m_Events[eventTypeId] -= action;

        if (m_Events[eventTypeId] == null) m_Events.Remove(eventTypeId);
    }

    public void TriggerEvent(EEventType eventTypeId, Dictionary<string, object> parameters)
    {
        m_Events[eventTypeId]?.Invoke(parameters);
    }
}
