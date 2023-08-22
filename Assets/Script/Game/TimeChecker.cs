using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChecker : MonoBehaviour
{
    private static float startTime;
    public static float elapsedTime;
    private static bool TimerOn;

    private void Awake()
    {
        // Store the current time as the starting time
        startTime = Time.time;
    }

    private void Start()
    {
        TimerOn = false;
        startTime = Time.time;
    }




    public static bool HasFiveMinutesPassed()
    {
        if (TimerOn == false)
        {
            TimerOn = true;
            startTime = Time.time;
        }

        // Calculate the elapsed time since the starting time
        elapsedTime = Time.time - startTime;

        // Check if five minutes (300 seconds) have passed
        if (elapsedTime >= 300f)
        {
            startTime = Time.time;
            TimerOn = false;
            return true;
        }
        
        return false;
    }
}

