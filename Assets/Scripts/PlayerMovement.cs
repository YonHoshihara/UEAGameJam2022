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
        m_MovementVector = new Vector2(Input.GetAxis("Horizontal"),0);
        Jump(m_JumpForce);
    }

    void FixedUpdate()
    {
        Move(m_MovementVector,m_MovementSpeed);
    }

    private void Move(Vector3  movement , float speed)
    {
        transform.position += movement * Time.deltaTime * speed;
    }

    private void Jump(float jumpforce)
    {
        if (Input.GetKeyDown(GameDefines.m_JumpButton) && !m_IsJumping)
        {
            CallJump(jumpforce, ForceMode2D.Impulse);
        }
    }

    public void CallJump(float jumpforce, ForceMode2D forcemode)
    {
        m_RigidBody.AddForce(new Vector2(0, jumpforce), forcemode);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == GameDefines.m_GroundLayer)
        {
            m_IsJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == GameDefines.m_GroundLayer)
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
