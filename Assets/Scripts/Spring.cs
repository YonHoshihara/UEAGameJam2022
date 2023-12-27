using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{

    [SerializeField]
    private float m_JumpForce;

    [SerializeField]
    private Animator m_Animator;

    [SerializeField]
    private string m_TrigerAnimation;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(GameDefines.m_PlayerTag) && !LevelController.m_Instance.GameOverStatus())
        {
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

            if(collision.relativeVelocity.normalized.y < 0 && playerMovement.GetIsJumpingStatus())
            {
                m_Animator.SetTrigger(m_TrigerAnimation);
                playerMovement.CallsSpringJump(m_JumpForce);
                EventManager.PlaySoundTrigger(GameDefines.Sounds.Spring);
            }
        }
    }
}
