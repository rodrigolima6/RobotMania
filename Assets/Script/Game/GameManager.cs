using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private TextMeshProUGUI Timer;
    [SerializeField] private List<Sprite> Hearts_Sprite;
    [SerializeField] private Image Hearts;
    [SerializeField] private List<Sprite> Arrows_Sprite;
    [SerializeField] private Image Arrows;
    [SerializeField] private TextMeshProUGUI HeartRate;
    
    private Bounds ScreenBounds;

    //Inputs
    private float playerLife = 3;
    private float score = 0;
    private float time = 0.0f;

    [SerializeField] private bool[] ballsucess = new bool[10];
    [SerializeField] private LSLOutput Output;

    public float ErrorRate = 0f;

    public float ScorePsecond = 0f;
    public float LifePsecond = 0f;
    public float ReactTime = 0f;
    //Outputs
    public float ballSpeed = 10.0f;
    public float ballSpawnRate = 4.0f;
    public float lifeSpawnRate = 8.0f;
    public float circleFade = 0.9f; 
    public float HR = 0.0f;


    //Outputs global variables
    public static float SscorePsecond = 0f;
    public static float SLifePsecond = 0f;
    public static float SReactTime = 0f;

    public static float SplayerLife = 10.0f;
    public static float Sscore = 4.0f;
    public static float Stime = 8.0f;

    public static float SballSpeed = 10.0f;
    public static float SballSpawnRate = 4.0f;
    public static float SlifeSpawnRate = 8.0f;

    //tools 

    private float one_second = 0;
    private float last_score = 0;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        ImageScaler.scaleMultiplier = circleFade;

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

            UniversalFunctions.ChangeScene("MenuVR2");
        }
    }

    private void FixedUpdate()
    {
        SballSpeed = ballSpeed;
        SballSpawnRate = ballSpawnRate;
        SlifeSpawnRate = lifeSpawnRate;

        ImageScaler.scaleMultiplier = circleFade;

        time = 300 - TimeChecker.elapsedTime;

        if (TimeChecker.elapsedTime - one_second >= 1)
        {
            SscorePsecond = ((score - last_score) + SscorePsecond) / 2;
            SLifePsecond = (playerLife + SLifePsecond) / 2;
            last_score = score;
            one_second = TimeChecker.elapsedTime;
        }
        
        if (circleFade>0)
        {
            Arrows.sprite = Arrows_Sprite[1];
        }
        else if (circleFade < 0)
        {
            Arrows.sprite = Arrows_Sprite[2];
        }
        else
        {
           // Debug.Log("bom");
            Arrows.sprite = Arrows_Sprite[0];
        }

        Timer.text = "" + (int)time;
        HeartRate.text = "" + HR.ToString("F1");
        ReactTime = SReactTime;
        ScorePsecond = SscorePsecond;
        LifePsecond = SLifePsecond;

        SplayerLife = playerLife;
        Sscore = score;
        Stime = time;
    }

    public static void Set_Reflexes(float reflex)
    {
        if (SReactTime == 0)
        {
            SReactTime = reflex;
            return;
        }
        SReactTime = (reflex + SReactTime) / 2;

    }

    public Bounds getScreenBounds()
    {
        return ScreenBounds;
    }

    
    public void DeductLife(int amount)
    {
        playerLife -= amount;
        // Add your desired logic when the player loses a life (e.g., game over screen, restart level, etc.)
        //Debug.Log("Player life: " + playerLife);
        Remove_Add(false);

        if (playerLife <= 0)
        {
            playerLife = 1;
            //UniversalFunctions.ChangeScene("Menu 1"); 
        }
        Output.SendData();
        ShowLife(playerLife);
    }

    public void IncreaseLife(int amount)
    {
        if (playerLife != 3)
        {
            playerLife += amount;
        }

        // Add your desired logic when the player loses a life (e.g., game over screen, restart level, etc.)
        Debug.Log("Player life: " + playerLife);
        ShowLife(playerLife);

    }

    public void IncreaseScore(int points)
    {
        Remove_Add(true);
        score += points;
        ShowScore(score);
        Output.SendData();
    }

    private void ShowScore(float points)
    {
        textMeshPro.text = "" + points;
    }

    private void Remove_Add(bool value)
    {
        int i = 0;
        float percentage = 0;
        bool[] temp_array = new bool[10];

        foreach (bool success in ballsucess)
        {
            if (i != ballsucess.Length - 1)
            {
                temp_array[i + 1] = success;
            }
            if (success)
            {
                percentage++;
            }
            i++;
        }

        temp_array[0] = value;
        ballsucess = temp_array;
        ErrorRate = (10 - percentage) / 10;
        
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
