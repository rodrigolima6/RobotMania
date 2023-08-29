using System.Collections;
using System.Collections.Generic;
using Tobii.G2OM;
using UnityEngine;
using UnityEngine.UI; // Add this line to use the Button class

namespace Tobii.XR.Examples.DevTools{
    public class VR_Button_Click : MonoBehaviour , IGazeFocusable
    {
        private Button btn;
        private VR_button_Controller controller;
        public Image fill;
        public float timer;
        public float clicks = 0;

        // Start is called before the first frame update
        void Start()
        {
            btn = GetComponent<Button>();
            controller=GameObject.FindWithTag("BtnController").GetComponent<VR_button_Controller>();
        }
        
        public void GazeFocusChanged(bool hasFocus)
        {
            // If this object received focus, start the timer
            if (hasFocus)
            {
                clicks += 0.25f;
                fill.fillAmount = clicks;

                controller.Btn_Was_Click(this);
                
                if (clicks >= 1f)
                {
                    Debug.Log("Click");
                    btn.onClick.Invoke();
                    controller.ClearClicks();
                }
            }
           
            
        }


    }
}
