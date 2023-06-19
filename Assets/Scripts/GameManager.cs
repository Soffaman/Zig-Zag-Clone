using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public int score = 0;

    public TextMeshProUGUI textMesh;

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

    public void ScoreIncrease()
    {
        score++;
        textMesh.text = score.ToString();
    }
}
