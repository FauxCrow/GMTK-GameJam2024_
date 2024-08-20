using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] GameObject credit;

    public void SetCredit(bool state){
        credit.SetActive(state);
    }
}
