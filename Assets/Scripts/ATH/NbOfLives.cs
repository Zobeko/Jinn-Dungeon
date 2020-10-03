using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NbOfLives : MonoBehaviour
{

    [SerializeField] private HealthBar playerHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealthBar.nbOfLives == 3)
        {
            transform.gameObject.GetComponent<Text>().text = "3";
        }
        else if (playerHealthBar.nbOfLives == 2)
        {
            transform.gameObject.GetComponent<Text>().text = "2";
        }
        else if (playerHealthBar.nbOfLives == 1)
        {
            transform.gameObject.GetComponent<Text>().text = "1";
        }
        else if (playerHealthBar.nbOfLives == 0)
        {
            transform.gameObject.GetComponent<Text>().text = "0";
        }
    }
}
