using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsWindow;

    
    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.volume = 1;
        Cursor.visible = false;
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void CloseSettings()
    {
        settingsWindow.SetActive(false);
    }
}
