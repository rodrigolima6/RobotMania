using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionaireController : MonoBehaviour
{
    // Reference to the image component
    public Image image;
    private Vector3 endPosition = new Vector3(6000, 0, 0);

    // Flag to check if the image is currently moving
    private bool isMoving = false;
    private float questionTimers = 1;

    //LSL Streams 
    [SerializeField] private LSLStreamer Streamer;

    private int FocusLevel = 3;

    private void Start()
    {
        Streamer.StartStream();
    }

    private void FixedUpdate()
    {
        if (TimeChecker.elapsedTime - questionTimers >= 60)
        {
            questionTimers = TimeChecker.elapsedTime;
            MoveImageToTargetPosition();
        }
        float[] dataSent = new float[1];
        dataSent[0] = FocusLevel;
        Streamer.StreamData(dataSent);


    }

    public void MoveImageToTargetPosition()
    {
        if (!isMoving)
        {
            // Start moving the image
            isMoving = true;
            image.transform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
            Time.timeScale = 0;

        }
        else
        {
            isMoving = false;
            Time.timeScale = 1;
            image.transform.position = endPosition;
        }
    }

    public void Focus_Input(int i)
    {
        FocusLevel = i;
        isMoving = true;
        MoveImageToTargetPosition();
    } 
}
