using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_Starts;
    
    [SerializeField]
    private GameObject[] m_Food;

    private void OnEnable()
    {
        m_Food = GameObject.FindGameObjectsWithTag(GameDefines.m_FoodTag);
        EnableStars(m_Food.Length);
    }

    private void OnDisable()
    {
        DisableStars();
    }
    private void EnableStars(int foodCount)
    {
        Debug.Log(foodCount);
        if (foodCount == 0)
        {
            m_Starts[0].SetActive(true);
            m_Starts[1].SetActive(true);
            m_Starts[2].SetActive(true);
        }

        if (foodCount == 1)
        {
            m_Starts[0].SetActive(true);
            m_Starts[1].SetActive(true);
        }

        if (foodCount == 2)
        {
            m_Starts[0].SetActive(true);
        }
    }

    private void DisableStars()
    {
        for (int i = 0; i <= m_Starts.Length - 1; i++)
        {
            m_Starts[i].SetActive(false);
        }
    } 
}
