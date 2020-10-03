using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonCheckCollision : MonoBehaviour
{
    

    public bool isOnCollisionWithPlayer;



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            isOnCollisionWithPlayer = true;
        }
        
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            isOnCollisionWithPlayer = false;
        }


    }
}
