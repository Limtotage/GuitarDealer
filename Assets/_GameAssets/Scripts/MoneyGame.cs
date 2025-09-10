using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGame : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 offset;
    private bool dragging = false;

    void OnEnable()
    {
        Spawn();
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = (Vector2)transform.position - mouseWorld;
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void FixedUpdate()
    {
        if (!dragging) return;
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 target = mouseWorld + offset;
        rb.MovePosition(target);
    }
    void Spawn()
    {
        float randomX = Random.Range(-2.9f, 8.16f);
        float randomY = Random.Range(-4f, 4f);
        gameObject.transform.position = new Vector3(randomX, randomY, 0);
    }
}
