using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _targetPrefab;
    [SerializeField] private GameObject _targetGuitar;
    [SerializeField] private Sprite _targetSprite;
    [SerializeField] private int _count;
    [SerializeField] private GameObject Money;
    [SerializeField] private int index;

    private SpriteRenderer _nesnenin;
    private bool once = true;
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
        MainGameManager.Instance.NextEvent();
        once = true;
    }
    void Update()
    {

        if (_count <= -1&&once)
        {
            once = false;
            if (_nesnenin != null)
            {
                _nesnenin.sprite = _targetSprite;

            }
            switch (index)
            {
                case 0:
                    GameValueButtons.GInstance.BlackMoney();
                    break;
                case 1:
                    GameValueButtons.GInstance.MoneyLaundring1();
                    break;
                case 2:
                    GameValueButtons.GInstance.MoneyLaundring2();
                    break;
                case 3:
                    GameValueButtons.GInstance.MoneyLaundringfinal();
                    break;
                default:
                    GameValueButtons.GInstance.BlackMoney();
                    break;
            }
            StartCoroutine(Seen1Second());

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        _count -= 1;
        Destroy(collision.gameObject);
    }


}
