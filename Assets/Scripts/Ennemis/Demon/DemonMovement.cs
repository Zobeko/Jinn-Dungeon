using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DemonMovement : MonoBehaviour
{
    //Bolléens
    [SerializeField] private bool isOnPlatform = true;
    [SerializeField] private bool isInFrontOfObstacle = false;
    private bool _isFlipping;
    [SerializeField] private bool isFlipping
    {
        get { return _isFlipping; }
        set
        {
            if (sr.flipX == true)
            {
                checkOnPlatform.position -= new Vector3(ennemiWidth / 2, 0f, 0f);
                checkObstacle.position -= new Vector3(ennemiWidth / 4, 0f, 0f);
                checkCollisionAttack.position -= new Vector3(ennemiWidth / 2, 0f, 0f);



            }
            else
            {
                checkOnPlatform.position += new Vector3(ennemiWidth / 2, 0f, 0f);
                checkObstacle.position += new Vector3(ennemiWidth / 4, 0f, 0f);
                checkCollisionAttack.position += new Vector3(ennemiWidth / 2, 0f, 0f);

            }

            _isFlipping = value;
        }
    }

    //Flottants
    public float checkOnPlatformRadius;
    public float checkObstacleRadius;
    private float ennemiWidth;
    private float checkObstacleDistance;
    private float checkOnPlatformDistance;
    private float demonCurrentHealth;


    //Vectors
    private Vector3 vref = Vector3.zero;

    // Extern objects
    private GameObject player;
    public LayerMask layerMaskEnnemis;

    //Les empties qui permettent de checker les obstacles et fin de plateforme
    public Transform checkOnPlatform;
    public Transform checkObstacle;
    public Transform checkCollisionAttack;

    //Ennemi's components
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public Vector3 ennemiSpeed;
    //public HealthBar demonHealthBar;


    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        ennemiWidth = transform.GetComponent<SpriteRenderer>().bounds.max.x - transform.GetComponent<SpriteRenderer>().bounds.min.x;

        //checkObstacleDistance = Vector3.Distance(checkObstacle.position, transform.position);
        //checkOnPlatformDistance = Vector3.Distance(checkOnPlatform.position, transform.position);

        EnnemiFlipStart();



    }

    // Update is called once per frame
    void Update()
    {
        demonCurrentHealth = GetComponent<DemonHealth>().currentHealth;
        




    }

    void FixedUpdate()
    {

        //isOnPlatform = true uniquement si il y a encore du sol (une plateforme) devant l'ennemi
        isOnPlatform = Physics2D.OverlapCircle(checkOnPlatform.position, checkOnPlatformRadius, layerMaskEnnemis);

        isInFrontOfObstacle = Physics2D.OverlapCircle(checkObstacle.position, checkObstacleRadius, layerMaskEnnemis);

        EnnemiMove();

    }

    private void EnnemiFlipStart()
    {
        if (player.transform.position.x > transform.position.x && sr.flipX == true)
        {
            sr.flipX = false;
            isFlipping = false;


        }
        if (player.transform.position.x <= transform.position.x && sr.flipX == false)
        {
            sr.flipX = true;
            isFlipping = true;



        }
    }

    private void EnnemiMove()
    {
        if (isOnPlatform == true && isInFrontOfObstacle == false && sr.flipX == false && (demonCurrentHealth > 0))
        {

            rb.velocity = Vector3.SmoothDamp(rb.velocity, ennemiSpeed * Time.deltaTime, ref vref, 0f);
        }
        else if (isOnPlatform == true && isInFrontOfObstacle == false && sr.flipX == true && (demonCurrentHealth > 0))
        {

            rb.velocity = Vector3.SmoothDamp(rb.velocity, -ennemiSpeed * Time.deltaTime, ref vref, 0f);

        }
        else if ((isOnPlatform == false || isInFrontOfObstacle == true) && sr.flipX == false && (demonCurrentHealth > 0))
        {
            sr.flipX = true;
            isFlipping = true;
            rb.velocity = Vector3.SmoothDamp(rb.velocity, -ennemiSpeed * Time.deltaTime, ref vref, 0f);
        }
        else if ((isOnPlatform == false || isInFrontOfObstacle == true) && sr.flipX == true && (demonCurrentHealth > 0))
        {
            sr.flipX = false;
            isFlipping = false;
            rb.velocity = Vector3.SmoothDamp(rb.velocity, ennemiSpeed * Time.deltaTime, ref vref, 0f);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }





    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkOnPlatform.position, checkOnPlatformRadius);

        Gizmos.DrawWireSphere(checkObstacle.position, checkObstacleRadius);
    }


}
