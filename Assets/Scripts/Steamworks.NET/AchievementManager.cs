using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void UnlockAchievementById(string id)
    {
        if (!SteamManager.Initialized)
            return;
        SteamUserStats.SetAchievement(id);
        SteamUserStats.StoreStats();
    }
    
    public void SetIncrementableAchevementById(string id, int incrementedValue)
    {
        if (!SteamManager.Initialized)
            return;
        SteamUserStats.SetStat(id, incrementedValue);
        SteamUserStats.StoreStats();
    }

}
