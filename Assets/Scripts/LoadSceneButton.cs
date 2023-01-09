using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{

    [SerializeField]
    private string m_SceneToLoad;

    [SerializeField]
    private int m_SceneIndexToLoad;

    private string m_SceneName;

    private int m_SceneIndex;
    
    private void Start()
    {
        m_SceneName = SceneManager.GetActiveScene().name;
        m_SceneIndex = SceneManager.GetActiveScene().buildIndex;
        CheckNextScene();
    }
    
    public void LoadSceneByName()
    {
        EventManager.PlaySoundTrigger(GameDefines.Sounds.PressButton);
        SceneManager.LoadScene(m_SceneToLoad);
    }

    public void LoadSceneByCode()
    {
        if (m_SceneToLoad == "")
        {
            SceneManager.LoadScene(m_SceneIndexToLoad);
            EventManager.PlaySoundTrigger(GameDefines.Sounds.PressButton);
        }
        else
        {
            LoadSceneByName();
        }
    }

    public void RelaodScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        EventManager.PlaySoundTrigger(GameDefines.Sounds.PressButton);
    }

    private void CheckNextScene()
    {
        if (m_SceneName.Contains("Stage"))
        {
            m_SceneIndexToLoad = m_SceneIndex + 1;
        }
    }

    public void LoadSceneToContinueScene()
    {
        int currentScene = PlayerPrefs.GetInt(GameDefines.m_CurrentScenePlayerPref, m_SceneIndexToLoad);
        
        if (currentScene == 0)
        {
           SceneManager.LoadScene("Stage_1");
        }
        else
        {
            SceneManager.LoadScene(currentScene);
        }

    }
}
