using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarSeller : MonoBehaviour
{
    public static GuitarSeller Instance;
    [SerializeField] private List<GameObject> guitars = new List<GameObject>();
    [SerializeField] private GameObject _selectedGuitar;
    [SerializeField] private GameObject _cart;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public GameObject selectGuitar()
    {
        return guitars[Random.Range(0, guitars.Count)];
    }
    public void ShowCart()
    {
        _cart.SetActive(true);
    }
    public void GuitarSell(GameObject destroyGuitar)
    {
        guitars.Remove(destroyGuitar);
        Destroy(destroyGuitar);
    }
}
