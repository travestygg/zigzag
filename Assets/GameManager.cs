using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public int score = 0;   
    public TextMeshProUGUI scoreText;
    public void StartGame()
    {
        gameStarted = true;
        Debug.Log("Game Started");
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
            Debug.Log("KeyDown Working");
        }
    }

    public void EndGame() {
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = "Score: " + score.ToString();

    }
}
