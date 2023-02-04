using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectPagination : MonoBehaviour
{

    [SerializeField] 
    private GameObject m_NextButton;

    [SerializeField] 
    private GameObject m_BackButton;

    [SerializeField] 
    private LevelSelectionGridGenerator m_GridGenerator;

    [SerializeField] 
    private int m_MaxLevel;

    [SerializeField]
    private int m_PageElementsNumber;

    private int m_MaxCalculatedLevel;

    private void OnEnable()
    {
        EventManager.callNextLevelMenuPage += GoToNextPage;
        EventManager.callLatestLevelMenuPage += GoToLatestPage;
    }

    private void OnDestroy()
    {
        EventManager.callNextLevelMenuPage -= GoToNextPage;
        EventManager.callLatestLevelMenuPage -= GoToLatestPage;
    }

    void Start()
    {
        UpdatePagination();
    }
    private void UpdatePagination()
    {
        if (m_GridGenerator.GetLevelStart() == 1)
        {
            m_BackButton.SetActive(false);
            
        }
        else
        {
            m_BackButton.SetActive(true);
        }

        if (m_GridGenerator.GetLevelEnd() == m_MaxLevel)
        {
            m_NextButton.SetActive(false);
        }
        else
        {
            m_NextButton.SetActive(true);
        }
        
        m_GridGenerator.ClearScreen();
        m_GridGenerator.GenerateMenu();

    }

    public void GoToNextPage()
    {
       
        int currentStartLevel = m_GridGenerator.GetLevelStart();
        int currentEndLevel = m_GridGenerator.GetLevelEnd();
        int nextStartLevel = currentStartLevel + m_PageElementsNumber;
        int nextEndLevel = currentEndLevel + m_PageElementsNumber;

        if (nextEndLevel > m_MaxLevel)
        {
            m_MaxCalculatedLevel = nextEndLevel;
            nextEndLevel = m_MaxLevel;
            m_NextButton.gameObject.SetActive(false);
        }
        
        m_GridGenerator.SetLevelStart( nextStartLevel);
        m_GridGenerator.SetLevelEnd(nextEndLevel);
        UpdatePagination();
    }
    
    public void GoToLatestPage()
    {
        UpdatePagination();
        int currentStartLevel = m_GridGenerator.GetLevelStart();
        int currentEndLevel = m_GridGenerator.GetLevelEnd();
        int nextStartLevel = currentStartLevel - m_PageElementsNumber;
        int nextEndLevel = currentEndLevel - m_PageElementsNumber;
        
        if (currentEndLevel == m_MaxLevel)
        {
            nextEndLevel = currentEndLevel - (m_MaxCalculatedLevel - m_MaxLevel);
        }
        
        if (nextStartLevel < 1)
        {
            nextStartLevel = 1;
        }
        
        m_GridGenerator.SetLevelStart( nextStartLevel);
        m_GridGenerator.SetLevelEnd(nextEndLevel);
        UpdatePagination();
        
    }
    
    
}
