using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    [SerializeField]
    private float m_DelayToDestroy;
    
    [SerializeField]
    private int m_ScoreToAdd;

    private GameObject m_ItemController;
    private ItemController m_ItemControllerClass;

    private void Awake()
    {
        m_ItemController = GameObject.FindGameObjectWithTag(GameDefines.m_ItemControllerTag);
        
        if (m_ItemController)
        {
            m_ItemControllerClass = m_ItemController.GetComponent<ItemController>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == GameDefines.m_PlayerTag && !LevelController.m_Instance.GameOverStatus())
        {
            m_ItemControllerClass.AddScore(m_ScoreToAdd);
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(m_DelayToDestroy);
        Destroy(gameObject);
    }

}
