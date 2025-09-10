using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcordStop : MonoBehaviour
{
    [SerializeField] private GameObject _acordGame;
    [SerializeField] private GameObject _targetPrefab;
    [SerializeField] private GameObject _currentTarget;

    [SerializeField] private float speed = 3f;

    private float minX = -8.7f;
    private float maxX = 8.7f;
    private int direction = 1;
    private bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

            if (transform.position.x >= maxX)
                direction = -1;
            else if (transform.position.x <= minX)
                direction = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = false;
            CheckHit();
        }
    }
    void OnEnable()
    {
        isMoving = true;
        Spawn();
    }
    void CheckHit()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        Vector2 size = col.size;
        Vector2 pos = transform.position;

        Collider2D hit = Physics2D.OverlapBox(pos, size, 0f, LayerMask.GetMask("WIN"));

        if (hit != null)
        {
            if (_currentTarget != null) Destroy(_currentTarget.gameObject);
            _acordGame.SetActive(false);
            GameValueButtons.GInstance.acord();
            MainGameManager.Instance.NextEvent();
        }
        else
        {
            if (_currentTarget != null) Destroy(_currentTarget.gameObject);
            _acordGame.SetActive(false);
            _acordGame.SetActive(true);

        }
    }
    void Spawn()
    {
        float randomX = Random.Range(-7.7f, 7.7f);
        Vector2 spawnPos = new Vector2(randomX, 0);
        _currentTarget = Instantiate(_targetPrefab, spawnPos, Quaternion.identity);
    }

}
