using UnityEngine;
using UnityEngine.UI;

public class MoveImage : MonoBehaviour
{
    // Reference to the image component
    public Image image;

    // Target positions
    private Vector3 startPosition = new Vector3(0, 0, 0);
    private Vector3 endPosition = new Vector3(5000, 0, 0);

    // Flag to check if the image is currently moving
    private bool isMoving = false;

    public void MoveImageToTargetPosition()
    {
        if (!isMoving)
        {
            // Start moving the image
            isMoving = true;
            image.transform.position = startPosition;

        }
        else
        {
            isMoving = false;
            image.transform.position = endPosition;
        }
    }

    
}
