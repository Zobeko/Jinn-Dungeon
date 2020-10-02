using System.Collections;
using UnityEngine;
using System;

public class JinnHealth : MonoBehaviour
{
    public float endAnimhurtDelay;
    public float deathAnimDelay;


    public int healthMax = 100;
    public int currentHealth;
    public int jinnScoreValue = 50;

    private bool isDead = false;
    private bool isHurted = false;

    private static System.Random random = new System.Random();
    public PlayerAttack playerAttack;
    public PlayerScore playerScoreObject;
    public Animator jinnAnimator;
    public GameObject jinn;
    public GameObject attackPickUp;
    public GameObject heartPickUp;
    public GameObject invincibilityPickUp;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = healthMax;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (currentHealth <= 0)
        {
            
            StartCoroutine(deathAnimTime());
        }

        boolToAnimator();
    }

    private void PickUpProbabilities()
    {
        int randAttack = random.Next(1, 21);
        int randHeart = random.Next(1, 21);
        int randInvincibility = random.Next(1, 21);

        Debug.Log("randAttack : " + randAttack);
        Debug.Log("randHeart : " + randHeart);
        Debug.Log("randInvincibility : " + randInvincibility);

        //Super Attack
        if (randAttack >= 18)
        {
            
            GameObject copy = UnityEngine.Object.Instantiate(attackPickUp, GetComponent<EnnemiMovements>().checkObstacle.transform.position, attackPickUp.transform.rotation);
            copy.SetActive(true);
        }

        //Heart
        else if (randHeart >= 15)
        {
            GameObject heart = UnityEngine.Object.Instantiate(heartPickUp, GetComponent<EnnemiMovements>().checkObstacle.transform.position, heartPickUp.transform.rotation);
            heart.SetActive(true);
        }

        //Invincibility
        else if (randInvincibility >= 18)
        {
            GameObject invincibility = UnityEngine.Object.Instantiate(invincibilityPickUp, GetComponent<EnnemiMovements>().checkObstacle.transform.position, invincibilityPickUp.transform.rotation);
            invincibility.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("PlayerBullets"))
        {
            currentHealth -= playerAttack.bulletDamages;
            StartCoroutine(hurtAnimTime());
        }
    }

    private void boolToAnimator()
    {
        jinnAnimator.SetBool("_isHurted", isHurted);
        jinnAnimator.SetBool("_isDead", isDead);

    }

    private IEnumerator hurtAnimTime()
    {
        isHurted = true;
        yield return new WaitForSeconds(endAnimhurtDelay);
        isHurted = false;

    }

    private IEnumerator deathAnimTime()
    {
        isDead = true;
        yield return new WaitForSeconds(deathAnimDelay);
        isDead = false;

        PickUpProbabilities();

        Destroy(jinn);
        playerScoreObject.playerScore += jinnScoreValue;
    }
}
