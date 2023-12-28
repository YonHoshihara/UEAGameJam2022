using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swamp : MonoBehaviour
{
    [SerializeField]
    private float m_VelocityReductionProportion;

    private float m_PlayeDefaultMovement;

    private PlayerMovement m_PlayerMovement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameDefines.m_PlayerTag && !LevelController.m_Instance.GameOverStatus())
        {
            if (m_PlayerMovement == null)
            {
                m_PlayerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            }

            m_PlayeDefaultMovement = m_PlayerMovement.GetMovementSpeed(); 
            m_PlayerMovement.SetMovementSpeed(m_PlayeDefaultMovement/m_VelocityReductionProportion);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameDefines.m_PlayerTag && !LevelController.m_Instance.GameOverStatus())
        {
            m_PlayerMovement.SetMovementSpeed(m_PlayeDefaultMovement);
        }
    }
}
