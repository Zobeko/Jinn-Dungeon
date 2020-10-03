using System;
using UnityEngine;

public class EnnemiMovements : MonoBehaviour
{
    //Bolléens
    [SerializeField] private bool isOnPlatform = true;
    [SerializeField] private bool isInFrontOfObstacle = false;
    private bool _isFlipping;
    public bool isFlipping
    {
        get { return _isFlipping; }
        set
        {
            if (sr.flipX == true)
            {
                checkOnPlatform.position -= new Vector3(ennemiWidth/2, 0f, 0f);
                checkObstacle.position -= new Vector3(ennemiWidth/4, 0f, 0f);
                 
                shotSpawPoint.position -= new Vector3(shotSpawPointDistance * 2, 0f, 0f);
            }
            else
            {
                checkOnPlatform.position += new Vector3(ennemiWidth/2, 0f, 0f);
                checkObstacle.position += new Vector3(ennemiWidth/4, 0f, 0f);

                shotSpawPoint.position += new Vector3(shotSpawPointDistance * 2, 0f, 0f);
            }

            _isFlipping = value;
        }
    }

    //Flottants
    [SerializeField] private float checkOnPlatformRadius;
    [SerializeField] private float checkObstacleRadius;
    private float ennemiWidth;
    [SerializeField] private float shotSpawPointDistance;
    private float checkObstacleDistance;
    private float checkOnPlatformDistance;
    private float jinnCurrentHealth;


    //Vectors
    private Vector3 vref = Vector3.zero;

    // Extern objects
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask layerMaskEnnemis;

    //Les empties qui permettent de checker les obstacles et fin de plateforme
    [SerializeField] private Transform checkOnPlatform;
    public Transform checkObstacle;
    [SerializeField] private Transform shotSpawPoint;

    //Ennemi's components
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector3 ennemiSpeed;
    [SerializeField] private HealthBar jinnHealthBar;
    

    // Start is called before the first frame update
    void Start()
    {
        ennemiWidth = transform.GetComponent<SpriteRenderer>().bounds.max.x - transform.GetComponent<SpriteRenderer>().bounds.min.x;

        shotSpawPointDistance = Vector3.Distance(shotSpawPoint.position, transform.position);
        checkObstacleDistance = Vector3.Distance(checkObstacle.position, transform.position);
        checkOnPlatformDistance = Vector3.Distance(checkOnPlatform.position, transform.position);

        EnnemiFlipStart();

        

    }

    // Update is called once per frame
    void Update()
    {
        jinnCurrentHealth = transform.gameObject.GetComponent<JinnHealth>().currentHealth;
        
        

        
        
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
        if(player.transform.position.x > transform.position.x && sr.flipX == true)
        {
            sr.flipX = false;
            isFlipping = false;
            

        }
        if(player.transform.position.x <= transform.position.x && sr.flipX == false)
        {
            sr.flipX = true;
            isFlipping = true;
            


        }
    }

    private void EnnemiMove()
    {
        if(isOnPlatform == true && isInFrontOfObstacle == false && sr.flipX == false && (jinnCurrentHealth > 0))
        {
            
            rb.velocity = Vector3.SmoothDamp(rb.velocity, ennemiSpeed * Time.deltaTime, ref vref, 0f);
        }
        else if(isOnPlatform == true && isInFrontOfObstacle == false && sr.flipX == true && (jinnCurrentHealth > 0))
        {
            
            rb.velocity = Vector3.SmoothDamp(rb.velocity, -ennemiSpeed * Time.deltaTime, ref vref, 0f);
            
        }
        else if((isOnPlatform == false || isInFrontOfObstacle == true) && sr.flipX == false && (jinnCurrentHealth > 0))
        {
            sr.flipX = true;
            isFlipping = true;
            rb.velocity = Vector3.SmoothDamp(rb.velocity, -ennemiSpeed * Time.deltaTime, ref vref, 0f);
        }
        else if((isOnPlatform == false || isInFrontOfObstacle == true) && sr.flipX == true && (jinnCurrentHealth > 0))
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
