using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public float playerScore;

    [SerializeField] private Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + playerScore;
        
    }
}
