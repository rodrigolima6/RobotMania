using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour { 
    public float growthRate = 0.1f;
    private float maxScale = 2.2f;

    // Start is called before the first frame update
    private void Update()
    {
        // Scale the ball
        transform.localScale += new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime;

        // Check if the ball should disappear
        if (transform.localScale.x >= maxScale)
        {
            // Remove the ball and deduct player's life
            Destroy(gameObject);
        }

    }

    private void OnMouseDown()
    {
        GameManager.Instance.IncreaseLife(1);
        Destroy(gameObject);
    }
}
