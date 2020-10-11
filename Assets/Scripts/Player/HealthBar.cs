using System.Collections;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public int nbOfLives = 3;
    [SerializeField] private float healthMax;
    public float currentHealth = 100;
    [SerializeField] private float nbHearts;
    [SerializeField] private float endAnimhurtDelay;
    public float endAnimDeathDelay;
    private readonly float invincibilityDelay = 5f;
    private float lifeForInvincibility = 2;

    [SerializeField] private bool isHurted = false;
    public bool isDead = false;
    public bool isGameOver = false;

    [SerializeField] private bool _isInvincible;
    public bool isInvincible
    {
        get { return _isInvincible; }
        set
        {
            _isInvincible = value;

            if (isInvincible == true)
            {
                lifeForInvincibility = currentHealth;
                Debug.Log(lifeForInvincibility);
            }
        }
    }


    [SerializeField] private SpriteRenderer sr;

    //private GameObject player;

    public AudioClip playerDeathSound;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public Animator animator;

    public float monstreDamages;
    // Start is called before the first frame update
    void Start()
    {
        isInvincible = false;

        isHurted = false;
        isDead = false;
        currentHealth = nbHearts;
        nbOfLives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentHealth <= 0)
        {

            StartCoroutine(deathAnimTime());
            nbOfLives -= 1;

            currentHealth = nbHearts;

            isDead = true;
        }
        else
        {
            isDead = false;
        }

        if(currentHealth >= nbHearts)
        {
            currentHealth = nbHearts;
        }

        Invincibility();
       
        heartsSystem();

        boolToAnimator();
    }

    void heartsSystem()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            //N'affiche que nbHearts coeurs (permet de modifier le nb 
            //de coeurs au cours du jeu)
            if (i < nbHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            //Cas ou currentHealth est entier donc que des coeurs pleins à afficher 
            if ((currentHealth % 1) == 0)
            {
                if (i < currentHealth)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }
            }
            //Cas ou currentHealth n'est pas entier donc des demis coeurs à afficher
            else
            {
                if (i < currentHealth - 1)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }

                if ((currentHealth - i) == 0.5)
                {
                    hearts[i].sprite = halfHeart;
                }
            }

        }
    }

    private void Invincibility()
    {
        if (isInvincible)
        {
            StartCoroutine(InvincibilityTime());
        }

        
    }
    


    void boolToAnimator()
    {
        animator.SetBool("_isHurted", isHurted);
        animator.SetBool("_isDead", isDead);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Bullets"))
        {
            currentHealth -= monstreDamages;
            StartCoroutine(hurtAnimTime());
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Lava"))
        {
            currentHealth = 0;
        }
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

        //On ajout le son de la mort du joueur
        AudioManager.instance.PlayClipAt(playerDeathSound, transform.position);

        yield return new WaitForSeconds(endAnimDeathDelay);   


    }

    private IEnumerator InvincibilityTime()
    {
        currentHealth = lifeForInvincibility;
        yield return new WaitForSeconds(invincibilityDelay);
        currentHealth = lifeForInvincibility;
        isInvincible = false;
    }

}
