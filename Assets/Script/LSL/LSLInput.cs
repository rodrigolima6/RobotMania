using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;
using System;

public class LSLInput : MonoBehaviour
{
    private StreamInlet inlet;
    public int channelCount = 0;


    void Start()
    {
        // Create a new LSL stream inlet
        inlet = new StreamInlet(new StreamInfo("Stream", "stream12", 3, 50, LSL.channel_format_t.cf_float32));

        if (inlet != null)
        {
            StreamInfo info = inlet.info();

            // Get the number of channels
           channelCount = info.channel_count();
            // Start a separate thread to continuously read samples
            System.Threading.Thread lslThread = new System.Threading.Thread(ReadSamples);
            lslThread.Start();
        }
        else
        {
            Debug.LogError("No streams found!");
        }
    }

    void ReadSamples()
    {
        while (true)
        {
            // Read a sample from the inlet
            float[] sample = new float[channelCount];
            double timestamp = 0;
            inlet.pull_sample(sample, 9);

            // Process the sample data here
            // ...

            Debug.Log("Sample received: " + string.Join(", ", sample));
        }
    }
}
