using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonCheckCollision : MonoBehaviour
{
    

    public bool isOnCollisionWithPlayer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

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
