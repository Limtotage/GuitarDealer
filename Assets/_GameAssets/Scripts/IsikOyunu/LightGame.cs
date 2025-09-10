using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightGame : MonoBehaviour
{
    [Header("Hareket")]
    public float moveSpeed = 5f;

    [SerializeField] private GameObject DontBusted;
    [SerializeField] private GameObject MainGame;
    // private
    Rigidbody2D rb;
    Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (collision.tag == "WIN")
        {
            MainGameManager.Instance.NextEvent();
            DontBusted.SetActive(false);
            MainGame.SetActive(true);
        }
        else if (collision.tag == "Danger")
        {
            Debug.Log("Dead");
            Transform t = DontBusted.transform;
            gameObject.transform.position = new Vector3(t.position.x+11.19939f,t.position.y+ -16.86978f,t.position.z+ 0.4721049f);
        }
    }




}
