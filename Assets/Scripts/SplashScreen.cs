using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField]
    private string m_SceneToLoad;

    public void  CallScreenOnEndAnimation()
    {
        SceneManager.LoadScene(m_SceneToLoad);
    }
  
}
