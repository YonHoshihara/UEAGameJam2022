using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] m_Starts;

    [SerializeField]
    private Image m_WinScreen;

    private GameObject[] m_Food;


    private void OnEnable()
    {
        m_Food = GameObject.FindGameObjectsWithTag(GameDefines.m_FoodTag);
        EnableStars(m_Food.Length);
    }
    private void EnableStars(int foodCount)
    {
        if (foodCount == 0)
        {
            m_WinScreen.sprite = m_Starts[2];
            PlayerPrefsManager.SaveScore(SceneManager.GetActiveScene().name,3);
        }

        if (foodCount == 1)
        {
            m_WinScreen.sprite = m_Starts[1];
            PlayerPrefsManager.SaveScore(SceneManager.GetActiveScene().name,2);
        }

        if (foodCount == 2)
        {
            m_WinScreen.sprite = m_Starts[0];
            PlayerPrefsManager.SaveScore(SceneManager.GetActiveScene().name,1);
        }
    }

}
