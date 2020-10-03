using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private AudioClip openPauseMenuSound;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeSelf)
        {
            //On ajoute le son
            AudioManager.instance.PlayClipAt(openPauseMenuSound, transform.position);

            pauseMenu.SetActive(true);
            AudioListener.volume = 0;
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf)
        {
            //On ajoute le son
            AudioManager.instance.PlayClipAt(openPauseMenuSound, transform.position);


            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            AudioListener.volume = 1;
            Cursor.visible = false;
        }
    }
}
