using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float health = 100;
    //Damage damage;
    Projectile projectile;
    [SerializeField] AudioClip attackerDeath;
    [SerializeField] GameObject deathVFX; 

    public void DealDamage(float damage)
    {
        health -= damage; 
        if(health <  0 )
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
       if(!deathVFX) { return; }
       GameObject deathVFXObject =  Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, 1f); 
    }
}
