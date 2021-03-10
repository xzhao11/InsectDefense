﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene(3);
        StartCoroutine(DelaySceneLoad(3));
    }

    public void BackToMainMenu()
    {
        //SceneManager.LoadScene(0);
        StartCoroutine(DelaySceneLoad(0));
    }

    public void GoToSetting()
    {
        //SceneManager.LoadScene(1);
        StartCoroutine(DelaySceneLoad(1));
    }

    public void SelectLevels()
    {
        //SceneManager.LoadScene(2);
        StartCoroutine(DelaySceneLoad(2));
    }

    IEnumerator DelaySceneLoad(int sceneNum)
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(sceneNum);
    }
}

