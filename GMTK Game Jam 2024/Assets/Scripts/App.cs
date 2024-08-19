using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class App : MonoBehaviour, IApp
{
    [SerializeField] protected GameObject window;
    [SerializeField] protected GameObject notificationIcon;
    [SerializeField] protected float animationDuration;

    public virtual void OpenApp(){}
    public virtual void CloseApp(){}
}