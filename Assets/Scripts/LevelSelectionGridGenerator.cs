using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionGridGenerator : MonoBehaviour
{
    
    [SerializeField] 
    private GameObject m_ButtonModel;

    [SerializeField] 
    private int m_LevelToStart;
    
    [SerializeField] 
    private int m_LevelToEnd;

    [SerializeField] 
    private GameObject m_Grid;


    public void ClearScreen()
    {
        int childCount = gameObject.transform.childCount;
        
        for (int i = childCount - 1; i >= 0; i--) {
            DestroyImmediate(gameObject.transform.GetChild(i).gameObject);
        }
    }
    public void GenerateMenu()
    {
        for (int i = m_LevelToStart; i<= m_LevelToEnd; i++)
        {
            string stageNumber = i.ToString();
            string stageName = "Stage_" + i.ToString();
            bool lockedStatus = PlayerPrefsManager.GetStageLockStatus(stageName);
            GameObject currentButton = Instantiate(m_ButtonModel);
            LevelSelectButtonController currentButtonController =
                currentButton.GetComponent<LevelSelectButtonController>();
            currentButtonController.SetIsLocked(lockedStatus);
            currentButtonController.SetStageNumber(stageNumber);
            currentButtonController.SetLevelToLoad(stageName);
            currentButton.transform.parent = m_Grid.transform;
            currentButtonController.LoadButtonState();
        }
    }

    public void SetLevelStart(int levelStart)
    {
        m_LevelToStart = levelStart;
    }

    public void SetLevelEnd(int levelEnd)
    {
        m_LevelToEnd = levelEnd;
    }

    public int GetLevelEnd()
    {
        return m_LevelToEnd;
    }

    public int GetLevelStart()
    {
        return m_LevelToStart;
    }
}
