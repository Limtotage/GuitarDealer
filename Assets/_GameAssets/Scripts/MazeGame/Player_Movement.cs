using UnityEngine;
using UnityEngine.Tilemaps;

public class Player_Movement : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Tilemap _tilemap;
    [Header("Settings")]
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private Vector2 _direction;
    private Color color;
    [SerializeField] private GameObject MazeGame;
    [SerializeField] private GameObject MainGame;

    void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

        if (ColorUtility.TryParseHtmlString("#f1f8cdff", out color)) { }
        else
        {
            Debug.Log("Geçersiz HEX kodu!");
        }

    }

    // Update is called once per frame
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
    void FixedUpdate()
    {
        PlayerMove();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WIN")
        {
            MainGameManager.Instance.NextEvent();
            MazeGame.SetActive(false);
            MainGame.SetActive(true);
        }
    }
}
