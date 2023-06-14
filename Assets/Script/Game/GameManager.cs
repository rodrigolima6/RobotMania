using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI textMeshPro;
    public List<Sprite> Hearts_Sprite;
    public Image Hearts;
    public int playerLife = 3;
    public Bounds ScreenBounds;
    public int score = 0;

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

    // Rest of the GameManager code...
    public void DeductLife(int amount)
    {
        playerLife -= amount;
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

    private void ShowScore(int points)
    {
        textMeshPro.text = ""+points;
    }

    public void ShowLife(int life)
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
