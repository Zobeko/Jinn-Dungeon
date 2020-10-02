using UnityEngine;

public class CheckObstacles : MonoBehaviour    
{
    public SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Tilemap"))
        {
            if (sr.flipX == false)
            {
                sr.flipX = true;

            }
            else if (sr.flipX == true)
            {
                sr.flipX = false;

            }
        }
    }
}
