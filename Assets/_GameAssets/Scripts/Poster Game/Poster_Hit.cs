using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poster_Hit : MonoBehaviour
{
    private int scoreValue = -1;

    public void Cut()
    {
        Debug.Log("You Hit Me");
        GameManager.Instance.AddScore(scoreValue);
        Destroy(gameObject);
    }
}
