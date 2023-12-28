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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(GameDefines.m_PlayerTag) && !LevelController.m_Instance.GameOverStatus())
        {
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            Rigidbody2D playerBody = collision.gameObject.GetComponent<Rigidbody2D>();

            if(playerBody.velocity.normalized.y < 0 && playerMovement.GetIsJumpingStatus())
            {
                m_Animator.SetTrigger(m_TrigerAnimation);
                playerMovement.CallsSpringJump(m_JumpForce);
                EventManager.PlaySoundTrigger(GameDefines.Sounds.Spring);
            }
        }
    }
}
