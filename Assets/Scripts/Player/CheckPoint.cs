using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool isActivated;

    private GameObject playerSpawn;
    private Animator graphicAnimator;

    public AudioClip checkpointSound;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn");
        isActivated = false;
        graphicAnimator = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        graphicAnimator.SetBool("_isActivated", isActivated);
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //Player spawn se place à l'endroit du chackpoint
            playerSpawn.transform.position = transform.position;

            //On ajout l'audio de l'activation du checkpoint
            AudioManager.instance.PlayClipAt(checkpointSound, transform.position);

            //Pour afficher etoile quand activé
            isActivated = true;

            //Pour que le checkpoint ne puisse pas etre réactivé une fois passé
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

    }
}
