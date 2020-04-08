using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    //[SerializeField] GameObject CoreGameArea;
        Defender defender;


    private void OnMouseDown()
    {
        //Debug.Log("area clicked");
        AttemptToPlaceDefenderAt( GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        //Pass in defender as the argueement defenderToSelect, so that it can be used in other classes (DefenderButton)
        defender = defenderToSelect; 
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost(); 
        // if we have enough stars 
        if(StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
            
    }

    private Vector2 GetSquareClicked()
    {
        // initialising clickPos as the positions of the mouse 
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //clickPos = worldPos using screen to world point to display the world space of the defender pos.
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        //  converting worldPos to the rounded integer grid position (snaptoGrid)
        Vector2 gridPos = SnapToGrid(worldPos); 
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
    private void SpawnDefender(Vector2 roundedPos)
    {
     
     Defender newDefender =  Instantiate(defender, roundedPos, 
          Quaternion.identity) as Defender;
    }
}
