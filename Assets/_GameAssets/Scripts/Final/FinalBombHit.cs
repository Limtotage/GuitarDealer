using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBombHit : MonoBehaviour
{
    public void BOOM()
    {
        FinalGameManager.Instance.GameOver();
        Destroy(gameObject);
    }
}
