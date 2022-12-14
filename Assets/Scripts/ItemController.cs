using System;
using UnityEngine;
using TMPro;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_ScoreText;
    
    private int m_Score;

    private GameObject[] m_Food;

    private int m_FoodLenght;

    private void Awake()
    {
        EventManager.callAddScore += AddScore;
    }

    private void Start()
    {
        m_Food = GameObject.FindGameObjectsWithTag(GameDefines.m_FoodTag);
        m_ScoreText = GameObject.FindGameObjectWithTag(GameDefines.m_ScoreTextTag).GetComponent<TMP_Text>();
        m_FoodLenght = m_Food.Length;
    }

    public void AddScore(int scoreToAdd)
    {
        m_Score = m_Score + scoreToAdd;
        m_ScoreText.text = m_Score.ToString();
    }
    public int GetScoreStars()
    {
        if (m_Food.Length == 0)
        {
            return 3;
        }
        return m_Score;
    }

    public int GetScore()
    {
        return m_Score;
    }

    public void ResetScore()
    {
        m_Score = 0;
        m_ScoreText.text = "Score: " + m_Score;
    }

    private void OnDestroy()
    {
        EventManager.callAddScore -= AddScore;
    }
}
