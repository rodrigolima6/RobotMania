using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawnner : MonoBehaviour
{
    public GameObject heartPrefab;
    private float startTime;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        startTime = Time.time;
    }

    private void Update()
    {
        if (HasOneMinutesPassed()) {
            startTime = Time.time;
            int randomInt = Random.Range(1, 100);
            if (randomInt >= 50)
            {
                SpawnHeart();
            }
        }
    }

    private void SpawnHeart()
    {
        Vector3 randomPosition = GetRandomScreenPosition();
        Instantiate(heartPrefab, randomPosition, Quaternion.identity);
    }

    private Vector3 GetRandomScreenPosition()
    {
        float screenX = Random.Range(0f, Screen.width);
        float screenY = Random.Range(0f, Screen.height);
        Vector3 randomScreenPosition = new Vector3(screenX, screenY, 0f);

        Vector3 randomWorldPosition = mainCamera.ScreenToWorldPoint(randomScreenPosition);
        randomWorldPosition.z = 0f;

        return randomWorldPosition;
    }

    public  bool HasOneMinutesPassed()
    {
        // Calculate the elapsed time since the starting time
        float elapsedTime = Time.time - startTime;

        // Check if five minutes (300 seconds) have passed
        if (elapsedTime >= 20f)
        {
            return true;
        }

        return false;
    }
}


