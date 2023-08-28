using System.Collections;
using System.Collections.Generic;
using Tobii.G2OM;
using UnityEngine;
using UnityEngine.UI; // Add this line to use the Button class

namespace Tobii.XR.Examples.DevTools{
    public class VR_Button_Click : MonoBehaviour , IGazeFocusable
    {
        private Button btn;
        public Image fill;
        public float timer;
        private float clicks = 0;

        // Start is called before the first frame update
        void Start()
        {
            btn = GetComponent<Button>();
        }
        
        public void GazeFocusChanged(bool hasFocus)
        {
            // If this object received focus, start the timer
            if (hasFocus)
            {
               
                
                clicks += 0.25f;
                fill.fillAmount = clicks;
                // If the timer is greater than or equal to 2 seconds, trigger the button click

                if (clicks >= 1f)
                {
                    Debug.Log("Click");
                    btn.onClick.Invoke();
                }
            }
            else
            {
               
                timer = 0f; 
            }
        }

        private void Update()
        {
            timer = +Time.deltaTime;

            if (timer >= 2f)
            {
                timer = 0;
               clicks = 0;
            }

        }

    }
}
