using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreenController : MonoBehaviour
{
    
    [SerializeField]
    private Animator m_GameOverScreen;

    [SerializeField]
    private Animator m_WinScreen;
    
    // Start is called before the first frame update
    void Awake()
    {
        EventManager.callGameOverScreen += EnableGameOverScreen;
        EventManager.callWinScreen += EnableWinScreen;
    }
    
    private void EnableWinScreen()
    {
        m_WinScreen.gameObject.SetActive(true);
        m_WinScreen.SetTrigger("Enable");
    }

    private void EnableGameOverScreen()
    {
        m_GameOverScreen.gameObject.SetActive(true);
        m_GameOverScreen.SetTrigger("Enable");
    }

    private void OnDestroy()
    {
        EventManager.callGameOverScreen -= EnableGameOverScreen;
        EventManager.callWinScreen -= EnableWinScreen;
    }
}
