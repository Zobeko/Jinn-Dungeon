using System.Collections;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float speed;
    public float endAnimDelay;

    public bool endTime = false;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public GameObject ennemi;
    public GameObject bullet;
    public Transform shotSpawPoint;
    public Animator animator;

    public AudioClip explosionAudioClip;


    public JinnAttack jinnAttack;



    private Vector3 vref = Vector3.zero;



    // Start is called before the first frame update
    void Start()
    {

        bulletPosition();

        //beginningAnimTime();
    }

    // Update is called once per frame
    void Update()
    {

        

        bulletShot();

        BoolToAnimator();

    }


    private void bulletPosition()
    {
        //Change la direction du missile en fonction de la direction de l'ennemi
        sr.flipX = ennemi.GetComponent<SpriteRenderer>().flipX;

        //Place le sprite sur le point de spawn des balles
        transform.position = shotSpawPoint.transform.position;
    }

    private void bulletShot()
    {
        if (sr.flipX == false)
        {
            rb.velocity = Vector3.SmoothDamp(rb.velocity, Vector3.right * speed * Time.deltaTime, ref vref, 0f);
            //GetComponent<Transform>().Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector3.SmoothDamp(rb.velocity, Vector3.left * speed * Time.deltaTime, ref vref, 0f);
            //GetComponent<Transform>().Translate(Vector3.left * speed * Time.deltaTime);
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        
        StartCoroutine("endAnimTime");
    }

    private void BoolToAnimator()
    {
        animator.SetBool("endTIme", endTime);
    }


    private IEnumerator endAnimTime()
    {
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        endTime = true;

        //On ajoute le son de d'explosion du projectile
        AudioManager.instance.PlayClipAt(explosionAudioClip, transform.position);
        

        yield return new WaitForSeconds(endAnimDelay);
        endTime = false;
        if (bullet != null && bullet.name == "JinnBullet(Clone)")
        {
            Destroy(bullet);
        }
    }
    
}
