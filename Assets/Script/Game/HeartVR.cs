
using System.Collections;
using System.Collections.Generic;
using Tobii.G2OM;
using UnityEngine;

namespace Tobii.XR.Examples.DevTools{

    public class HeartVR : MonoBehaviour , IGazeFocusable
    {


        public List<Sprite> spriteList;

        private SpriteRenderer spriteRenderer;
        public float growthRate = 0.1f;
        private float maxScale = 2.2f;

        private float startTime;
        private float elapsedTime = 0;
        private int currentIndex = 0;

        private void Start()
        {
            
            spriteRenderer = GetComponent<SpriteRenderer>();
       

            startTime = Time.time;
        }

        public void GazeFocusChanged(bool hasFocus)
        {
            //If this object received focus, fade the object's color to highlight color
            if (hasFocus)
            {
                GameManager.Instance.IncreaseLife(1);
                Destroy(gameObject);
            }
        }

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
}