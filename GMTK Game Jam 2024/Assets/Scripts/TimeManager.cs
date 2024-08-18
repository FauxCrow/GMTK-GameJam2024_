using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timeMultipler;

    public const int hoursInDay = 24;
    public const int minutesInHour = 60;

    [InspectorName("Day Duration in seconds")]
    public float dayDuration;

    float totalTime = 0;
    float currentTime = 0;

    void Update()
    {
        totalTime += Time.deltaTime * timeMultipler;
        currentTime = totalTime % dayDuration;
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
}
