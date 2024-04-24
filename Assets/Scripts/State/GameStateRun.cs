using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateRun : AGameState
{
    PlayerController m_Controller;

    public GameStateRun(GameStateManager attachedBehavior) : base(attachedBehavior, EGameState.Run)
    {

        m_Controller = PlayerController.Instance;
    }

    public override void Enter()
    {
        Debug.Log("ENTER GAME");
    }

    public override void Execute()
    {
        Debug.Log("IS GAME");
        if (Input.GetKeyDown(GameParameters.InputName.GAME_MENU))
        {
            m_AttachedBehavior.ChangeState(EGameState.PauseMenu);
            return;
        }

        if (Input.GetKey(KeyCode.Space) && m_Controller.MiniGameControleValue != null)
        {
            PlayMiniGame(m_Controller.MiniGameControleValue);
        }

        m_Controller.Execute();
    }

    private void PlayMiniGame(AMiniGameController controller)
    {
        switch (controller.MiniGameId)
        {
            case EMiniGame.Bread:
                m_AttachedBehavior.ChangeState(EGameState.MiniGameBread);
                break;
            case EMiniGame.Ham:
                m_AttachedBehavior.ChangeState(EGameState.MiniGameMeat);
                break;
        }
    }

    public override void Exit()
    {
        Debug.Log("EXIT DOWN");
    }
}
