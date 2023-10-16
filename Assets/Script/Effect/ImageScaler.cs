using UnityEngine;
using UnityEngine.UI;

public class ImageScaler : MonoBehaviour
{
    public Image image;
    public static float scaleMultiplier = 0.9f;
    public float _scaleMultiplier = 0.9f;

    public float speed = 0.2f;

    public float _max = 0.9f;
    public float _min = 0.5F;

    Vector3 newScale = new Vector3();

    private float timeElapsed;

    private void Update()
    {
        // Update the time elapsed

        if (scaleMultiplier != Mathf.Round(_scaleMultiplier))
        {
            timeElapsed = 0;
            float realScale = ((1 - Mathf.Abs(scaleMultiplier)) * (_max - _min)) + _min;
            if (_max < realScale)
            {
                realScale = 0.9f;
            }
            else if (_min > realScale)
            {
                realScale = 0.5f;
            }
            newScale = new Vector3(realScale, realScale, 1f);

            scaleMultiplier = Mathf.Round(_scaleMultiplier);
        }

        timeElapsed += Time.deltaTime;
        //float realScale = (scaleMultiplier * (_max - _min)) + _min;
        Vector3 scale_Now = newScale - image.transform.localScale;

        scale_Now.Normalize();

        if (Mathf.Abs(scale_Now.x) > 0.1f)
        {
            // Apply the scale to the image transform
            image.transform.localScale += scale_Now * speed * Time.deltaTime;
        }
        else
        {
            image.transform.localScale = newScale;
        }
    }
}