    
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMoneyAcik: MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        FinalMoneyGame.Instance.DecreaseCount();
        Destroy(collision.gameObject);
    }
}
    
