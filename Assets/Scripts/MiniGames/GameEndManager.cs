using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndManager : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> m_ItemNames;
    [SerializeField] private List<TextMeshProUGUI> m_ItemPrices;
    [SerializeField] private TextMeshProUGUI m_ItemTotal;
    [SerializeField] private GameObject m_GameEndPanel;
    [SerializeField] private CinemachineVirtualCamera m_Camera;
    
    private void Start()
    {
        GameEventSystem.Instance.SubscribeTo(EGameEvent.GameEndDisplay, OnGameEnd);
    }

    private void OnGameEnd(GameEventMessage message)
    {
        ChangeCamera();
        m_GameEndPanel.SetActive(true);
        if (message.Contains<List<Item>>(EGameEventMessage.ItemList, out List<Item> itens))
        {
            float total = 0;
            for(int i = 0; i < itens.Count; i++)
            {
                m_ItemNames[i].text = $"1 x {itens[i].Name}";
                m_ItemPrices[i].text = itens[i].Price.ToString("0.00");
                total += itens[i].Price;
            }

            m_ItemTotal.text = "Total: " + total.ToString("0.00");
        }
    }

    private void ChangeCamera()
    {
        ICinemachineCamera oldCamera = GetCinemachineBrain().ActiveVirtualCamera;
        oldCamera.Priority = 0;
        m_Camera.Priority = 1;
    }
    private CinemachineBrain GetCinemachineBrain()
    {
        return CinemachineCore.Instance.GetActiveBrain(0);
    }

    public void OnClickPayAndLeaveButton()
    {
        SceneManager.LoadScene(GameParameters.SceneName.GAME);
    }
}
