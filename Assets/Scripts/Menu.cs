using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 

public class Menu : MonoBehaviour
{


    void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }


  
    
}
