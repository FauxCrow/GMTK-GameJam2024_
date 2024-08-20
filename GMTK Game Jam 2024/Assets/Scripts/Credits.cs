using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] GameObject credits;

    public void CreditsState(bool state){
        credits.SetActive(state);
    }
}