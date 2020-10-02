using UnityEngine;

public class AttackPickUp : MonoBehaviour
{
    private GameObject player;

    public AudioClip pickUpSound;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            player.GetComponent<PlayerAttack>().isSpecialAttack = true;

            //On ajoute le son de ramassage de pickUp
            AudioManager.instance.PlayClipAt(pickUpSound, transform.position);

            Destroy(transform.gameObject);
        }
    }

    
}
