using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float m_MovementSpeed;
    
    [SerializeField]
    private float m_JumpForce;

    [SerializeField]
    private Rigidbody2D m_RigidBody;

    [SerializeField]
    private Animator m_Animator;

    private Vector2 m_MovementVector;
    
    private bool m_IsJumping;
    
    // Start is called before the first frame update
    void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {     
        m_MovementVector = new Vector2(Input.GetAxis("Horizontal"), 0);
        Jump(m_JumpForce);
        if (m_IsJumping)
        {
            m_Animator.SetFloat("YVelocity", m_RigidBody.velocity.y);
        }
    }

    void FixedUpdate()
    {
        Move(m_MovementVector,m_MovementSpeed);
    }

    private void Move(Vector3  movement , float speed)
    {
        if (!LevelController.m_Instance.GameOverStatus())
        {
            transform.position += movement * Time.deltaTime * speed;
            
            if (movement.x == 0 && !m_IsJumping)
            {
                m_Animator.SetBool("Move", false);
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            
            if (movement.x > 0 && !m_IsJumping)
            {
                m_Animator.SetBool("Move", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (movement.x < 0 && !m_IsJumping)
            {
                m_Animator.SetBool("Move", true);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    private void Jump(float jumpforce)
    {
        if (Input.GetKeyDown(GameDefines.m_JumpButton) && !m_IsJumping)
        {
            m_Animator.SetTrigger("Jump");
            m_Animator.SetBool("Move", false);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            CallJump(jumpforce, ForceMode2D.Impulse);
        }
    }

    public void CallJump(float jumpforce, ForceMode2D forcemode)
    {
        m_RigidBody.AddForce(new Vector2(0, jumpforce), forcemode);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == GameDefines.m_GroundLayer && !LevelController.m_Instance.GameOverStatus())
        {
            if (m_IsJumping)
            {
                m_Animator.SetTrigger("Land");
            }
            m_IsJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == GameDefines.m_GroundLayer && !LevelController.m_Instance.GameOverStatus())
        {
            m_IsJumping = true;
        }
    }

    public void SetMovementSpeed(float speed)
    {
        m_MovementSpeed = speed;
    }

    public float GetMovementSpeed()
    {
        return m_MovementSpeed;
    }


    public bool GetIsJumpingStatus()
    {
        return m_IsJumping;
    }

    public GameDefines.PlayerDirection GetPlayerDirection()
    {
        if (m_RigidBody.velocity.x >= 0)
        {
            return GameDefines.PlayerDirection.RIGHT;
        }

        return GameDefines.PlayerDirection.LEFT;
    }
}
