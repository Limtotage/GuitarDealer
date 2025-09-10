using UnityEngine;
using UnityEngine.Tilemaps;

public class MazeGameFinal : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private GameObject MazeGame;
    [SerializeField] private GameObject MainGame;
    [SerializeField] private Transform target;
    [SerializeField] private Transform navigator;
    [SerializeField] private Vector3 _spawnPoint;

    [Header("Settings")]
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private Vector2 _direction;
    private Color color;

    void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {

        if (ColorUtility.TryParseHtmlString("#f1f8cdff", out color)) { }
        else
        {
            Debug.Log("Geçersiz HEX kodu!");
        }

    }

    void LateUpdate()
    {
        TryingPaint();
    }
    void TryingPaint()
    {
        Vector3Int cellPosition = _tilemap.WorldToCell(transform.position);

        _tilemap.SetTileFlags(cellPosition, TileFlags.None);
        _tilemap.SetColor(cellPosition, color);
    }
    void PlayerMove()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");
        _direction.Normalize();
        _rb.velocity = _direction * _speed;
    }
    void Update()
    {
        Nav();
    }
    void FixedUpdate()
    {
        PlayerMove();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SafeSpot")
        {
            _spawnPoint = collision.transform.position;
        }
        if (collision.tag == "WIN")
        {
            Debug.Log("Win");
            MainGameManager.Instance.NextEvent();
            MazeGame.SetActive(false);
            MainGame.SetActive(true);
        }
        if (collision.tag == "Danger")
        {
            transform.position = _spawnPoint;
        }
    }
    void Nav()
    {
        if (target == null) return;

        Vector3 dir = target.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        navigator.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
