using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Hit : MonoBehaviour
{
    public void BOOM()
    {
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }
}
