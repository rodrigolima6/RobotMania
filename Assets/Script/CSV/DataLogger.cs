using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataLogger : MonoBehaviour
{
    public string Name = "default";
    private DateTime currentTime;
    private List<DataEntry> dataRows = new List<DataEntry>();
    private string filePath;
    private float timer = 0f;
    private float interval = 290f; // 20 seconds interval

    private string[] headers = {
        "Score",
        "Time",
        "Score/10s",
        "Reflexes",
        "Ball Speed"
    };

    [Serializable]
    public class DataEntry
    {
        public string Timestamp;
        public float Score;
        public float Time;
        public float ScorePerSecond;
        public float Reflexes;
        public float BallSpeed;
    }

    private void Start()
    {
        currentTime = System.DateTime.Now;
        string dateString = currentTime.Hour + "_" + currentTime.Minute + "_" + currentTime.Second + "_" + currentTime.Day + "_" + currentTime.Month;
        // Set the file path for the JSON file
        filePath = Application.dataPath + "/data/" + Name + "_" + dateString + ".json";

        // Start the data logging coroutine
        StartCoroutine(LogData());
    }

    private IEnumerator LogData()
    {
        while (true)
        {
            // Simulate receiving data (replace this with your actual data source)
            DataEntry newData = new DataEntry
            {
                Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Score = GameManager.Sscore,
                Time = GameManager.Stime,
                ScorePerSecond = GameManager.SscorePsecond,
                Reflexes = GameManager.SReactTime,
                BallSpeed = GameManager.SballSpeed
            };

            // Add the new data to the list
            dataRows.Add(newData);

            // Check if it's time to write to the JSON file
            if (timer >= interval)
            {
                // Convert the list to JSON
                string jsonData = JsonUtility.ToJson(new DataWrapper { DataEntries = dataRows }, true);

                // Write data to the JSON file
                File.WriteAllText(filePath, jsonData);

                // Clear the data list for the next interval
               // dataRows.Clear();

                // Reset the timer
                timer = 0f;
            }

            // Wait for a short time
            yield return new WaitForSeconds(1f);

            // Increment the timer
            timer += 1f;
        }
    }

    [Serializable]
    private class DataWrapper
    {
        public List<DataEntry> DataEntries;
    }
}
