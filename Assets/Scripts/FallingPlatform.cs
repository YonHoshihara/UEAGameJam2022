using System;
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

    private void Update()
    {
        if (gameObject.transform.position.y < -30)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "BottomBound")
        {
            Destroy(gameObject);
        }
        
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

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(m_TimeToFall);
        m_BoxCollider2D.enabled = false;
        m_TargetJoint.enabled = false;
    }
}
