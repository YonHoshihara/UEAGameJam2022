using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;


public class LevelSelectionGridGenerator : MonoBehaviour
{
    
    [SerializeField] 
    private GameObject m_ButtonModel;

    [SerializeField] 
    private GameObject m_Grid;
 
    [SerializeField]
    private GameObject m_NextButton;

    [SerializeField]
    private GameObject m_BackButton;

    [SerializeField]
    private int m_PageElementsNumber;

    private List<string> m_ScenesNameList;

    private int m_LevelToStart;

    private int m_LevelToEnd;

    private int m_MaxLevel;

    private int m_MaxCalculatedLevel;

    private EditorBuildSettingsScene[] m_ScenesInBuildSettings;

    private void Start()
    {
        m_ScenesNameList = new List<string>();
        ListLevelGameScenes();
        m_LevelToStart = 1;
        m_LevelToEnd = m_PageElementsNumber;
        UpdatePagination();
    }

    private void ListLevelGameScenes()
    {
        m_ScenesInBuildSettings = EditorBuildSettings.scenes;
        
        foreach (var scene in m_ScenesInBuildSettings)
        {
            if (scene.path.Contains("Stage"))
            {
                m_ScenesNameList.Add(scene.path);
            }
        }
        m_MaxLevel = m_ScenesNameList.Count;
    }

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
            currentButton.transform.SetParent(m_Grid.transform);
            currentButtonController.LoadButtonState();
        }
        
        
        foreach (LevelSelectButtonController child in m_Grid.transform.GetComponentsInChildren<LevelSelectButtonController>())
        {
            child.GetComponent<RectTransform>().localScale = Vector3.one;
        }

        GameObject buttonToStart = m_Grid.gameObject.transform.GetChild(0).gameObject;
        EventSystem.current.SetSelectedGameObject(buttonToStart);
        
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

    private void UpdatePagination()
    {
        if (GetLevelStart() == 1)
        {
            m_BackButton.SetActive(false);

        }
        else
        {
            m_BackButton.SetActive(true);
        }

        if (GetLevelEnd() == m_MaxLevel)
        {
            m_NextButton.SetActive(false);
        }
        else
        {
            m_NextButton.SetActive(true);
        }

       ClearScreen();
       GenerateMenu();

    }

    public void GoToNextPage()
    {

        int currentStartLevel = GetLevelStart();
        int currentEndLevel = GetLevelEnd();
        int nextStartLevel = currentStartLevel + m_PageElementsNumber;
        int nextEndLevel = currentEndLevel + m_PageElementsNumber;

        if (nextEndLevel > m_MaxLevel)
        {
            m_MaxCalculatedLevel = nextEndLevel;
            nextEndLevel = m_MaxLevel;
            m_NextButton.gameObject.SetActive(false);
        }

        SetLevelStart(nextStartLevel);
        SetLevelEnd(nextEndLevel);
        UpdatePagination();
    }

    public void GoToLatestPage()
    {
        UpdatePagination();
        int currentStartLevel = GetLevelStart();
        int currentEndLevel = GetLevelEnd();
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

        SetLevelStart(nextStartLevel);
        SetLevelEnd(nextEndLevel);
        UpdatePagination();

    }

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
}
