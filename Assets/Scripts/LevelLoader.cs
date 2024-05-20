using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    public TransitionManager _transitionManager;
    public TransitionSettings settings;

    private bool isLoading;
    public float delay;

    private void Awake()
    {
        instance = this;
        _transitionManager = GetComponent<TransitionManager>();
    }

    public void LoadNextLevel()
    {
        int num = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("CompletedLevels", num);
        PlayerPrefs.Save();
        LoadLevel(num);
    }
    public void LoadPrevLevel()
    {
        int num = SceneManager.GetActiveScene().buildIndex - 1;
        LoadLevel(num);
    }

    public void LoadCurrentLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadScene(int index)
    {
        try
        {
            var scene = SceneManager.GetSceneByBuildIndex(index);
            if (scene == null)
            {
                Debug.LogWarning(index + " index level not found!");
                return;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
            isLoading = false;
            return;
        }
      
        Time.timeScale = 1f;
        Debug.Log("Loading level " + index); 
        TransitionManager.Instance().Transition(index,settings,startDelay: delay);
    }

    public void LoadMainMenu()
    {
        if (!isLoading)
        {
            isLoading = true;
            LoadScene(0);
        }
    }

    public void LoadLevel(int level)
    {
        if (!isLoading)
        {
            isLoading = true;
            LoadScene(level);
        }
    }
}

