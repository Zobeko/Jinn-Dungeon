﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void SelectLevel11()
    {
        SceneManager.LoadScene("Level1-1");
    }

    public void SelectLevel12()
    {
        SceneManager.LoadScene("Level1-2");
    }


}
