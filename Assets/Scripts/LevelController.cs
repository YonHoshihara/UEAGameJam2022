using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_GameOverScreen;

    [SerializeField]
    private Vector3 m_PlayerStartPosition;

    public static LevelController m_Instance;
    
    private TimerController m_TimeController;

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
        m_GameOverStatus = false;
        m_TimeController.StartCount();
    }

    public void CallGameOver()
    {
        m_GameOverStatus = true;
        m_GameOverScreen.SetActive(true);
    }

    public bool GameOverStatus()
    {
        return m_GameOverStatus;
    }

    public void ResetLevel()
    {
        m_GameOverStatus = false;
        m_Player.transform.position = m_PlayerStartPosition;
        m_GameOverScreen.SetActive(false);
        m_TimeController.ResetCount();
        m_TimeController.StartCount();

    }
}
