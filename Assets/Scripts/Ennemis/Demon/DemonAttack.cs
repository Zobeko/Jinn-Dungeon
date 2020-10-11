using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAttack : MonoBehaviour
{
    [SerializeField] private float demonDamages;
    [SerializeField] private float animAttackDelay;
    [SerializeField] private float delayBetween2Attacks;

    [SerializeField] private bool isOnCollisionWithPlayer;

    private bool _isAttacking;
    public bool isAttacking
    {
        get { return _isAttacking; }
        set
        {
            _isAttacking = value;
            //Quand l'animation de tir vient de finir
            if (isAttacking == false && isOnCollisionWithPlayer)
            {
                player.GetComponent<HealthBar>().currentHealth -= demonDamages;

            }

        }
    }



    public AudioClip attackSound;
    public Animator animator;
    public SpriteRenderer sr;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        if (enabled)
        {
            StartCoroutine("ShootDelay");
        }
    }

    // Update is called once per frame
    void Update()
    {
        isOnCollisionWithPlayer = transform.GetChild(2).gameObject.GetComponent<DemonCheckCollision>().isOnCollisionWithPlayer;

        BoolToAnimator();


    }

    /*private void OnTriggerStay2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            isOnCollisionWithPlayer = true;
        }
        else
        {
            isOnCollisionWithPlayer = false;
        }
    }*/



    //Envoie isAttacking à l'animator de l'ennemi
    private void BoolToAnimator()
    {
        animator.SetBool("_isAttacking", isAttacking);
    }

    //Delais entre 2 shoots de l'ennemi
    public IEnumerator ShootDelay()
    {
        while (true)
        {
            isAttacking = true;

            //Son de l'attaque
            AudioManager.instance.PlayClipAt(attackSound, transform.position);

            yield return new WaitForSeconds(animAttackDelay);
            isAttacking = false;

            yield return new WaitForSeconds(delayBetween2Attacks);
        }
    }
}
