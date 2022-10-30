using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    [SerializeField]
    private float m_TimeToFall;

    [SerializeField]
    private Rigidbody2D m_RigidyBody;

    [SerializeField]
    private TargetJoint2D m_TargetJoint;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameDefines.m_PlayerTag)
        {
            StartCoroutine(Fall());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(m_TimeToFall);
        m_TargetJoint.enabled = false;
      
    }
}
