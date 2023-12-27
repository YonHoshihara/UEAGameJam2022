using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerController : MonoBehaviour
{

    [SerializeField]
    private TMP_Text m_TimeText;

    [SerializeField]
    private float m_LevelTime;

    [SerializeField]
    private FloatVariable m_GameCurrentTime;

    private float m_Time;
    private bool m_StartCount;
    private int m_IntTime;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Time = m_LevelTime;
        m_GameCurrentTime.m_Value = m_Time;
        m_TimeText = GameObject.FindGameObjectWithTag(GameDefines.m_TimeTextTag).GetComponent<TMP_Text>();
        m_TimeText.text = m_Time.ToString();
    }
   
    // Update is called once per frame
    void Update()
    {
        if (m_StartCount)
        {
            m_Time -= Time.deltaTime;
            m_IntTime = (int)m_Time;
            m_TimeText.text = m_IntTime.ToString();
            m_GameCurrentTime.m_Value = m_Time;
            if (m_Time <= 0)
            {
                m_StartCount = false;
                LevelController.m_Instance.CallGameOver();
            }
        }
    }

    public void StartCount()
    {
        m_StartCount = true;
    }

    public void ResetCount()
    {
        m_StartCount = false;
        m_Time = m_LevelTime;
    }

    public float GetCurrentTime()
    {
        return m_Time;
    }
}
