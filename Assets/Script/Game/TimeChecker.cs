using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChecker : MonoBehaviour
{
    private static  float startTime;

    private void Awake()
    {
        // Store the current time as the starting time
        startTime = Time.time;
    }



    public static bool HasFiveMinutesPassed()
    {
        // Calculate the elapsed time since the starting time
        float elapsedTime = Time.time - startTime;

        // Check if five minutes (300 seconds) have passed
        if (elapsedTime >= 300f)
        {
            startTime = Time.time;
            return true;
        }
        
        return false;
    }
}

