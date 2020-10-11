using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

    private float endAnimDeathDelay;
    private float currentPlayerHealth;
    [SerializeField] private float respawnDelay;


    [SerializeField] private GameObject player;
    [SerializeField] private HealthBar playerHealthBar;

    //private readonly HealthBar playerHealthBar;
    // Start is called before the first frame update
    void Awake()
    {
        
        
        endAnimDeathDelay = player.GetComponent<HealthBar>().endAnimDeathDelay;


    }

    void Start()
    {
        player.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //currentPlayerHealth = player.GetComponent<HealthBar>().currentHealth;

        if (playerHealthBar.isDead)
        {

            StartCoroutine(Respawn());
            

        }

    }



    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(endAnimDeathDelay);
        player.SetActive(false);
        player.transform.position = this.transform.position;
        yield return new WaitForSeconds(respawnDelay);
        if (playerHealthBar.nbOfLives > 0)
        {
            player.SetActive(true);
            playerHealthBar.isDead = false;
        }


    }

}
