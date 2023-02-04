using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPrefsManager : MonoBehaviour
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
    
    public static void UnlockStage(string sceneName)
    {
        PlayerPrefs.SetInt(sceneName + "LockStatus",1);
    }

    public static bool GetStageLockStatus(string sceneName)
    {
        if (sceneName == "Stage_1")
        {
            return false;
        }
        
        int currentLockStatus = PlayerPrefs.GetInt(sceneName + "LockStatus", 0);
        
        if (currentLockStatus == 0)
        {
            return true;
        }
        return false;
    }
    
}
