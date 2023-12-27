using System.Collections;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField]
    private float m_DelayToGameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameDefines.m_PlayerTag && !LevelController.m_Instance.GameOverStatus())
        {
            StartCoroutine(CallGameOver());
        }
    }

    IEnumerator CallGameOver()
    {
        yield return new WaitForSeconds(m_DelayToGameOver);
        LevelController.m_Instance.CallGameOver();
    }

}
