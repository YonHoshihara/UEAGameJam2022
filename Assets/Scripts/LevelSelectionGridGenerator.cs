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
    private int m_PaginationNumber;


    [SerializeField] 
    private int m_LevelToStart;
    
    [SerializeField] 
    private int m_LevelToEnd;

    [SerializeField] 
    private GameObject m_Grid;

    [SerializeField]
    private List<string> m_ScenesNameList;
    
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

    private EditorBuildSettingsScene[] m_ScenesInBuildSettings;

    private void Start()
    {
        ListLevelGameScenes();
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
            currentButton.transform.parent = m_Grid.transform;
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

        m_GridGenerator.SetLevelStart(nextStartLevel);
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

        m_GridGenerator.SetLevelStart(nextStartLevel);
        m_GridGenerator.SetLevelEnd(nextEndLevel);
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
