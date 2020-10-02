using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public AudioClip gameOverSound;

    public GameObject gameOverUI;
    public HealthBar playerHealthBar;

    private GameObject G;
    private GameObject A;
    private GameObject M;
    private GameObject E1;
    private GameObject O;
    private GameObject V;
    private GameObject E2;
    private GameObject R;



    private GameObject playerScoreGameOver;

    private GameObject retryButton;
    private GameObject mainMenuButton;

    private GameObject bestScoresButton;

    // Start is called before the first frame update
    void Start()
    {


        Time.timeScale = 1;
        AudioListener.volume = 1;
        Cursor.visible = false;

        G = gameOverUI.transform.GetChild(0).gameObject;
        A = gameOverUI.transform.GetChild(1).gameObject;
        M = gameOverUI.transform.GetChild(2).gameObject;
        E1 = gameOverUI.transform.GetChild(3).gameObject;
        O = gameOverUI.transform.GetChild(4).gameObject;
        V = gameOverUI.transform.GetChild(5).gameObject;
        E2 = gameOverUI.transform.GetChild(6).gameObject;
        R = gameOverUI.transform.GetChild(7).gameObject;

        playerScoreGameOver = gameOverUI.transform.GetChild(8).gameObject;

        retryButton = gameOverUI.transform.GetChild(9).gameObject;
        mainMenuButton = gameOverUI.transform.GetChild(10).gameObject;

        bestScoresButton = gameOverUI.transform.GetChild(11).gameObject;


        G.SetActive(false);
        A.SetActive(false);
        M.SetActive(false);
        E1.SetActive(false);
        O.SetActive(false);
        V.SetActive(false);
        E2.SetActive(false);
        R.SetActive(false);

        playerScoreGameOver.SetActive(false);

        retryButton.SetActive(false);
        mainMenuButton.SetActive(false);
        bestScoresButton.SetActive(false);

        
        

    }

    // Update is called once per frame
    void Update()
    {
        
        //Le joueur est Game over donc on lance la coroutine adaptée
        if (playerHealthBar.nbOfLives <= 0)
        {
            StartCoroutine(GameOverCoroutine());
        }





            

            

        
        else
        {
            //gameOverUI.transform.gameObject.SetActive(false);
            G.SetActive(false);
            A.SetActive(false);
            M.SetActive(false);
            E1.SetActive(false);
            O.SetActive(false);
            V.SetActive(false);
            E2.SetActive(false);
            R.SetActive(false);

            playerScoreGameOver.SetActive(false);
            retryButton.SetActive(false);
            mainMenuButton.SetActive(false);
            bestScoresButton.SetActive(false);

            


        }


        

    }


    public void RetryButton()
    {
        //Recharge la scene actuelle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void MainMenuButton()
    {
        //Charge le Menu principal
        SceneManager.LoadScene("MainMenuScene");
    }



    private IEnumerator GameOverCoroutine()
    {

        yield return new WaitForSeconds(0.5f);

        

        G.SetActive(true);
        yield return new WaitForSeconds(0.3f);

        A.SetActive(true);
        yield return new WaitForSeconds(0.3f);

        M.SetActive(true);
        yield return new WaitForSeconds(0.3f);

        E1.SetActive(true);
        yield return new WaitForSeconds(0.3f);

        O.SetActive(true);
        yield return new WaitForSeconds(0.3f);

        V.SetActive(true);
        yield return new WaitForSeconds(0.3f);

        E2.SetActive(true);
        yield return new WaitForSeconds(0.3f);

        R.SetActive(true);
        yield return new WaitForSeconds(0.3f);

        playerScoreGameOver.SetActive(true);
        bestScoresButton.SetActive(true);
        retryButton.SetActive(true);
        mainMenuButton.SetActive(true);
        


        

        /*AudioListener.volume = 0;
        Time.timeScale = 0;*/
        Cursor.visible = true;
    }
}

