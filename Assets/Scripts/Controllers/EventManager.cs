using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void CallGameOverScreen();

    public static event CallGameOverScreen callGameOverScreen ;
    
    public delegate void CallWinScreen();

    public static event CallGameOverScreen callWinScreen;
    
    public delegate void CallAddScore(int scoreToAdd);

    public static event CallAddScore callAddScore;
    
    public delegate void PlaySound(GameDefines.Sounds sound);

    public static event PlaySound playSound;
    
    public delegate void StartMeteorMovement();

    public static event StartMeteorMovement startMeteorMovement;
    
    public delegate void CallNextLevelMenuPage();

    public static event CallNextLevelMenuPage callNextLevelMenuPage ;
    
    public delegate void CallLatestLevelMenuPage();

    public static event CallLatestLevelMenuPage callLatestLevelMenuPage ;

    
    #region Triggers

    public static void CallGameOverScreenTrigger()
    {
        if (callGameOverScreen != null)
        {
            callGameOverScreen();
        }
    }
    
    public static void CallWinScreenTrigger()
    {
        if (callWinScreen != null)
        {
            callWinScreen();
        }
    }
    
    public static void CallAddScoreTrigger(int scoreToAdd)
    {
        if (callAddScore != null)
        {
            callAddScore(scoreToAdd);
        }
    }

    public static void PlaySoundTrigger(GameDefines.Sounds sound)
    {
        if (playSound != null)
        {
            playSound(sound);
        }
    }
    
    public static void StartMeteorMovementTrigger()
    {
        if (startMeteorMovement != null)
        {
            startMeteorMovement();
        }
    }

    public static void CallNextLevelMenuPageTrigger()
    {
        if (callNextLevelMenuPage != null)
        {
            callNextLevelMenuPage();
        }
    }
    
    public static void CallLatestLevelMenuPageTrigger()
    {
        if (callLatestLevelMenuPage != null)
        {
            callLatestLevelMenuPage();
        }
    }

    #endregion
}
