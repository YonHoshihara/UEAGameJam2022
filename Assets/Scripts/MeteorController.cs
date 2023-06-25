using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorController : MonoBehaviour
{
    [SerializeField] 
    private Vector3 m_MeteorVelocity;

    [SerializeField] 
    private Rigidbody2D m_Rb;

    private Hashtable m_Hashtable;

    private void Start()
    {
        m_Rb.velocity = m_MeteorVelocity * Random.Range(1,2);
    }
    
}
