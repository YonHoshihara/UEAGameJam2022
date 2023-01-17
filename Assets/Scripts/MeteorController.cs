using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [SerializeField] 
    private float m_Time;

    [SerializeField] 
    private Vector3 m_EndDistance;

    [SerializeField] 
    private iTween.EaseType m_AnimationCurve;

    private Hashtable m_Hashtable;

    private void Awake()
    {
        EventManager.startMeteorMovement += MoveMeteor;
        m_Hashtable = new Hashtable();
        m_Hashtable.Add("position", m_EndDistance);
        m_Hashtable.Add("speed", m_Time);
    }
    
    public void MoveMeteor()
    {
        iTween.MoveTo(gameObject, m_Hashtable);
    }

    private void OnDestroy()
    {
        EventManager.startMeteorMovement -= MoveMeteor;
    }
}
