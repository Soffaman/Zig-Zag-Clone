using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;

    public void StartGame()
    {
        gameStarted = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void EndGame(Transform transform )
    {
        if (transform.position.y < -2)
        {
            SceneManager.LoadScene(0);
        }
    }
}
