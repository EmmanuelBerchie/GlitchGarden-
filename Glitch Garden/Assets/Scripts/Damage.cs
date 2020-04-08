using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    int damage = 150; 

    public int damageDealer()
    {
        return damage; 
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
