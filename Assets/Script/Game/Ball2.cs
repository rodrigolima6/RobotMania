using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

[RequireComponent(typeof(GazeAware))]
public class Ball2 : MonoBehaviour
{
    private GazeAware _gazeAwareComponent;
    private SpriteRenderer spriteRenderer;

    public float speed = 1f;
    public float growthRate = 0.1f;
    public int damage = 1;
    private float maxScale = 0.65f;

    private float startTime;
    private float elapsedTime = 0;
    private int currentIndex = 0;

    private bool isLookedAt = false;
    private float lookTimer = 0f;

    private float changeInterval = 1.0f;
    private float minInterval = 0.1f;
    private float intervalDecrement = 0.1f;

    private Animator animator;

    private void Start()
    {
        _gazeAwareComponent = GetComponent<GazeAware>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();

        // Set a random direction for the ball
        speed = GameManager.SballSpeed / 10;
        //Debug.Log("Speed ="+speed+"| Ball Speed = " + GameManager.SballSpeed);
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody>().velocity = randomDirection * speed;
        startTime = Time.time;
    }

    private void Update()
    {
        Eye_Contect();
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

    private void Eye_Contect()
    {
        // Check if the ball is being looked at
        if (_gazeAwareComponent.HasGazeFocus)
        {
            Debug.Log("IM NOT INVISIBLE");
            inplode_Attack();
        }
        else
        {
            Debug.Log("IM INVISIBLE");
        }
    }

    private void inplode_Attack()
    {
        
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        _gazeAwareComponent.enabled = false;
        animator.Play("Atk_Implusion");

        // Call a method to destroy the object after a delay (duration of the new animation)
        float newAnimationDuration = CalculateNewAnimationDuration();
   
        DestroyObjectAfterDelay(0.35f);
    }

    private float CalculateNewAnimationDuration()
    {
        // Here, you would calculate and return the duration of the new animation
        // You can use animator.GetCurrentAnimatorStateInfo(0).length to get the length of the current state
        // You might also want to add a small buffer time
        // For example:
        float bufferTime = 0.2f;
        return animator.GetCurrentAnimatorStateInfo(0).length + bufferTime;
    }

    private void DestroyObjectAfterDelay(float delay)
    {
        // Destroy the object after the given delay
        GameManager.Instance.IncreaseScore(100);
        GameManager.Set_Reflexes(elapsedTime);
        Destroy(gameObject, delay);
    }

  
    private void OnMouseDown()
    {
        inplode_Attack();
        //Destroy(gameObject);
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
