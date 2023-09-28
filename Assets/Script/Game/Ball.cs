using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour
{
    public float speed = 1f;
    public float growthRate = 0.1f;
    public int damage = 1;
    private float maxScale = 0.65f;

    private float startTime;
    private float elapsedTime=0;

    private void Start()
    {

        // Set a random direction for the ball
        speed = GameManager.SballSpeed/10;
        //Debug.Log("Speed ="+speed+"| Ball Speed = " + GameManager.SballSpeed);
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody2D>().velocity = randomDirection * speed;
        startTime = Time.time;
    }

    private void Update()
    {
        // Scale the ball
        transform.localScale += new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime;
        elapsedTime = Time.time - startTime;
        // Check if the ball should disappear
        if (transform.localScale.x >= maxScale)
        {
            // Remove the ball and deduct player's life
            GameManager.Set_Reflexes(elapsedTime);
            Destroy(gameObject);
            GameManager.Instance.DeductLife(damage);
        }

    }

    private void OnMouseDown()
    {
        GameManager.Instance.IncreaseScore(100);
        GameManager.Set_Reflexes(elapsedTime);
        Destroy(gameObject);
    }

    public void onMouseOnTop()
    {
        GameManager.Instance.IncreaseScore(100);
        GameManager.Set_Reflexes(elapsedTime);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        // Clamp the ball's position to the screen boundaries
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, GameManager.Instance.getScreenBounds().min.x, GameManager.Instance.getScreenBounds().max.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, GameManager.Instance.getScreenBounds().min.y, GameManager.Instance.getScreenBounds().max.y);
        transform.position = clampedPosition;
    }
}
