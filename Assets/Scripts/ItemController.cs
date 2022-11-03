using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private int m_Score;
    
    public void AddScore(int scoreToAdd)
    {
        m_Score = m_Score + scoreToAdd;
    }

    public int GetScore()
    {
        return m_Score;
    }
}
