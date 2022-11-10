using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geiser : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;

    [SerializeField]
    private string m_TrigerAnimation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(GameDefines.m_PlayerTag) && !LevelController.m_Instance.GameOverStatus())
        {
            m_Animator.SetTrigger(m_TrigerAnimation);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(GameDefines.m_PlayerTag) && !LevelController.m_Instance.GameOverStatus())
        {
            m_Animator.SetTrigger(m_TrigerAnimation);

        }
    }
}
