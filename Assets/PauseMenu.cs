﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Button pause;
    public Canvas pauseMenu;

    public Button restartConfirm;
    public Button mainMenuConfirm;

    public bool paused;

    public void pauseMenuOpen()
    {
        pauseMenu.gameObject.SetActive(true);
        paused = true;
        Time.timeScale = 0;
    }
    public void pauseMenuClose()
    {
        pauseMenu.gameObject.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }

    public void restartComfirmOpen()
    {
        restartConfirm.gameObject.SetActive(true);
        mainMenuConfirm.gameObject.SetActive(false);
    }

    public void mainMenuComfirmOpen()
    {
        restartConfirm.gameObject.SetActive(false);
        mainMenuConfirm.gameObject.SetActive(true);
    }

    public void restartComfirmed()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void mainMenuComfirmed()
    {
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        paused = false;
    }
}
