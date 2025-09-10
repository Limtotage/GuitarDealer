using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWithSpawnPoints : MonoBehaviour
{
    [Header("Hareket")]
    public float moveSpeed = 5f;

    [SerializeField] private GameObject FinalDontBusted;
    [SerializeField] private GameObject finalMaze;

    private Vector3 _spawnPoint;
    // private
    Rigidbody2D rb;
    Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        _spawnPoint = gameObject.transform.position;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SafeSpot")
        {
            _spawnPoint = collision.transform.position;
        }
        if (collision.tag == "WIN")
        {
            FinalDontBusted.SetActive(false);
            finalMaze.SetActive(true);
        }
        else if (collision.tag == "Danger")
        {
            Debug.Log("Dead");
            gameObject.transform.position = _spawnPoint;
        }
    }
}
