using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>(); 
        if(!costText)
        {
            Debug.LogError(name + " has no cost text, add some");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString(); 
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(65, 64, 64, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        // calling class defender spawner so that when the button is clicked the right prefab is shown
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
