using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{
    private Animator m_Animator;
    [SerializeField] private GameObject m_GameMenuPanel;
    [SerializeField] private Button m_EndGameButton;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        GameEventSystem.Instance.SubscribeTo(EGameEvent.GameMenuToggle, OnToggle);
    }

    private void OnToggle(GameEventMessage message)
    {
        if (message.Contains<bool>(EGameEventMessage.Toggle, out bool show)) m_GameMenuPanel.SetActive(show);

        if (message.Contains<bool>(EGameEventMessage.IsInventoryFull, out bool isInventoryFull)) m_EndGameButton.interactable = isInventoryFull;
    }

    public void OnClickGameEnd()
    {
        GameEventSystem.Instance.TriggerEvent(EGameEvent.GameMenuEndGame, new GameEventMessage());
    }

    public void OnClickLoadGame()
    {
        GameEventSystem.Instance.TriggerEvent(EGameEvent.LoadGame, new GameEventMessage(EGameEventMessage.Enter, true));
    }
}
