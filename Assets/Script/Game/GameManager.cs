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
    public float ballSpeed = 0.0f;
    public float ballSpawnRate = 0.0f; 
    public float lifeSpawnRate = 0.0f;

    public static float SballSpeed = 0.0f;
    public static float SballSpawnRate = 0.0f;
    public static float SlifeSpawnRate = 0.0f;


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
            UniversalFunctions.ChangeScene("Menu");
        }
    }

    private void FixedUpdate()
    {
            SballSpeed = ballSpeed;
            SballSpawnRate = ballSpawnRate;
            SlifeSpawnRate = SlifeSpawnRate;
    }

public Bounds getScreenBounds()
    {
        return ScreenBounds;
    }

    // Rest of the GameManager code...
    public void DeductLife(int amount)
    {
        //playerLife -= amount;
        // Add your desired logic when the player loses a life (e.g., game over screen, restart level, etc.)
        Debug.Log("Player life: " + playerLife);

        ShowLife(playerLife);

        if (playerLife <= 0)
        {
            UniversalFunctions.ChangeScene("Menu");
        }
    }

    public void IncreaseLife(int amount)
    {
        playerLife += amount;
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
