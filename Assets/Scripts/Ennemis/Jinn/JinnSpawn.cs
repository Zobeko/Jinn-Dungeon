using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JinnSpawn : MonoBehaviour
{
    void Awake()
    {
        GetComponent<JinnHealth>().enabled = false;
        GetComponent<JinnAttack>().enabled = false;
        GetComponent<EnnemiMovements>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;

    }


    // Start is called before the first frame update
    void Start()
    {


        

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnBecameVisible()
    {

        GetComponent<JinnHealth>().enabled = true;
        GetComponent<JinnAttack>().enabled = true;
        GetComponent<EnnemiMovements>().enabled = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
