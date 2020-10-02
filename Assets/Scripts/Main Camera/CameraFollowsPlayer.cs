using System.Linq.Expressions;
using System.Runtime.Versioning;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{

    private GameObject player;

    private Vector3 targetPos;
    public Vector3 posOffset;
    public float timeOffset;
    private float cameraBoundRight;



    private Vector3 v = Vector3.zero;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3((player.transform.position.x + posOffset.x), transform.position.y, -10);
        

        cameraBoundRight = transform.position.x - posOffset.x;

        if (player.transform.position.x >= cameraBoundRight || !(player.activeInHierarchy))
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref v, timeOffset);

        }
        
    }
}
