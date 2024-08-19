using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IGNORE THIS SCRIPT ITS FOR ME
public class testing : MonoBehaviour
{
    public DataManager dataManager;
    public SliderBar sliderBar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(test());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator test(){
        yield return new WaitForSecondsRealtime(3);
        dataManager.Morality = 50;
        sliderBar.startUpdate();
    }
}
