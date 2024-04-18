using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameEventMessage
{
    Enter,
    Exit,
    Item,
    Inventory
}

public class GameEventMessage
{
    private Dictionary<EGameEventMessage, object> m_Params;

    public GameEventMessage()
    {
        m_Params = new Dictionary<EGameEventMessage, object>();
    }

    public GameEventMessage(EGameEventMessage messageId, object value) : this()
    {
        Add(messageId, value);
    }


    public void Add(EGameEventMessage eventMessageId, object value)
    {
        if (m_Params.ContainsKey(eventMessageId))
        {
            m_Params[eventMessageId] = value;
        }
        else
        {
            m_Params.Add(eventMessageId, value);
        }
    }

    public object Get(EGameEventMessage eventMessageId)
    {
        return m_Params.ContainsKey(eventMessageId) ? m_Params[eventMessageId] : false;
    }
}
