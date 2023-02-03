using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButtonController : MonoBehaviour
{

    [SerializeField] 
    private GameObject m_LockedIcon;

    [SerializeField] 
    private Image m_StarButtonImage;
    
    [SerializeField] 
    private string m_LevelToLoad;
    
    [SerializeField] 
    private string m_StageNumber;

    [SerializeField] 
    private TMP_Text m_StageNumberText;
    
    [SerializeField] 
    private Sprite[] m_StarsImage;

    [SerializeField] 
    private bool m_Locked;

    // Start is called before the first frame update
    void Start()
    {
        LoadButtonState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        if (!m_Locked)
        {
            StartCoroutine(CallLoadScene());
        }
    }

    private IEnumerator CallLoadScene()
    {
        yield return null;
        SceneManager.LoadScene(m_LevelToLoad);
    }

    private void LoadButtonState()
    {
        
        if (m_Locked)
        {  
            m_StarButtonImage.sprite = m_StarsImage[0];
            m_LockedIcon.SetActive(true);
            m_StageNumberText.gameObject.SetActive(false);
        }
        else
        {
            LoadScoreNumber();
        }
    }

    private void LoadScoreNumber()
    {
        int currentScore = ScoreManager.GetScore(m_LevelToLoad);
        switch (currentScore)
        {
            case 0:
                m_StarButtonImage.sprite = m_StarsImage[0];
                break;
            case 1:
                m_StarButtonImage.sprite = m_StarsImage[1];
                break;
            case 2:
                m_StarButtonImage.sprite = m_StarsImage[2];
                break;
            case 3:
                m_StarButtonImage.sprite = m_StarsImage[3];
                break;
        }
        m_StageNumberText.gameObject.SetActive(true);
        m_StageNumberText.text = m_StageNumber;
    }
}
