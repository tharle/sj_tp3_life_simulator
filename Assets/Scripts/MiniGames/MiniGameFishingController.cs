using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiniGameFishingController : AMiniGameController
{
    /*[SerializeField] Vector3 m_OffsetCamera = new Vector3(0.46f, 1.58f, -1.43f);
    [SerializeField] float m_RotationCamera = 140f;*/

    [SerializeField] Vector3 m_OffsetCamera;
    [SerializeField] float m_RotationCamera;

    public override void StartMinigame()
    {
        base.StartMinigame();
        PlayerAnimation.Instance.Fishing();
        List<Item>  itens = ItemLoader.Instance.GetAll(true); ;

        m_Item = itens[Random.Range(0, itens.Count)];
        SetupCamera(m_OffsetCamera, m_RotationCamera);
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
