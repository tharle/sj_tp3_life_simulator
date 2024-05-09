using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerBehaviorManager : MonoBehaviour
{
    [SerializeField] private EPlayerState m_CurrentStateId;

    private Vector3 m_PositionInitial;
    private Vector3 m_FowardInitial;

    private APlayerState m_CurrentState;
    private Dictionary<EPlayerState, APlayerState> m_States;

    private List<Item> m_Inventory;
    public List<Item> Inventory { get { return m_Inventory; } }
    private int m_InventorySlotMax = 5;

    private AMiniGameController m_CurrentMiniGame;
    public AMiniGameController CurrentMiniGame { get => m_CurrentMiniGame; set => m_CurrentMiniGame = value; }

    private void Awake()
    {
        m_PositionInitial = transform.position;
        m_FowardInitial = transform.forward;
    }
    void Start()
    {
        m_Inventory = new List<Item>();

        m_States = new Dictionary<EPlayerState, APlayerState>();
        m_States.Add(EPlayerState.Win, new PlayerStateWin(this));
        m_States.Add(EPlayerState.PauseMenu, new PlayerStatePauseMenu(this));
        m_States.Add(EPlayerState.Run, new PlayerStateRun(this));
        m_States.Add(EPlayerState.MiniGame, new PlayerStateMiniGame(this));

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
        m_CurrentStateId = stateId;
        m_CurrentState = m_States[stateId];
        m_CurrentState.Enter();
    }

    public bool IsInventoryFull()
    {
        return m_Inventory.Count >= m_InventorySlotMax;
    }

    public void AddItem(Item item)
    {
        m_CurrentMiniGame = null;

        if (IsInventoryFull()) return;


        m_Inventory.Add(item);
        GameEventSystem.Instance.TriggerEvent(EGameEvent.InventoryChanged, new GameEventMessage(EGameEventMessage.ItemList, m_Inventory));
        SaveGame();
    }

    private void SaveGame()
    {
        SaveSystem.Save(m_Inventory);
    }

    public void LoadGame()
    {
        SaveSystem.Load((saveData) => m_Inventory = saveData.ToItens());
        GameEventSystem.Instance.TriggerEvent(EGameEvent.InventoryChanged, new GameEventMessage(EGameEventMessage.ItemList, m_Inventory));

        transform.position = m_PositionInitial;
        transform.forward = m_FowardInitial;
    }
}
