using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataLogger : MonoBehaviour
{
    public String Name = "default";
    private List<string> dataRows = new List<string>();
    private string filePath;
    private float timer = 0f;
    private float interval = 20f; // 20 seconds interval

    private void Start()
    {
        // Set the file path for the CSV file
        filePath = Application.dataPath + "/"+Name+".csv";

        // Initialize the CSV file with headers
        dataRows.Add("Timestamp,Score,Time,Life,Score/10s,Life/10s,Reflexes,Ball Speed, Ball Spawn Rate, Life Spawn Rate");

        // Start the data logging coroutine
        StartCoroutine(LogData());
    }

    private IEnumerator LogData()
    {
        while (true)
        {


            // Simulate receiving data (replace this with your actual data source)
             string newData = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + GameManager.Sscore + "," + GameManager.Stime + "," + GameManager.SplayerLife + ","+ GameManager.SscorePsecond + "," + GameManager.SLifePsecond + "," + GameManager.SReflexes + "," + GameManager.SballSpeed + "," + GameManager.SballSpawnRate + "," + GameManager.SlifeSpawnRate;
            //Debug.Log(newData);
            // Add the new data to the list
            dataRows.Add(newData);

            // Check if it's time to write to the CSV file
            if (timer >= interval)
            {
                // Write data to the CSV file
                File.AppendAllLines(filePath, dataRows);

                // Clear the data list for the next interval
                dataRows.Clear();

                // Reset the timer
                timer = 0f;
            }

            // Wait for a short time
            yield return new WaitForSeconds(1f);

            // Increment the timer
            timer += 1f;
        }
    }
}
