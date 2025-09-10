using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameValueButtons : MonoBehaviour
{
    public static GameValueButtons GInstance;

    [Header("References")]
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Button _corruptionIncreaseButton;
    [SerializeField] private Button _corruptionDecreaseButton;
    [SerializeField] private Button _reputationIncreaseButton;
    [SerializeField] private Button _reputationDecreaseButton;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private Image _reputationValue;
    [SerializeField] private RectTransform _reputationIcon;
    [SerializeField] private Image _corruptionValue;
    [SerializeField] private RectTransform _corruptionIcon;
    [SerializeField] private Vector2 endPos;
    [SerializeField] private Vector2 startPos;


    [SerializeField] private int _currentMoney = 200;

    private int _guitarVal = 100;
    public int GetGuitarVal()
    {
        return _guitarVal;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (GInstance == null)
        {
            GInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        updateMoney(_currentMoney);
    }

    private void buyGuitar()
    {
        if (_currentMoney >= _guitarVal)
        {
            _currentMoney -= _guitarVal;
            updateMoney(_currentMoney);
        }
    }
    public void sellGuitar()
    {
        _currentMoney += _guitarVal;
        updateMoney(_currentMoney);
    }
    public void acord()
    {
        _currentMoney += 50;
        updateMoney(_currentMoney);
    }
    public void BlackMoney()
    {
        _currentMoney -= 150;
        updateMoney(_currentMoney);
    }
    public void MoneyLaundring1()
    {
        _currentMoney += 50000;
        updateMoney(_currentMoney);
    }
    public void MoneyLaundring2()
    {
        _currentMoney += 250000;
        updateMoney(_currentMoney);
    }
    public void MoneyLaundringfinal()
    {
        _currentMoney += 500000;
        updateMoney(_currentMoney);
    }
    private void decreaseCorruption()
    {
        _corruptionValue.fillAmount -= 0.05f;
        _corruptionIcon.anchoredPosition = Vector2.Lerp(startPos, endPos, _corruptionValue.fillAmount);
    }
    private void increaseCorruption()
    {
        _corruptionValue.fillAmount += 0.05f;
        _corruptionIcon.anchoredPosition = Vector2.Lerp(startPos, endPos, _corruptionValue.fillAmount);
    }
    private void decreaseReputation()
    {
        _reputationValue.fillAmount -= 0.05f;
        _reputationIcon.anchoredPosition = Vector2.Lerp(startPos, endPos, _reputationValue.fillAmount);

    }
    //-16.5 - 77
    private void increaseReputation()
    {
        _reputationValue.fillAmount += 0.05f;
        _reputationIcon.anchoredPosition = Vector2.Lerp(startPos, endPos, _reputationValue.fillAmount);

    }
    private void updateMoney(int val)
    {
        _currentMoney = val;
        _moneyText.text = val + " $";
    }
}
