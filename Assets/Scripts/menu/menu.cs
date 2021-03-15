using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    int level;
    public Button level1;
    public Button level2;
    private Color oldColor;
    private void Start()
    {
        //PlayerPrefs.SetInt("LevelFinish", 0);
        if (level1 && level2)
        {
            oldColor = level1.GetComponent<Image>().color;
        }
        
    }

    private void Update()
    {
        if (level1 && level2)
        {
            if (PlayerPrefs.GetInt("LevelFinish") == 1 || PlayerPrefs.GetInt("LevelFinish") == 2)
            {
                level2.GetComponent<Button>().interactable = true;
                level1.GetComponent<Button>().interactable = true;
                level2.GetComponent<Image>().color = oldColor;
                level1.GetComponent<Image>().color = oldColor;

            }
            else if (PlayerPrefs.GetInt("LevelFinish") == 5)
            {
                level2.GetComponent<Button>().interactable = false;
                level1.GetComponent<Button>().interactable = true;
                level2.GetComponent<Image>().color = Color.white;
                level1.GetComponent<Image>().color = oldColor;
            }
            else
            {
                level2.GetComponent<Button>().interactable = false;
                level1.GetComponent<Button>().interactable = false;
                level2.GetComponent<Image>().color = Color.white;
                level1.GetComponent<Image>().color = Color.white;
            }
        }

    }
    public void PlayGame()
    {
        //SceneManager.LoadScene(3);
        Time.timeScale = 1;
        level = PlayerPrefs.GetInt("Level");
        if (level == 0)
        {
            level = 5;
        }
        StartCoroutine(DelaySceneLoad(level));
        
    }
    public void PlayNewGame()
    {
        //SceneManager.LoadScene(3);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("LevelFinish", 0);
        PlayTutorial();

    }
    public void BackToMainMenu()
    {
        //SceneManager.LoadScene(0);
        Time.timeScale = 1;
        StartCoroutine(DelaySceneLoad(0));
    }

    public void PlayTutorial()
    {
        //SceneManager.LoadScene(3);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Level", 5);
        level = PlayerPrefs.GetInt("Level");
        StartCoroutine(DelaySceneLoad(5));

    }
    public void PlayLevel1()
    {
        //SceneManager.LoadScene(3);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Level", 3);
        level = PlayerPrefs.GetInt("Level");
        StartCoroutine(DelaySceneLoad(3));
        
    }

    public void PlayLevel2()
    {
        //SceneManager.LoadScene(3);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Level", 4);
        level = PlayerPrefs.GetInt("Level");
        StartCoroutine(DelaySceneLoad(4));
        
    }

    public void PlayLevel3()
    {
        //SceneManager.LoadScene(3);
        Time.timeScale = 1;
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

