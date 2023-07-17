using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public float SyncTest = 0, ConsistencyTest = 0, DelayTest = 0;
    public float SyncTest2 = 0, ConsistencyTest2 = 0, DelayTest2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeVariableEverySecond());
    }

    private void Update()
    {
        if (DelayTest2 != 0)
        {
            Debug.Log("Delay is "+(DelayTest2-Time.time));
        }
    }


    // Update is called once per frame
    void fixedUpdate()
    {
        if(DelayTest != 0)
        {
            DelayTest = 0;
        }
    }

    public void press()
    {
        SyncTest = (SyncTest == 0) ? 1 : 0;
        DelayTest = Time.time;
        Debug.Log("Variable value changed to: " + SyncTest);
    }

    private System.Collections.IEnumerator ChangeVariableEverySecond()
    {
        while (true)
        {
            ConsistencyTest = (ConsistencyTest == 0) ? 1 : 0;
            //Debug.Log("Variable value changed to: " + ConsistencyTest);
            yield return new WaitForSeconds(1f);
            DelayTest = 0;
        }
    }
}
