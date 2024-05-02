using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum EGameEvent
{
    MiniGameEnd,
    MiniGameMemoryItemSelect,
    InventoryChanged
}

public class GameEventSystem
{
    private Dictionary<EGameEvent, Action<GameEventMessage>> m_Events;

    #region Singleton
    private static GameEventSystem m_Instance;

    public static GameEventSystem Instance { 
        get 
        { 
            if (m_Instance == null)
            {
                m_Instance = new GameEventSystem();
            }

            return m_Instance;
        } 
    }
    #endregion

    private GameEventSystem()
    {
        m_Events = new Dictionary<EGameEvent, Action<GameEventMessage>>();
    }

    public void SubscribeTo(EGameEvent eventId, Action<GameEventMessage> action)
    {
        if (!m_Events.ContainsKey(eventId)) m_Events.Add(eventId, action);
        else m_Events[eventId] += action;
    }

    public void UnsubscribeFrom(EGameEvent eventId, Action<GameEventMessage> action)
    {
        if (!m_Events.ContainsKey(eventId)) return;

        m_Events[eventId] -= action;

        if (m_Events[eventId] == null) m_Events.Remove(eventId);
    }

    public void TriggerEvent(EGameEvent eventId, GameEventMessage parameters)
    {
        if (!m_Events.ContainsKey(eventId)) 
        {
            Debug.Log($"Impossible trigger Event {eventId}.");
            return;
        }

        m_Events[eventId]?.Invoke(parameters);
    }
}
