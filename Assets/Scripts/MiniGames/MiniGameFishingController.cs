using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiniGameFishingController : AMiniGameController
{
    [SerializeField] private Vector3 m_OffsetCamera;
    [SerializeField] private float m_RotationCamera;

    private Vector2 m_WaitToShowRodRange = new Vector2(0.5f, 2f);
    private float m_WaitForFishing = 0.5f;
    private bool m_Hit;

    public override IEnumerator StartMinigame()
    {
        yield return base.StartMinigame();
        // Animation player
        PlayerAnimation.Instance.Fishing();
        
        // Setup camera
        SetupCamera(m_OffsetCamera, m_RotationCamera);
        
        // Load item
        List<Item>  items ;
        yield return ItemLoader.Instance.GetAll(true, 
            (itemsLoaded) => 
            {
                items = itemsLoaded;
                m_Item = items[Random.Range(0, items.Count)];

                // Show display
                GameEventSystem.Instance.TriggerEvent(EGameEvent.MiniGameFishingDisplay, new GameEventMessage(EGameEventMessage.Enter, true));

                // Start random frame for fishing
                StartCoroutine(FishingRodRoutine());

                m_IsWin = false;
            });
    }

    public override void Execute()
    {
        base.Execute();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            if (m_Hit) m_IsWin = true;

            EndMinigame();
        }
    }

    protected override void EndMinigame()
    {
        GameEventSystem.Instance.TriggerEvent(EGameEvent.MiniGameFishingDisplay, new GameEventMessage(EGameEventMessage.Exit, true));
        base.EndMinigame();
    }

    private IEnumerator FishingRodRoutine()
    {
        yield return new WaitForSeconds(1.5f); // Delay from camera
        m_Hit = false;
        yield return new WaitForSeconds(Random.Range(m_WaitToShowRodRange.x, m_WaitToShowRodRange.y));
        m_Hit = true;
        AudioManager.Instance.Play(EAudio.SFXFishingRod, transform.position);
        FishingRodToggle(true);
        yield return new WaitForSeconds(m_WaitForFishing);
        m_Hit = false;
        FishingRodToggle(false);
        EndMinigame();
    }

    private void FishingRodToggle(bool show)
    {
        GameEventSystem.Instance.TriggerEvent(EGameEvent.MiniGameFishingDisplay, new GameEventMessage(EGameEventMessage.FishingRodToggle, show));
    }
}
