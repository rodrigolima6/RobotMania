using UnityEngine;
using UnityEngine.UI;

public class ImageScaler : MonoBehaviour
{
    // Reference to the image component
    public Image image;

    // Static variable to control the scale multiplier
    public static float scaleMultiplier = 0.9f;

    // Variable to control the scale multiplier (visible in the Inspector)
    public float _scaleMultiplier = 0.9f;

    // Speed at which the image scales
    public float speed = 0.2f;

    // Maximum scale value
    public float _max = 0.9f;

    // Minimum scale value
    public float _min = 0.5F;

    // Variable to store the new scale
    Vector3 newScale = new Vector3();

    // Variable to track time elapsed
    private float timeElapsed;

    private void Update()
    {
        // Update the time elapsed

        // If the scale multiplier has changed, reset time elapsed and calculate real scale
        if (scaleMultiplier != Mathf.Round(_scaleMultiplier))
        {
            timeElapsed = 0;
            float realScale = ((1 - Mathf.Abs(scaleMultiplier)) * (_max - _min)) + _min;
            // Ensure real scale stays within bounds
            if (_max < realScale)
            {
                realScale = 0.9f;
            }
            else if (_min > realScale)
            {
                realScale = 0.5f;
            }
            // Set the new scale
            newScale = new Vector3(realScale, realScale, 1f);

            // Update the scale multiplier
            scaleMultiplier = Mathf.Round(_scaleMultiplier);
        }

        // Update time elapsed
        timeElapsed += Time.deltaTime;

        // Calculate the difference in scale between current and target scale
        Vector3 scale_Now = newScale - image.transform.localScale;

        // Normalize the scale difference vector
        scale_Now.Normalize();

        // If the scale difference is significant
        if (Mathf.Abs(scale_Now.x) > 0.1f)
        {
            // Apply the scaled difference to the image transform with speed
            image.transform.localScale += scale_Now * speed * Time.deltaTime;
        }
        else
        {
            // If the scale difference is small, set the scale to the target scale
            image.transform.localScale = newScale;
        }
    }
}
