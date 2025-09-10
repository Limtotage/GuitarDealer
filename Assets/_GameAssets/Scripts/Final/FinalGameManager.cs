using TMPro;
using UnityEngine;

public class FinalGameManager : MonoBehaviour {
    public static FinalGameManager Instance;
    [SerializeField]private int score = 10;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private GameObject PosterGame;
    [SerializeField] private GameObject DontBusted;
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
            PosterGame.SetActive(false);
            DontBusted.SetActive(true);
        }
        scoreText.text = "Target: " + score;
    }

    public void GameOver()
    {
        score += 5;
        scoreText.text = "Target: " + score;
    }
}