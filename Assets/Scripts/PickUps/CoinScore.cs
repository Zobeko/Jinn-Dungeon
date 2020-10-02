using UnityEngine;

public class CoinScore : MonoBehaviour
{
    private int coinValue = 25;
    GameObject playerScoreBoard;

    public AudioClip soundEffect;
    
    void Awake()
    {

        playerScoreBoard = GameObject.Find("PlayerScoreBoard");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(soundEffect, transform.position);
            playerScoreBoard.GetComponent<PlayerScore>().playerScore += coinValue;
            Destroy(transform.gameObject);
        }
    }
}
