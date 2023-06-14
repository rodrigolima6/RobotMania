using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour
{
    public float speed = 1f;
    public float growthRate = 0.1f;
    public int damage = 1;
    private float maxScale = 0.65f;

    private void Start()
    {
        // Set a random direction for the ball
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody2D>().velocity = randomDirection * speed;
    }

    private void Update()
    {
        // Scale the ball
        transform.localScale += new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime;

        // Check if the ball should disappear
        if (transform.localScale.x >= maxScale)
        {
            // Remove the ball and deduct player's life
            Destroy(gameObject);
            GameManager.Instance.DeductLife(damage);
        }

    }

    private void OnMouseDown()
    {
        GameManager.Instance.IncreaseScore(100);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        // Clamp the ball's position to the screen boundaries
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, GameManager.Instance.ScreenBounds.min.x, GameManager.Instance.ScreenBounds.max.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, GameManager.Instance.ScreenBounds.min.y, GameManager.Instance.ScreenBounds.max.y);
        transform.position = clampedPosition;
    }
}
