using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker attackerPrefab; 

   

    IEnumerator Start()
    {
        while(spawn == true)
        {
            
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker(); 
        }
    }

    private void SpawnAttacker()
    {
       Attacker newAttacker =  Instantiate
            (attackerPrefab, transform.position, transform.rotation)
            as Attacker;
        //show the position of the attackers 
       // allows us to spawn a new attacker as a child to the game object which instantiated it
        newAttacker.transform.parent = transform; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
