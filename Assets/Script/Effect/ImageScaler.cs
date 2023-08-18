using UnityEngine;
using UnityEngine.UI;

public class ImageScaler : MonoBehaviour
{
    public Image image;
    public static float scaleMultiplier = 0.9f;
    public float _max = 0.9f;
    public float _min = 0.5f;


    private void Update()
    {
        float realScale = (scaleMultiplier * (_max - _min)) + _min;

        if (_max < realScale)
        {
            realScale = 0.9f;
        }
        else if(_min > realScale)
        {
            realScale = 0.5f;
        }
        
        // Apply the scale to the image transform
        image.transform.localScale = new Vector3(realScale, realScale, 1f);
    }
}