using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionGridGenerator : MonoBehaviour
{
    public class ButtonConfig: MonoBehaviour
    {
        public int LevelNumber;
        public string LevelName;
    }
    
    [SerializeField] 
    private GameObject m_ButtonModel;

    [SerializeField] 
    private int m_LevelToStart;
    
    [SerializeField] 
    private int m_LevelToEnd;

    [SerializeField] 
    private GameObject m_Grid;

    private void Start()
    {
        GenerateMenu();
    }

    private void GenerateMenu()
    {
        for (int i = m_LevelToStart; i<= m_LevelToEnd; i++)
        {
            string stageNumber = i.ToString();
            string stageName = "Stage_" + i.ToString();
            bool lockedStatus = PlayerPrefsManager.GetStageLockStatus(stageName);
            GameObject currentButton = Instantiate(m_ButtonModel);
            LevelSelectButtonController currentButtonController =
                currentButton.GetComponent<LevelSelectButtonController>();
            currentButtonController.SetIsLocked(false);
            currentButtonController.SetStageNumber(stageNumber);
            currentButtonController.SetLevelToLoad(stageName);
            currentButton.transform.parent = m_Grid.transform;
            currentButtonController.LoadButtonState();
        }
    }

}
