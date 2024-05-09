using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameControllerr : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene(GameParameters.SceneName.GAME);
    }
}
