using System.Collections;
using UnityEngine;


public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray; 

   

    IEnumerator Start()
    {
        while(spawn == true)
        {
            
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker(); 
        }
    }

    public void StopSpwaning()
    {
        spawn = false; 
    }
    private void SpawnAttacker()
    {
        // responsible for picking an attacker index from the array 
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length); 


        Spawn(attackerPrefabArray[attackerIndex]);
      
    }

    private void  Spawn(Attacker myAttacker)
    {
        
        Attacker newAttacker = Instantiate
                    (myAttacker, transform.position, transform.rotation)
                    as Attacker;  
        newAttacker.transform.parent = transform;
    }

    
}
