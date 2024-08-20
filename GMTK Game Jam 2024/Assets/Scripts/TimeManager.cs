using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshPro clocktext;
    [SerializeField] TextMeshPro dayText;
    [SerializeField] GameManager gm;

    public float timeMultipler;

    public const int hoursInDay = 24;
    public const int minutesInHour = 60;

    [InspectorName("Day Duration in seconds")]
    public float dayDuration;

    float totalTime;
    float currentTime;
    public int currentDay;

    public void ResetTime(){
        totalTime = 180f;
    }

    public void StartTimer(){
        timeMultipler = 1f;
    }

    public void StopTimer(){
        timeMultipler = 0f;
    }

    void ResetDay(){
        currentDay = 0;
    }

    void Update()
    {
        if(!gm.GameInPlay) return;
        totalTime += Time.deltaTime * timeMultipler;
        currentTime = totalTime % dayDuration;

        clocktext.text = Clock24Hour();

        if((int)totalTime == 360){
            CheckEndOfDay();
        }
    }

    void CheckEndOfDay(){
        currentDay++;
        // dayText.text = "Current Day: " + currentDay;
        StopTimer();
        gm.StartNewDay();
        gm.GameInPlay = false;
    }

    public float GetHour()
    {
        return currentTime * hoursInDay / dayDuration;
    }

    public float GetMinute()
    {
        return (currentTime * hoursInDay * minutesInHour / dayDuration) % minutesInHour;
    }

    public string Clock24Hour()
    {
        return Mathf.FloorToInt(GetHour()).ToString("00") +":" + Mathf.FloorToInt(GetMinute()).ToString("00");   
    }

    public void ResetAll(){
        ResetDay();
        ResetTime();
    }
}
