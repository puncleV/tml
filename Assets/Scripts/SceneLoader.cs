﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene + 1);
    }

    public void loadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void failScreen()
    {
        SceneManager.LoadScene(3);
    }

    public void quit()
    {
        Application.Quit();
    }
}
