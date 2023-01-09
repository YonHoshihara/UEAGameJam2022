using System.Collections;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    
    [SerializeField]
    private float m_DelayToCallScreen;

    private GameObject m_Player;

    public static LevelController m_Instance;
    
    [SerializeField]
    private TimerController m_TimeController;

    [SerializeField]
    private ItemController m_ItemController;

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
        PlayerPrefs.SetInt(GameDefines.m_CurrentScenePlayerPref, SceneManager.GetActiveScene().buildIndex);
        m_Player = GameObject.FindGameObjectWithTag(GameDefines.m_PlayerTag);
        m_GameOverStatus = false;
        m_TimeController.StartCount();
    }

    public void CallGameOver()
    {
        EventManager.PlaySoundTrigger(GameDefines.Sounds.Lose); 
        m_Player.SetActive(false);
       m_GameOverStatus = true;
       m_TimeController.ResetCount();
       EventManager.CallGameOverScreenTrigger();
    }

    public void CallWinScreen()
    {
        m_Player.SetActive(false);
        StartCoroutine(CallScreen());
    }

    private IEnumerator CallScreen()
    {
        yield return new WaitForSeconds(m_DelayToCallScreen);
        if (m_ItemController.GetScore() > 0)
        {
            EventManager.PlaySoundTrigger(GameDefines.Sounds.Win); 
            EventManager.CallWinScreenTrigger();
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
