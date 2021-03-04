using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(3);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToSetting()
    {
        SceneManager.LoadScene(1);
    }

    public void SelectLevels()
    {
        SceneManager.LoadScene(2);
    }
}

