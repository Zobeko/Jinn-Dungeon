using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class SettingsWindow : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    private Resolution[] resolutions;

    public void Start()
    {
        //Récuperes les resolutions disponnible sur notre ecran
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        //Supprime toutes les options du dropdownResolution
        resolutionDropdown.ClearOptions();

        //List qui va contenir les resolutions "resolutions" sous forme de string
        List<string> options = new List<string>();

        //Index de la resolution actuelle affichée
        int currentResolutionIndex = 0;

        //On boucle sur les Resolution.resolutions pour les convertir en string dans list
        for (int i = 0; i < resolutions.Length; i++)
        {
            //Récuperation du string correspondant à la resolution[i]
            string option = resolutions[i].width + "x" + resolutions[i].height;
            //Ajout à la List
            options.Add(option);

            //Si la résolution testée est la resolution de notre écran, on la choisie comme resolution par défaut
            if((resolutions[i].width == Screen.width) && (resolutions[i].height == Screen.height))
            {
                currentResolutionIndex = i;
            }
        }
        //Ajoute les options au dorpdownResolution
        resolutionDropdown.AddOptions(options);
        //Met la valeur de résolution à la résolution de base de notre écran
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        //On met le jeu en plein ecran par défaut
        Screen.fullScreen = true;
    }

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("music", volume);
    }

    public void ChangeSoundVolume(float volume)
    {
        audioMixer.SetFloat("soundEffects", volume);
    }


    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
