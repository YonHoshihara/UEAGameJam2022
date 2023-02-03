using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{

    public static void SaveScore(string sceneName, int value)
    {
        int latestScore = PlayerPrefs.GetInt(sceneName + "Score",0);
        
        if (latestScore < value)
        {
            PlayerPrefs.SetInt(sceneName + "Score", value);
        }
    }
    
    public static int GetScore(string sceneName)
    {
        int latestScore = PlayerPrefs.GetInt(sceneName + "Score", 0);

        return latestScore;
    }
    
}
