using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EEventMessage
{
    Enter,
    Exit
}

public class EventMessage
{
    private Dictionary<EEventMessage, object> m_Params;

    public void Add(EEventMessage eventMessageId, object value)
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

    public object Get(EEventMessage eventMessageId)
    {
        return m_Params.ContainsKey(eventMessageId) ? m_Params[eventMessageId] : false;
    }
}
