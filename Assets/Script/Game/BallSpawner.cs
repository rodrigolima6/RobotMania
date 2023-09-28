using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public float spawnRate = 1f;
    public GameObject ballPrefab;
    public float delayAfterSpawn = 1f;
    public int delay = 1000;

    private void Start()
    {
        InvokeRepeating("SpawnBallWithDelay", 1f, spawnRate);
    }

    private void SpawnBallWithDelay()
    {
        int randomInt = Random.Range(1, 10);

        if (randomInt>=GameManager.SballSpawnRate)
        {
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
            
        }
    }

    
}

