using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

[RequireComponent(typeof(GazeAware))]
public class Heart : MonoBehaviour {


    public List<Sprite> spriteList;

    private GazeAware _gazeAwareComponent;
    private SpriteRenderer spriteRenderer;
    public float growthRate = 0.1f;
    private float maxScale = 2.2f;

    private float startTime;
    private float elapsedTime = 0;
    private int currentIndex = 0;

    private void Start()
    {
        _gazeAwareComponent = GetComponent<GazeAware>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       

        startTime = Time.time;
    }

    // Start is called before the first frame update
    private void Update()
    {
        Eye_Contect();

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

    private void Eye_Contect()
    {
        // Check if the ball is being looked at
        if (_gazeAwareComponent.HasGazeFocus)
        {
            GameManager.Instance.IncreaseLife(1);
            Destroy(gameObject);
        }
    }
}
