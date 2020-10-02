using System;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // 1) Les variables globales

        //Les entiers
    public float cptJump;

        //Les flottants
    public float playerSpeed;
    public float jumpForce;
    private float horizMvt;
    private float horizMvtAbs;
    public float CheckGroundedRadius;
    private float shotSpawnPointDistance;

        //Les booléens (flags)
    public bool isGrounded;
    public bool isJumping;
    public bool isDoubleJumping;
    private bool _isFlipping;
    public bool isFlipping
    {
        get { return _isFlipping; }
        set
        {
            if (sr.flipX == true)
            {
                shotSpawnPoint.position -= new Vector3(shotSpawnPointDistance * 2, 0f, 0f);
            }
            else
            {
                shotSpawnPoint.position += new Vector3(shotSpawnPointDistance * 2, 0f, 0f);
            }

            _isFlipping = value;
        }
    }

    //Les objets Unity
    public Transform CheckGrounded;
    public LayerMask layerMaskGrounded;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator animator;
    public Transform shotSpawnPoint;


        //La référence pour le SmoothDamp
    private Vector3 v = Vector3.zero;

    void Start()
    {
        cptJump = 0;
        shotSpawnPointDistance = Vector3.Distance(shotSpawnPoint.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        //Récupération de la vitesse du joueur selon l'input
        horizMvt = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;

        if (isGrounded)
        {
            cptJump = 0;
        }

        //Test si le joueur est au sol et appuie sur "espace", alors isJumping=true
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            isJumping = true;
            //cptJump++;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !isGrounded)
        {
            isDoubleJumping = true;
            cptJump++;
        }

        //Appel à la fonction de changement de direction du sprite
        Flip(horizMvt);

        //Envoie isGrounded à l'animator
        BoolsForAnimator();

        //Envoie les vitesse à l'animator
        FloatsForAnimator(horizMvt);

        //checkFlip();
        
    }

    void FixedUpdate()
    {
        //isGrounded = true si CheckGrounded est en contact avec un collider
        isGrounded = Physics2D.OverlapCircle(CheckGrounded.position, CheckGroundedRadius, layerMaskGrounded);


        //Fonction de déplacement du joueur
        MovePayer(horizMvt);
        
        //Fonction de saut du joueur
        PlayerJump();

        
    }










    //Fonction de déplacement du joueur
    private void MovePayer(float _horizMvt)
    {

        Vector3 targetVelocity = new Vector3(_horizMvt, rb.velocity.y);

        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref v, .05f);
        
    }

    //Appel à la fonction de changement de direction du sprite
    private void Flip(float _horizMvt)
    {
        if(horizMvt > 0.1f && sr.flipX == true)
        {

            sr.flipX = false;
            isFlipping = false;
        }
        else if(horizMvt < -0.1f && sr.flipX == false)
        {

            sr.flipX = true;
            isFlipping = true;
        }
        
    }

    private void checkFlip()
    {
        if((sr.flipX == false) && (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            isFlipping = true;
        }
        else if ((sr.flipX == true) && (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            isFlipping = false;
        }
    }

    //Fonction de saut du joueur
    private void PlayerJump()
    {
        //Gere le saut simple
        if (isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isJumping = false;
        }

        //Gere le double saut
        else if (isDoubleJumping && cptJump <= 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce);
            isDoubleJumping = false;
        }
    }









    //Envoie les vitesse à l'animator
    private void FloatsForAnimator(float _horizMvt)
    {
        horizMvtAbs = Math.Abs(horizMvt);
        animator.SetFloat("playerSpeed", horizMvtAbs);

        animator.SetFloat("playerSpeedY", rb.velocity.y);

        animator.SetFloat("compteurJump", cptJump);


    }

    //Envoie siGrounded à l'animator
    private void BoolsForAnimator()
    {
        animator.SetBool("isGrounded", isGrounded);

        
    }

    

    //Dessine le guizmos du checkGrounded pour pouvoir le placer aisément
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(CheckGrounded.position, CheckGroundedRadius);
    }
}
