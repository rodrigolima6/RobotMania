using System.Collections;
using UnityEngine;

public class LightColorChange : MonoBehaviour
{
    public Light lightComponent;
    public float colorChangeDuration = 2.0f; // Duration of each color change
    private Color startColor = Color.red;
    private Color endColor = Color.black;

    private void Start()
    {
        lightComponent = GetComponent<Light>();
        // Initialize the light color to red
        lightComponent.color = startColor;

        // Start the color change loop
        StartCoroutine(ChangeLightColor());
    }

    private IEnumerator ChangeLightColor()
    {
        while (true)
        {
            // Change the light color from red to black
            yield return ChangeColor(startColor, endColor, colorChangeDuration);

            // Change the light color from black to red
            yield return ChangeColor(endColor, startColor, colorChangeDuration);
        }
    }

    private IEnumerator ChangeColor(Color fromColor, Color toColor, float duration)
    {
        float startTime = Time.time;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            lightComponent.color = Color.Lerp(fromColor, toColor, t);
            elapsedTime = Time.time - startTime;
            yield return null;
        }

        // Ensure the final color is set
        lightComponent.color = toColor;
    }
}
