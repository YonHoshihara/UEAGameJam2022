using System.Collections;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField]
    private float m_DelayToGameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameDefines.m_PlayerTag)
        {
            StartCoroutine(CallGameOver());
        }
    }

    IEnumerator CallGameOver()
    {
        yield return new WaitForSeconds(m_DelayToGameOver);
        Debug.Log("Game Over");
    }

}
