using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairGame : MonoBehaviour
{
    [SerializeField] private GameObject acord;

    public void AcordEt()
    {
        acord.SetActive(true);
    }
}
