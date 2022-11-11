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


    public void LoadSceneByName()
    {
        SoundController.Instance.PlaySound(4);
        SceneManager.LoadScene(m_SceneToLoad);
    }

    public void LoadSceneByCode()
    {
        SceneManager.LoadScene(m_SceneIndexToLoad);
        SoundController.Instance.PlaySound(4);
    }

    public void RelaodScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundController.Instance.PlaySound(4);
    }
}
