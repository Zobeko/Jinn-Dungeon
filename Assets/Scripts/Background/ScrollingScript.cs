using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{

    public Vector2 speed;
    public Vector2 direction;

    public bool isLinkedToCamera = false;
    public bool isLooping = true;

    
    private List<Transform> backgroundParts;

    private CameraFollowsPlayer cam;
    public GameObject player;

    void Start()
    {

        cam = Camera.main.GetComponent<CameraFollowsPlayer>();

        if (isLooping)
        {

            //Récupération des enfants ayant un SpriteRenderer (visibles)
            backgroundParts = new List<Transform>();
            for(int i=0; i<transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);

                if(child.GetComponent<SpriteRenderer>() != null)
                {
                    backgroundParts.Add(child);
                }
            }

            //Tri par position de gauche à droite
            backgroundParts = backgroundParts.OrderBy(t => t.position.x).ToList();

        }
    }

    // Update is called once per frame
    void Update()
    {
        //mvt est la vitesse de déplacement des bg
        Vector3 mvt = new Vector3((speed.x * direction.x), (speed.y * direction.y), 0);

        mvt *= Time.deltaTime;

        //Si le joueur se déplace vers la droite et dépasse le cap de la caméra, alors le bg bouge
        Rigidbody2D rb = player.transform.GetComponent<Rigidbody2D>();
        if ((rb.velocity.x > 0.1f) && (player.transform.position.x >= (Camera.main.transform.position.x - cam.posOffset.x)))
        {
            transform.Translate(mvt);
        }


        //Déplacement camera
        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(mvt);
        }

        //Répétition des backgrounds
        if (isLooping) {
            
            
                Transform firstChild = backgroundParts.FirstOrDefault();

                if (firstChild != null)
                {

                    //Test position
                    if (firstChild.position.x < Camera.main.transform.position.x)
                    {

                        //Test si ce plan n'est plus visible par la camera
                        if (firstChild.GetComponent<SpriteRenderer>().IsVisibleFrom(Camera.main) == false)
                        {
                            //Récupération du dernier plan (celui le plus à droite)
                            Transform lastChild = backgroundParts.LastOrDefault();

                            //Calcul de la position à laquelle replacer firstChil
                            Vector3 lastPosition = lastChild.transform.position;
                            Vector3 lastSize = (lastChild.GetComponent<SpriteRenderer>().bounds.max - lastChild.GetComponent<SpriteRenderer>().bounds.min);

                            //On place firstChildaprès lastChild
                            firstChild.position = new Vector3((lastPosition.x + lastSize.x), lastPosition.y, lastPosition.z);

                            //Mise à jour de la liste (lepremier devient dernier)
                            backgroundParts.Remove(firstChild);
                            backgroundParts.Add(firstChild);
                        }
                    }
                }
            
        }
        
    }

}
