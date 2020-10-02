using UnityEngine;
using System.Collections;

public class playerBulletMovement : MonoBehaviour
{
    public float speed;
    public float endAnimDelay;

    public bool endTime = false;
    public bool upShoot = false;
    public bool downShoot = false;


    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public GameObject player;
    public GameObject bullet;
    public Transform shotSpawnPointLeftRight;
    public Animator animator;


    public PlayerAttack playerAttack;
    public AudioClip explosionAudioClip;

    private Vector3 vref = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        upShoot = false;
        downShoot = false;

        bulletPosition();

        //beginningAnimTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, bullet.transform.position) > 2)
        {
            upShoot = false;
            downShoot = false;
        }

        




        BoolToAnimator();

    }

    void FixedUpdate()
    {
        bulletShot();
    }


    private void bulletPosition()
    {
        //Change la direction du missile en fonction de la direction de player
        sr.flipX = player.GetComponent<SpriteRenderer>().flipX;

        //Place le sprite sur le point de spawn des balles
        transform.position = shotSpawnPointLeftRight.transform.position;
    }

    private void bulletShot()
    {
        //Attaques gauche et droite
        if (!sr.flipX && !endTime)
        {
            rb.velocity = Vector3.SmoothDamp(rb.velocity, Vector3.right * speed * Time.deltaTime, ref vref, 0f);
        }
        else if(sr.flipX && !endTime)
        {
            rb.velocity = Vector3.SmoothDamp(rb.velocity, Vector3.left * speed * Time.deltaTime, ref vref, 0f);

        }

        //Attaque haut
        if (upShoot)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 45);
            bullet.transform.rotation = rotation;
            rb.gravityScale = -50;
        }
        else if (downShoot)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, -45);
            bullet.transform.rotation = rotation;
            rb.gravityScale = 50;
        }

        
    }


    private void OnCollisionEnter2D(Collision2D col)
    {

        StartCoroutine("endAnimTime");
    }

    private void BoolToAnimator()
    {
        animator.SetBool("_endTime", endTime);
        animator.SetBool("_isSpecialBullet", player.GetComponent<PlayerAttack>().isSpecialAttack);
    }


    private IEnumerator endAnimTime()
    {
        
        endTime = true;
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        //On ajoute le son d'explosion du projectile
        AudioManager.instance.PlayClipAt(explosionAudioClip, transform.position);


        yield return new WaitForSeconds(endAnimDelay);
        endTime = false;
        if (bullet != null && bullet.name == "PlayerBullet(Clone)")
        {
            Destroy(bullet);
        }
    }

}
