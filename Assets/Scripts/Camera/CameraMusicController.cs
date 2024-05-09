using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMusicController : MonoBehaviour
{


    // TODO: Transformer ça dans Event quand j'ai fini le jeu
    private void Start()
    {
        GameEventSystem.Instance.SubscribeTo(EGameEvent.GameEndDisplay, OnGameEnd);
    }

    private void OnGameEnd(GameEventMessage message)
    {
        GetComponent<AudioSource>().Stop();
    }

    private void OnDisable()
    {
        GameEventSystem.Instance.UnsubscribeFrom(EGameEvent.GameEndDisplay, OnGameEnd);
    }
}
