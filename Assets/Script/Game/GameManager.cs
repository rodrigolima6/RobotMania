using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private List<Sprite> Hearts_Sprite;
    [SerializeField] private Image Hearts;
    private Bounds ScreenBounds;

    //Inputs
    public float playerLife = 3;
    public float score = 0;
    public float time = 0.0f;

    //Outputs
    public float ballSpeed = 10.0f;
    public float ballSpawnRate = 4.0f; 
    public float lifeSpawnRate = 8.0f;

    //Outputs global variables
    public static float SscorePsecond = 0f;
    public static float SLifePsecond = 0f;
    public static float SReflexes = 0f;

    public static float SplayerLife = 10.0f;
    public static float Sscore = 4.0f;
    public static float Stime = 8.0f;

    public static float SballSpeed = 10.0f;
    public static float SballSpawnRate = 4.0f;
    public static float SlifeSpawnRate = 8.0f;

    //tools 
    private float ten_second = 0;
    private float one_second = 0;
    private float last_score = 0;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        // Calculate the screen bounds
        float screenAspect = (float)Screen.width / Screen.height;
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * screenAspect;

        ScreenBounds = new Bounds(Camera.main.transform.position, new Vector3(cameraWidth * 2, cameraHeight * 2, 0f));
    }

    private void Update()
    {
        if (TimeChecker.HasFiveMinutesPassed())
        {
            
            UniversalFunctions.ChangeScene("Menu 1");
        }
    }

    private void FixedUpdate()
    {
            SballSpeed = ballSpeed;
            SballSpawnRate = ballSpawnRate;
            SlifeSpawnRate = lifeSpawnRate;
            
            time = 300-TimeChecker.elapsedTime;
            if (TimeChecker.elapsedTime-one_second >= 2){
                SscorePsecond = ((score - last_score) + SscorePsecond) / 2;
                SLifePsecond = (playerLife + SLifePsecond) / 2;
                last_score = score;
                one_second = TimeChecker.elapsedTime;
            }
            
            SplayerLife = playerLife;
            Sscore = score;
            Stime = time;

        //Debug.Log("ballSpeed = " + ballSpeed + "=" + SballSpeed);
        //Debug.Log("ballSpawnRate = " + ballSpawnRate + "=" + SballSpawnRate);
        //Debug.Log("lifeSpawnRate = " + lifeSpawnRate + "=" + SlifeSpawnRate);
    }

    public static void Set_Reflexes(float reflex)
    {
        if (SReflexes==0)
        {
            SReflexes = reflex;
            return;
        }
        SReflexes = (reflex + SReflexes) / 2;
       
    }


    public Bounds getScreenBounds()
        {
            return ScreenBounds;
        }

    // Rest of the GameManager code...
    public void DeductLife(int amount)
    {
        playerLife -= amount;
        // Add your desired logic when the player loses a life (e.g., game over screen, restart level, etc.)
        //Debug.Log("Player life: " + playerLife);

        

        if (playerLife <= 0)
        {
            playerLife = 1;
            //UniversalFunctions.ChangeScene("Menu 1"); 
        }
        ShowLife(playerLife);
    }

    public void IncreaseLife(int amount)
    {
        if (playerLife!=3)
        {
            playerLife += amount;
        }
        
        // Add your desired logic when the player loses a life (e.g., game over screen, restart level, etc.)
        Debug.Log("Player life: " + playerLife);

        ShowLife(playerLife);
    }

    public void IncreaseScore(int points)
    {
        score += points;
        ShowScore(score);
    }

    private void ShowScore(float points)
    {
        textMeshPro.text = ""+points;
    }

    public void ShowLife(float life)
    {
        switch (life)
        {
            case 0:
                Hearts.sprite = Hearts_Sprite[0];
                break;
            case 1:
                Hearts.sprite = Hearts_Sprite[1];
                break;
            case 2:
                Hearts.sprite = Hearts_Sprite[2];
                break;
            default:
                Hearts.sprite = Hearts_Sprite[3];
                break;
        }

    }

}
