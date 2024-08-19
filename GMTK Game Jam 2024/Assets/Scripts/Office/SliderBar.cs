using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    // named variable -- for repeated use for every bar
    public string variable;
    public DataManager dataManager;
    private Slider slider;
    private float newValue;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        getValue();
        slider.value = newValue;
    }

    //function: set slider value based on variable number from data manager
    void getValue(){
        switch (variable) {
            case "money":
                newValue = dataManager.Money / 1000000;     //max value = 1 million
                break;
            case "morality":
                newValue = dataManager.Morality / 100;      //max value = 100
                break;
            case "reputation":
                newValue = dataManager.Reputation / 100;    //max value = 100
                break;
        }
    }

    //function: start slow update of bar (when computer closes? just playing with features lmao)
    public void startUpdate(){
        getValue();
        StartCoroutine(updateBar());
    }

    // coroutine: slowly update bar value
    IEnumerator updateBar() {
        float increment = (newValue - slider.value)/3;
        int i = 0;

        print(increment);

        // slow increase over 3 seconds
        while (i < 3){
            slider.value += increment;
            yield return new WaitForSecondsRealtime(1); //Wait 1 second
            i++;
        }
    }
}