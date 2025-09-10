using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPosterPlayer : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(worldPos);

            if (hit != null)
            {
                if (hit.GetComponent<FinalPosterHit>() != null)
                    hit.GetComponent<FinalPosterHit>().Cut();
                else if (hit.GetComponent<FinalBombHit>() != null)
                    hit.GetComponent<FinalBombHit>().BOOM();
            }
        }
    }
}
