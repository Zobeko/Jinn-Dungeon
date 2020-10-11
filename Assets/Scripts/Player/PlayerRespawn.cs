using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

    private float endAnimDeathDelay;
    private float currentPlayerHealth;
    [SerializeField] private float respawnDelay;


    private GameObject player;

    //private readonly HealthBar playerHealthBar;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        
        endAnimDeathDelay = player.GetComponent<HealthBar>().endAnimDeathDelay;


    }

    void Start()
    {
        player.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayerHealth = player.GetComponent<HealthBar>().currentHealth;

        if (currentPlayerHealth <= 0)
        {

            StartCoroutine(Respawn());
            

        }

        

        
        
        



    }



    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(endAnimDeathDelay);
        player.SetActive(false);
        player.transform.position = transform.position;
        yield return new WaitForSeconds(respawnDelay);
        if (player.GetComponent<HealthBar>().nbOfLives > 0)
        {
            player.SetActive(true);
            player.GetComponent<HealthBar>().isDead = false;
        }


    }

}
