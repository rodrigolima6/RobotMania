using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleListScrollView : MonoBehaviour
{
    public List<string> itemsList;
    public GameObject togglePrefab;
    public Transform contentPanel;
    public Transform example;
    public Vector3 positionOffset = Vector3.zero;
    private int i = 1;

    void Start()
    {
        
        // Loop through the items list and create a toggle for each item
        foreach (string item in itemsList)
        {
            positionOffset = new Vector3(0, contentPanel.position.y + i, 0);
            // Create a new toggle from the prefab
            GameObject newToggle = Instantiate(togglePrefab) as GameObject;
            newToggle.transform.SetParent(contentPanel);
            newToggle.transform.localScale = new Vector3(1, 1, 1);
            newToggle.transform.position = positionOffset;
            i++;
            


            // Set the toggle's label to the item's name
            Text toggleLabel = newToggle.GetComponentInChildren<Text>();
            toggleLabel.text = item;

            
        }
    }
}
