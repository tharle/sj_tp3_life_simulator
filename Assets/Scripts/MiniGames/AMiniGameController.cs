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
    private EMiniGame m_Minigame;

    public EMiniGame MiniGameId { get => m_Minigame; }
    public ItemScriptableObject ItemData { get => m_ItemData; }

    public AMiniGameController(EMiniGame miniGameId)
    {
        m_Minigame = miniGameId;
    }

    public abstract void Execute();
}
