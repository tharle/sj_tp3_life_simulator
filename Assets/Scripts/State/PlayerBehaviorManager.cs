using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerBehaviorManager : MonoBehaviour
{
    private APlayerState m_CurrentState;
    private Dictionary<EPlayerState, APlayerState> m_States;
    
    private List<Item> m_Inventory;
    private int m_InventorySlotMax = 5;

    [SerializeField] EPlayerState m_CurrentStateId;

    
    void Start()
    {
        m_Inventory = new List<Item>();

        m_States = new Dictionary<EPlayerState, APlayerState>();
        m_States.Add(EPlayerState.Win, new PlayerStateWin(this));
        m_States.Add(EPlayerState.PauseMenu, new PlayerStatePauseMenu(this));
        m_States.Add(EPlayerState.Run, new PlayerStateRun(this));
        m_States.Add(EPlayerState.MiniGameMemory, new PlayerStateMiniGameMemory(this));
        m_States.Add(EPlayerState.MiniGameMeat, new PlayerStateMiniGameMeat(this));

        m_CurrentStateId = EPlayerState.Run;
        m_CurrentState = m_States[m_CurrentStateId];
    }

    private void Update()
    {
        m_CurrentState.Execute();
    }

    private void OnTriggerEnter(Collider other)
    {
        m_CurrentState.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        m_CurrentState.OnTriggerExit(other);
    }

    public void ChangeState(EPlayerState stateId)
    {
        m_CurrentState.Exit();
        m_CurrentState = m_States[stateId];
        m_CurrentState.Enter();
    }

    public bool IsInventoryFull()
    {
        return m_Inventory.Count >= m_InventorySlotMax;
    }

    public void AddItem(Item item)
    {
        if (IsInventoryFull()) return;

        m_Inventory.Add(item);
        GameEventSystem.Instance.TriggerEvent(EGameEvent.InventoryChanged, new GameEventMessage(EGameEventMessage.ItemList, m_Inventory));
    }
}
