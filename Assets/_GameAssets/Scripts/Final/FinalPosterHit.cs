using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPosterHit : MonoBehaviour
{
    private int scoreValue = -1;

    public void Cut()
    {
        Debug.Log("You Hit Me");
        FinalGameManager.Instance.AddScore(scoreValue);
        Destroy(gameObject);
    }
}
