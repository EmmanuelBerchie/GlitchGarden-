using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    Attacker attacker; 

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //identifying other collider
        GameObject otherObject = otherCollider.gameObject;    

        if(otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
