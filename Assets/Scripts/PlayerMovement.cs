using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float m_MovementSpeed;
    
    [SerializeField]
    private float m_JumpForce;

    [SerializeField] 
    private float m_GroundCheckRadios;

    [SerializeField]
    private Rigidbody2D m_RigidBody;
    
    [SerializeField]
    private Animator m_Animator;

    [SerializeField] 
    private float m_MinGroundColliderPosition;
    
    [SerializeField] 
    private float m_MaxGroundColliderPosition;
    
    [SerializeField]
    private LayerMask m_GroundLayer;
    
    private Vector2 m_MovementVector;
    
    private bool m_IsJumping;

    private bool m_Moving;

    private PlayerControlls m_Controls;
    // Start is called before the first frame update
    void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Controls = new PlayerControlls();
        m_Controls.Gameplay.Jump.performed += ctx => JumpListener();
        m_Controls.Gameplay.MoveInPad.performed += ctx => m_MovementVector = new Vector2(ctx.ReadValue<float>(),0);
        m_Controls.Gameplay.MoveInPad.canceled += ctx => m_MovementVector = Vector2.zero;
        
        m_Controls.Gameplay.MoveInArrow.performed += ctx => m_MovementVector = ctx.ReadValue<Vector2>();
        m_Controls.Gameplay.MoveInArrow.canceled += ctx => m_MovementVector = Vector2.zero;
        
    }

    private void OnEnable()
    {
        m_Controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        m_Controls.Gameplay.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsJumping)
        {
            m_Animator.SetFloat("YVelocity", m_RigidBody.velocity.y);
        }
    }
    
    void FixedUpdate()
    {
        Move(m_MovementVector,m_MovementSpeed);
        GroundCheck();
    }
    
    
    private void Move(Vector3  movement , float speed)
    {
        if (!LevelController.m_Instance.GameOverStatus())
        {
            transform.position += movement * Time.deltaTime * speed;
            
            if (movement.x == 0 && !m_IsJumping)
            {
                m_Animator.SetBool("Move", false);
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
        if (!m_IsJumping)
        {
            m_Animator.SetTrigger("Jump");
            EventManager.PlaySoundTrigger(GameDefines.Sounds.Jump);
            m_Animator.SetBool("Move", false);
            CallJump(jumpforce, ForceMode2D.Impulse);
            m_Animator.SetBool("Land", false);
        }
    }
    
    public void CallJump(float jumpforce, ForceMode2D forcemode)
    {
        m_RigidBody.AddForce(new Vector2(0, jumpforce), forcemode);
    }

    public void CallsSpringJump(float jumpforce)
    { m_Animator.SetTrigger("Jump");
        EventManager.PlaySoundTrigger(GameDefines.Sounds.Jump);
        m_Animator.SetBool("Move", false);
        CallJump(jumpforce, ForceMode2D.Impulse);
        m_Animator.SetBool("Land", false);
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

    public void SetIsJumpingStatus(bool isJumpingStatus)
    {
        m_IsJumping = isJumpingStatus;
    }
    public GameDefines.PlayerDirection GetPlayerDirection()
    {
        if (m_RigidBody.velocity.x >= 0)
        {
            return GameDefines.PlayerDirection.RIGHT;
        }

        return GameDefines.PlayerDirection.LEFT;
    }

    private void GroundCheck()
    {
        
        Vector2 hitorigin_1 = new Vector2(gameObject.transform.position.x + m_MinGroundColliderPosition, gameObject.transform.position.y);
        Vector2 hitorigin_2 = new Vector2(gameObject.transform.position.x - m_MaxGroundColliderPosition, gameObject.transform.position.y);
        
        RaycastHit2D hit_1  = Physics2D.Raycast(hitorigin_1, Vector2.down, m_GroundCheckRadios, m_GroundLayer);
        RaycastHit2D hit_2  = Physics2D.Raycast(hitorigin_2, Vector2.down, m_GroundCheckRadios, m_GroundLayer);
        
        Debug.DrawRay(hitorigin_1, Vector2.down * m_GroundCheckRadios);
        Debug.DrawRay(hitorigin_2, Vector2.down * m_GroundCheckRadios);
        
        if (hit_1.collider != null || hit_2.collider != null)
        {
            if (m_IsJumping)
            {
                m_Animator.SetBool("Land", true);
            }

            m_IsJumping = false;
        }
        else
        {
            m_IsJumping = true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "BottomBound")
        {
            LevelController.m_Instance.CallGameOver();
        }
    }


    #region InputListeners

    private void JumpListener()
    {
        Jump(m_JumpForce);
    }
    
    #endregion
}
