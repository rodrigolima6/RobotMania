using UnityEngine;
using Tobii.Gaming;
using UnityEngine.UI;

public class TobiiEyeTrackingInteraction : MonoBehaviour
{
    public float activationTime = 1.0f; // Time the gaze should be on the button to trigger click
    private float currentActivationTime = 0.0f;
    private bool isGazeOnButton = false;
    private Button currentButton;

    private void Update()
    {
        GazePoint gazePoint = TobiiAPI.GetGazePoint();

        if (gazePoint.IsValid)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(gazePoint.Screen);

            if (Physics.Raycast(ray, out hit))
            {
                Button hitButton = hit.collider.GetComponent<Button>();

                if (hitButton != null)
                {
                    if (hitButton != currentButton)
                    {
                        currentButton = hitButton;
                        currentActivationTime = 0.0f;
                        isGazeOnButton = false;
                    }

                    currentActivationTime += Time.deltaTime;

                    if (!isGazeOnButton && currentActivationTime >= activationTime)
                    {
                        isGazeOnButton = true;
                        currentButton.onClick.Invoke(); // Simulate button click
                    }
                }
                else
                {
                    currentButton = null;
                    currentActivationTime = 0.0f;
                    isGazeOnButton = false;
                }
            }
        }
        else
        {
            currentButton = null;
            currentActivationTime = 0.0f;
            isGazeOnButton = false;
        }
    }
}
