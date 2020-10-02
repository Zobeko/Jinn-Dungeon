using System.Collections;
using UnityEngine;

public class JinnAttack : MonoBehaviour
{
    public float jinnDamages;
    public float animAttackDelay;
    public float delayBetween2Attacks;

    public bool isAlive = true;
    public bool shotSignal;
    public bool _isAttacking;
    public bool isAttacking
    {
        get { return _isAttacking; }
        set
        {
            _isAttacking = value;
            //Quand l'animation de tir vient de finir
            if (isAttacking == false)
            {
                GameObject copy = Object.Instantiate(jinnBullet, bulletSpawnPoint.transform.position, jinnBullet.transform.rotation);
                copy.SetActive(true);

            }
            
        }
    }
            


    public Animator animator;
    public SpriteRenderer sr;
    public GameObject jinnBullet;
    public GameObject bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (enabled)
        {
            StartCoroutine("ShootDelay");
        }
    }

    // Update is called once per frame
    void Update()
    {


        BoolToAnimator();

        //Attack();

    }



    //Envoie isAttacking à l'animator de l'ennemi
    private void BoolToAnimator()
    {
        animator.SetBool("_isAttacking", isAttacking);
    }

    //Delais entre 2 shoots de l'ennemi
    public IEnumerator ShootDelay()
    {

        while (isAlive)
        {
            isAttacking = true;
 

            yield return new WaitForSeconds(animAttackDelay);
            isAttacking = false;
         
            yield return new WaitForSeconds(delayBetween2Attacks);
        }
    }
}
