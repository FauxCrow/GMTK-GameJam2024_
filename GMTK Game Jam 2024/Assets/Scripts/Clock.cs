using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public TextMeshPro clockText;
    public float timer;
    public TimeManager tm;


    void Update()
    {
        // clockText.text = tm.Clock24Hour();
    }
}