using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float animAttackDelay;
    public float delayBetween2Attacks;
    private float specialAttackDelay = 15f;

    public int bulletDamages;
    private readonly int baseBulletDamages = 50;


    public GameObject playerBullet;
    public GameObject copyBullet;
    public Transform bulletSpawnPoint;

    public playerBulletMovement pBulletMovement;


    public bool shotSignal;
    public bool _isAttacking;
    public bool upAttack;
    public bool downAttack;
    public bool isSpecialAttack;
    public bool isAttacking
    {
        get { return _isAttacking; }
        set
        {
            _isAttacking = value;
            //Quand l'animation de tir vient de finir
            if (isAttacking == false)
            {
                copyBullet = Object.Instantiate(playerBullet, bulletSpawnPoint.transform.position, playerBullet.transform.rotation);
                
                copyBullet.SetActive(true);

                

            }
            
        }
    }


    public Animator animator;




    // Start is called before the first frame update
    void Start()
    {
        bulletDamages = baseBulletDamages;
        isSpecialAttack = false;
        //StartCoroutine(PlayerShootDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
        //isAttacking = false;

        getInputAttack();

        SpecialAttack();
        
        boolToAnimator();
        
    }

    void getInputAttack()
    {
        /*if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))){
            rightLeftAttack = true;
            StartCoroutine(PlayerShootDelay());
        }
        else */if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(PlayerShootDelay());
        }
        if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.UpArrow)) && copyBullet)
        {
            upAttack = true;
            copyBullet.GetComponent<playerBulletMovement>().upShoot = true;
            StartCoroutine(PlayerShootDelay());
            
        }
        else if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.DownArrow)) && copyBullet)
        {
            downAttack = true;
            copyBullet.GetComponent<playerBulletMovement>().downShoot = true;

           

            StartCoroutine(PlayerShootDelay());
        }
        

       

        
    }

    private void SpecialAttack()
    {
        if (isSpecialAttack)
        {
            
            StartCoroutine(SpecialAttackTime());

        }
        
    }

    void boolToAnimator()
    {
        animator.SetBool("_isAttacking", isAttacking);
        animator.SetBool("_isSpecialAttack", isSpecialAttack);
    }

    //Delais entre 2 shoots de du joueur
    public IEnumerator PlayerShootDelay()
    {

        if (!isAttacking)
        {
            //yield return new WaitForSeconds(delayBetween2Attacks);
            isAttacking = true;

            yield return new WaitForSeconds(animAttackDelay);

            isAttacking = false;

            //StopCoroutine(PlayerShootDelay());

            
        }

    }

    private IEnumerator SpecialAttackTime()
    {
        bulletDamages = 2*baseBulletDamages;
        yield return new WaitForSeconds(specialAttackDelay);
        isSpecialAttack = false;
        bulletDamages = baseBulletDamages;
    }
}
