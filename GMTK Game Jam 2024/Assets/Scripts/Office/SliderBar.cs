using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    // named variable -- for repeated use for every bar
    public string variable;
    public DataManager dataManager;
    private Slider slider;
    private float sliderValue;
    
    void Awake(){
        slider = GetComponent<Slider>();
    }

    //function: set slider value based on variable number from data manager
    void GetValue(){
        switch (variable) {
            case "money":
                sliderValue = (float) dataManager.Money / 1000000f;     //max value = 1 million
                break;
            case "morality":
                sliderValue = (float) dataManager.Morality / 100f;      //max value = 100
                break;
            case "reputation":
                sliderValue = (float) dataManager.Reputation / 100f;    //max value = 100
                break;
        }
    }

    //function: start slow update of bar (when computer closes? just playing with features lmao)
    public void StartUpdate(){
        GetValue();
        Debug.Log(sliderValue);
        slider.DOValue(sliderValue, 2f);
    }
}