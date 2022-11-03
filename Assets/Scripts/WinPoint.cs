using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPoint : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameDefines.m_PlayerTag && !LevelController.m_Instance.GameOverStatus())
        {
            LevelController.m_Instance.CallWinScreen();
        }
    }

}
