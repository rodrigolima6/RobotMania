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
        dataRows.Add("Timestamp,Score,Time,Life,Ball Speed, Ball Spawn Rate, Life Spawn Rate, SCalculation1, SCalculation2, SCalculation3, SCalculation4, SCalculation5, SCalculation6, SCalculation7, SCalculation8, SCalculation9, SCalculation10, SCalculation11, SCalculation12, SCalculation13");

        // Start the data logging coroutine
        StartCoroutine(LogData());
    }

    private IEnumerator LogData()
    {
        while (true)
        {
            float SCalculation1 = (GameManager.Sscore + GameManager.SplayerLife * 10) / GameManager.Stime;
            float SCalculation2 = (GameManager.Sscore + GameManager.SplayerLife * 10) / (GameManager.Stime / 2);
            float SCalculation3 = (GameManager.Sscore + GameManager.SplayerLife * 10) / (GameManager.Stime / 4);

            float SCalculation4 = (GameManager.Sscore + GameManager.SplayerLife * 100) / GameManager.Stime;
            float SCalculation5 = (GameManager.Sscore + GameManager.SplayerLife * 100) / (GameManager.Stime / 2);
            float SCalculation6 = (GameManager.Sscore + GameManager.SplayerLife * 100) / (GameManager.Stime / 4);

            float SCalculation7 = (GameManager.Sscore + GameManager.SplayerLife * 50) / GameManager.Stime;
            float SCalculation8 = (GameManager.Sscore + GameManager.SplayerLife * 50) / (GameManager.Stime / 2);
            float SCalculation9 = (GameManager.Sscore + GameManager.SplayerLife * 50) / (GameManager.Stime / 4);

            float SCalculation10 = ((GameManager.Sscore/10) + (300-(GameManager.SplayerLife * 100)) + (300-GameManager.Stime))/3;
            float SCalculation11 = ((GameManager.Sscore / 10) + (400 - (GameManager.SplayerLife * 100)) + (300 - GameManager.Stime)) / 3;
            float SCalculation12 = ((GameManager.Sscore / 20) + (300 - (GameManager.SplayerLife * 100)) + (300 - GameManager.Stime)) / 3;
            float SCalculation13 = ((GameManager.Sscore / 20) + (400 - (GameManager.SplayerLife * 100)) + (300 - GameManager.Stime)) / 3;

            // Simulate receiving data (replace this with your actual data source)
            string newData = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + GameManager.Sscore + "," + GameManager.Stime + "," + GameManager.SplayerLife + "," + GameManager.SballSpeed + "," + GameManager.SballSpawnRate + "," + GameManager.SlifeSpawnRate + "," + SCalculation1 + "," + SCalculation2 + "," + SCalculation3 + "," + SCalculation4 + "," + SCalculation5 + "," + SCalculation6 + "," + SCalculation7 + "," + SCalculation8 + "," + SCalculation9 + "," + SCalculation10 + "," + SCalculation11 + "," + SCalculation12 + "," + SCalculation13;

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
