using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    int level;
    //private void Start()
    //{
    //    PlayerPrefs.SetInt("Level", 3);
    //}
    public void PlayGame()
    {
        //SceneManager.LoadScene(3);
        
        level = PlayerPrefs.GetInt("Level");
        if (level == 0)
        {
            level = 5;
        }
        StartCoroutine(DelaySceneLoad(level));
        
    }
    public void BackToMainMenu()
    {
        //SceneManager.LoadScene(0);
        StartCoroutine(DelaySceneLoad(0));
    }

    public void PlayTutorial()
    {
        //SceneManager.LoadScene(3);
        PlayerPrefs.SetInt("Level", 5);
        level = PlayerPrefs.GetInt("Level");
        StartCoroutine(DelaySceneLoad(5));

    }
    public void PlayLevel1()
    {
        //SceneManager.LoadScene(3);
        PlayerPrefs.SetInt("Level", 3);
        level = PlayerPrefs.GetInt("Level");
        StartCoroutine(DelaySceneLoad(3));
        
    }

    public void PlayLevel2()
    {
        //SceneManager.LoadScene(3);
        PlayerPrefs.SetInt("Level", 4);
        level = PlayerPrefs.GetInt("Level");
        StartCoroutine(DelaySceneLoad(4));
        
    }

    public void PlayLevel3()
    {
        //SceneManager.LoadScene(3);
        PlayerPrefs.SetInt("Level", 4);
        level = PlayerPrefs.GetInt("Level");
        StartCoroutine(DelaySceneLoad(4));
        
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

    public void quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif

    }

    IEnumerator DelaySceneLoad(int sceneNum)
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(sceneNum);
    }
}

