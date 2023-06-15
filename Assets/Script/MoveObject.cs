using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Reference to the game object
    public GameObject gameObject;

    // Target positions
    private Vector3 startPosition = new Vector3(3, 0, 0);
    private Vector3 endPosition = new Vector3(10, 0, 0);

    // Flag to check if the object is currently moving
    private bool isMoving = true;

    //Flag to determine which movement is correct
    private bool on_off = true;

    // Total time to move the object from start to end position
    private float totalTime = 1f;

    // Current time elapsed during the movement
    private float currentTime = 0f;

    // Function to move the object from start to end position
    public void MoveObjectToTargetPosition()
    {
        if (!isMoving)
        {
            // Start moving the object
            isMoving = true;

            if (on_off) {
                on_off = false;
                // Set the object's position to the start position
                gameObject.transform.position = startPosition;
            }
            else
            {
                on_off = true;
                // Set the object's position to the start position
                gameObject.transform.position = endPosition;
            }

            // Set the current time to zero
            currentTime = 0f;
        }

    }


    private void Start()
    {
        gameObject.transform.position = endPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the object is currently moving
        if (isMoving)
        {
            Vector3 newPosition;
            // Calculate the new position of the object based on the current time
            float t = currentTime / totalTime;
            if (on_off) { 
                newPosition = Vector3.Lerp(startPosition, endPosition, t);
            }
            else
            {
                newPosition = Vector3.Lerp(endPosition,startPosition, t);
            }
            // Set the object's position to the new position
            gameObject.transform.position = newPosition;

            // Update the current time
            currentTime += Time.deltaTime;

            // Check if the movement is completed
            if (currentTime >= totalTime)
            {
                // Set the flag to false since the object is not moving anymore
                isMoving = false;
            }
        }
    }
}
