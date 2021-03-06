﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Using findObjectOfType instead of getComponent 
        //because for an object not attained to this class or scene
       FindObjectOfType<LivesDisplay>().TakeLife();
        Destroy(otherCollider.gameObject);
    }
}
