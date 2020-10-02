using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        
        Time.timeScale = 1;
        AudioListener.volume = 1;
        Cursor.visible = false;

        G = transform.GetChild(0).gameObject;
        A = transform.GetChild(1).gameObject;
        M = transform.GetChild(2).gameObject;
        E1 = transform.GetChild(3).gameObject;
        O = transform.GetChild(4).gameObject;
        V = transform.GetChild(5).gameObject;
        E2 = transform.GetChild(6).gameObject;
        R = transform.GetChild(7).gameObject;

        playerScoreGameOver = transform.GetChild(8).gameObject;


        G.SetActive(false);
        A.SetActive(false);
        M.SetActive(false);
        E1.SetActive(false);
        O.SetActive(false);
        V.SetActive(false);
        E2.SetActive(false);
        R.SetActive(false);

        playerScoreGameOver.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (playerHealthBar.nbOfLives <= 0)
        {
            playerHealthBar.isGameOver = true;
        }
        else
        {
            playerHealthBar.isGameOver = false;
        }


        if (playerHealthBar.isGameOver)
        {
            StartCoroutine(GameOverCoroutine());
            
        }
        else
        {
            //transform.gameObject.SetActive(false);
            G.SetActive(false);
            A.SetActive(false);
            M.SetActive(false);
            E1.SetActive(false);
            O.SetActive(false);
            V.SetActive(false);
            E2.SetActive(false);
            R.SetActive(false);

            playerScoreGameOver.SetActive(false);
        }
        
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

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        /*AudioListener.volume = 0;
        Time.timeScale = 0;
        Cursor.visible = true;*/
    }
}
