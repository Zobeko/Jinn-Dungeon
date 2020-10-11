using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private string stagesScene;

    [SerializeField] private GameObject settingWindow;

    void Start()
    {
        Cursor.visible = true;
        settingWindow.SetActive(false);
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(stagesScene);
    } 

    public void SettingsButton()
    {
        settingWindow.SetActive(true);
    }

    public void CloseSettings()
    {
        settingWindow.SetActive(false);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

}
