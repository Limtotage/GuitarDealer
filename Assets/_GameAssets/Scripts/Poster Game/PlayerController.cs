using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(worldPos);

            if (hit != null)
            {
                if (hit.GetComponent<Poster_Hit>() != null)
                    hit.GetComponent<Poster_Hit>().Cut();
                else if (hit.GetComponent<Bomb_Hit>() != null)
                    hit.GetComponent<Bomb_Hit>().BOOM();
            }
        }
    }
}
