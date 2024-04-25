using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateRun : APlayerState
{
    private int m_InventorySlotMax = 5;
    private List<ItemData> m_Inventory;
    private PlayerMoveController m_PlayerMoveController;
    private AMiniGameController m_MiniGameController;
    private GameEventSystem m_EventSystem;

    public PlayerStateRun(PlayerBehaviorManager attachedBehavior) : base(attachedBehavior, EPlayerState.Run)
    {

        m_PlayerMoveController = attachedBehavior.GetComponent<PlayerMoveController>();
        m_EventSystem = GameEventSystem.Instance;
        m_MiniGameController = null;
        m_Inventory = new List<ItemData>();
    }

    public override void Enter()
    {
        SubscribeAll();
    }

    public override void Execute()
    {
        Debug.Log("IS GAME");
        if (Input.GetKeyDown(GameParameters.InputName.GAME_MENU))
        {
            m_AttachedBehavior.ChangeState(EPlayerState.PauseMenu);
            return;
        }

        if (Input.GetKey(KeyCode.Space) && m_MiniGameController != null)
        {
            PlayMiniGame(m_MiniGameController);
        }

        m_PlayerMoveController.Execute();
    }

    public override void OnTriggerEnter(Collider other)
    {
        AMiniGameController miniGameController = other.GetComponent<AMiniGameController>();

        if (miniGameController != null)
        {
            m_MiniGameController = miniGameController;
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        AMiniGameController miniGameController = other.GetComponent<AMiniGameController>();

        if (miniGameController != null)
        {
            m_MiniGameController = null;
        }
    }

    private void SubscribeAll()
    {
        m_EventSystem.SubscribeTo(EGameEvent.MiniGameEnd, OnMiniGameEnd);
    }

    private void PlayMiniGame(AMiniGameController controller)
    {
        switch (controller.MiniGameId)
        {
            case EMiniGame.Bread:
                m_AttachedBehavior.ChangeState(EPlayerState.MiniGameBread);
                break;
            case EMiniGame.Ham:
                m_AttachedBehavior.ChangeState(EPlayerState.MiniGameMeat);
                break;
        }
    }

    private void OnMiniGameEnd(GameEventMessage message)
    {
        if (message.Contains<ItemData>(EGameEventMessage.Item, out ItemData item) && !IsInventoryFull())
        {
            m_Inventory.Add(item);
            m_EventSystem.TriggerEvent(EGameEvent.InventoryChanged, new GameEventMessage(EGameEventMessage.Inventory, m_Inventory));
        }
    }

    private bool IsInventoryFull()
    {
        return m_Inventory.Count >= m_InventorySlotMax;
    }
}