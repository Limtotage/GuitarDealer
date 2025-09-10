using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowProductInfo : MonoBehaviour
{
    [SerializeField] private Image _guitar;
    [SerializeField] private TMP_Text _guitarPrice;
    [SerializeField] private TMP_Text _guitarType;
    [SerializeField] private Button _sellButton;
    private GameObject selectedGuitar;
    void Start()
    {
        _sellButton.onClick.AddListener(sellGuitar);

    }
    void sellGuitar() {
        GuitarSeller.Instance.GuitarSell(selectedGuitar);
        gameObject.SetActive(false);
    }
    void OnEnable()
    {
        selectedGuitar = GuitarSeller.Instance.selectGuitar();
        SpriteRenderer guitarSprite = selectedGuitar.GetComponent<SpriteRenderer>();
        if (guitarSprite != null) { _guitar.sprite = guitarSprite.sprite; }
        _guitarPrice.text = "Price: "+GameValueButtons.GInstance.GetGuitarVal() + " $";
        _guitarType.text = "Type: Classical Guitar";
    }
}
