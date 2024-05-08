using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiniGameFishingController : AMiniGameController
{

    #region Singleton
    private static MiniGameFishingController m_Instance;
    public static MiniGameFishingController Instance { get { return m_Instance; } }
    #endregion

    private void Awake()
    {
        if (m_Instance != null)
            Destroy(gameObject);

        m_Instance = this;
    }

    public override void StartMinigame()
    {
        base.StartMinigame();
        PlayerAnimation.Instance.Fishing();
        List<Item>  itens = ItemLoader.Instance.GetAll(true); ;

        m_Item = itens[Random.Range(0, itens.Count)];
    }

    public override void Execute()
    {
        base.Execute();
        Debug.Log("IS FISHING");

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            m_IsWin = true;
            StartCoroutine(EndMinigameRoutine());
        }
    }

    private IEnumerator EndMinigameRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        EndMinigame();
    }
}
