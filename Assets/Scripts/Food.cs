using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private float m_DelayToDestroy;
    
    [SerializeField]
    private int m_ScoreToAdd;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == GameDefines.m_PlayerTag && !LevelController.m_Instance.GameOverStatus())
        {
            EventManager.PlaySoundTrigger(GameDefines.Sounds.EatFood);
            EventManager.CallAddScoreTrigger(m_ScoreToAdd);
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(m_DelayToDestroy);
        Destroy(gameObject);
    }

}
