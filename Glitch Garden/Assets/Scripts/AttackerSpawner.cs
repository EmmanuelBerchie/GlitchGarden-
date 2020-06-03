using System;
using System.Collections;
using UnityEngine;


public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray;

  //  GameObject attackerParent;
   // const string ATTACKER_PARENT_NAME = "Attackers";



    IEnumerator Start()
    {
        while(spawn == true)
        {
            
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker(); 
        }

      //  CreateAttackerParent();
    }

  /*  private void CreateAttackerParent()
    {
        attackerParent = GameObject.Find(ATTACKER_PARENT_NAME);
        
        if(!attackerParent)
        {
            attackerParent = new GameObject(ATTACKER_PARENT_NAME); 
        }
    }*/

    public void StopSpwaning()
    {
        spawn = false; 
    }
    private void SpawnAttacker()
    {
        // responsible for picking an attacker index from the array 
        var attackerIndex = UnityEngine.Random.Range(0, attackerPrefabArray.Length); 


        Spawn(attackerPrefabArray[attackerIndex]);
      
    }

    private void  Spawn(Attacker myAttacker)
    {
        
        Attacker newAttacker = Instantiate
                    (myAttacker, transform.position, transform.rotation)
                    as Attacker;  
        newAttacker.transform.parent = transform;
       // newAttacker.transform.parent = attackerParent.transform;
    }

    
}
