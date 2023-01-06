using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void CallGameOverScreen();

    public static event CallGameOverScreen callGameOverScreen ;
    
    public delegate void CallWinScreen();

    public static event CallGameOverScreen callWinScreen ;

    
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

    #endregion
}
