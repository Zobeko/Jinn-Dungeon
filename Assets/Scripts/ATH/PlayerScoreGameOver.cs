using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreGameOver : MonoBehaviour
{

    public Text scoreTextGameOver;

    public PlayerScore playerScore;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.gameObject.activeSelf == true) {
            scoreTextGameOver.text = "Your score : " + playerScore.playerScore;
        }
    }
}