using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public GameObject gameOverScreen;
    public Text scoreText;

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int newScore)
    {
        if (!isGameOver)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);
    }
}
