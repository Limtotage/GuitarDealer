using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinalMoneyGame : MonoBehaviour
{
    public static FinalMoneyGame Instance;
    [SerializeField] private GameObject _targetPrefab;
    [SerializeField] private GameObject _targetGuitar;
    [SerializeField] private Sprite _targetSprite;
    [SerializeField] private int _count;
    [SerializeField] private GameObject Money;

    private SpriteRenderer _nesnenin;
    private bool once = true;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("Atandim");
            Money.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _nesnenin = GetComponent<SpriteRenderer>();
        for (int i = 0; i < _count; i++)
        {
            Instantiate(_targetPrefab, new Vector2(0, 0), Quaternion.identity);
        }
        Instantiate(_targetGuitar, new Vector2(0, 0), Quaternion.identity);
    }
    public void LetsGo()
    {
        Money.SetActive(true);
    }
    IEnumerator Seen1Second()
    {
        yield return new WaitForSeconds(1f);
        Money.SetActive(false);
        MainGameManager.Instance.FinalGame();
        once = true;
    }
    void Update()
    {

        if (_count <= -1 && once)
        {
            once = false;
            if (_nesnenin != null)
            {
                _nesnenin.sprite = _targetSprite;

            }
            GameValueButtons.GInstance.MoneyLaundringfinal();
            StartCoroutine(Seen1Second());

        }
    }
    public void DecreaseCount()
    {
        _count -= 1;
    }



}
