using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]private int score = 10;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private GameObject PosterGame;
    [SerializeField] private GameObject MainGame;
    void Awake()
    {
        Instance = this;
        scoreText.text = "Target: " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (score <= 0)
        {
            MainGameManager.Instance.NextEvent();
            PosterGame.SetActive(false);
            MainGame.SetActive(true);
        }
        scoreText.text = "Target: " + score;
    }

    public void GameOver()
    {
        score += 5;
        scoreText.text = "Target: " + score;
    }

}
