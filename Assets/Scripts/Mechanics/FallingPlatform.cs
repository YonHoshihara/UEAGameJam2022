using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    [SerializeField]
    private float m_TimeToFall;

    [SerializeField]
    private Rigidbody2D m_RigidyBody;

    [SerializeField]
    private TargetJoint2D m_TargetJoint;

    [SerializeField] 
    private BoxCollider2D m_BoxCollider2D;

    [SerializeField]
    private Animator m_Animator;

    private bool m_IsFalling = false;

    private Vector3 m_StartPosition;

    private void Start()
    {
        m_StartPosition = transform.position;
    }

    private void Update()
    {
        if (gameObject.transform.position.y < -30)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_IsFalling)
        {
            return;
        }

        if (collision.relativeVelocity.normalized.y < 0)
        {
            if (collision.gameObject.tag == GameDefines.m_PlayerTag)
            {
                StartCoroutine(Fall());
            }
            else
            {
                m_BoxCollider2D.enabled = false;
                m_TargetJoint.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BottomBound")
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Fall()
    {
        m_IsFalling = true;
        StartCoroutine(ShakeObject(m_StartPosition, 1 , 0.05f));
        yield return new WaitForSeconds(m_TimeToFall);
        m_Animator.enabled = false;
        m_BoxCollider2D.isTrigger = true;
        m_TargetJoint.enabled = false;
    }

    private IEnumerator ShakeObject(Vector3 startPosition, float  duration, float amount)
    {
        float currentShakeDuration = duration;
   

        while (currentShakeDuration > 0)
        {
            float randomX = Random.Range(-amount, amount);
            Vector3 newPosition = startPosition + new Vector3(randomX, 0, 0);
            transform.position = newPosition;
            currentShakeDuration -= Time.deltaTime;
            yield return null;
        }

    
        transform.position = startPosition;

    }

 
}
