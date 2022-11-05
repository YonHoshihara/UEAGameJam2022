using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_GameOverScreen;

    [SerializeField]
    private GameObject m_WinScreen;

    [SerializeField]
    private Vector3 m_PlayerStartPosition;

    public static LevelController m_Instance;
    
    private TimerController m_TimeController;

    private ItemController m_ItemController;

    private GameObject m_Player;


    private void Awake()
    {
        if (m_Instance != null && m_Instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            m_Instance = this;
        }
    }

    private bool m_GameOverStatus;

    private void Start()
    {
        m_TimeController = GameObject.FindGameObjectWithTag(GameDefines.m_TimerControler).GetComponent<TimerController>();
        m_Player = GameObject.FindGameObjectWithTag(GameDefines.m_PlayerTag);
        m_ItemController = GameObject.FindGameObjectWithTag(GameDefines.m_ItemControllerTag).GetComponent<ItemController>();
        m_GameOverStatus = false;
        m_TimeController.StartCount();
    }

    public void CallGameOver()
    {
       m_GameOverStatus = true;
       m_TimeController.ResetCount();
       m_GameOverScreen.SetActive(true); 
    }

    public void CallWinScreen()
    {
        if (m_ItemController.GetScore() > 0)
        {
            m_WinScreen.SetActive(true);
            m_GameOverStatus = true;
            m_TimeController.ResetCount();
        }
        else
        {
            CallGameOver();
        }
    }

    public bool GameOverStatus()
    {
        return m_GameOverStatus;
    }

    public void ResetLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
