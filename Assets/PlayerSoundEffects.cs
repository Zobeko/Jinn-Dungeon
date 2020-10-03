using UnityEngine;
using UnityEngine.Audio;



public class PlayerSoundEffects : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip doubleJumpSound;
    [SerializeField] private AudioClip walkSound;
    

    private GameObject player;



    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovements>().isGrounded && (Input.GetKeyDown(KeyCode.LeftControl)))
        {
            AudioManager.instance.PlayClipAt(jumpSound, player.transform.position);
        }

        if (!(player.GetComponent<PlayerMovements>().isGrounded) && (Input.GetKeyDown(KeyCode.LeftControl)) && (player.GetComponent<PlayerMovements>().cptJump <=1))
        {
            AudioManager.instance.PlayClipAt(doubleJumpSound, player.transform.position);
        }



    }
}
