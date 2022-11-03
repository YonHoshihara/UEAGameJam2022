using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{

    [SerializeField]
    private float m_JumpForce;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(GameDefines.m_PlayerTag) && !LevelController.m_Instance.GameOverStatus())
        {
            collision.gameObject.GetComponent<PlayerMovement>().CallJump(m_JumpForce, ForceMode2D.Impulse);
        }
    }
}
