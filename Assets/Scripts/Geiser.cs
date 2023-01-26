using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Geiser : MonoBehaviour
{
    private PlayerMovement m_PlayerMovement;
    
    [SerializeField] 
    private GameObject m_GeiserFinalPosition;

    [SerializeField] 
    private GameObject m_Geiser;

    [SerializeField] 
    private float m_AnimationTime;
    
    [SerializeField] 
    private float m_DelayGaiserAnimation;
    
    [SerializeField] 
    private float m_DisableGeiserTime;
    
    private Vector3 m_GeiserStartPosition;
    
    private Hashtable m_Hashtable;

    [SerializeField] 
    private BoxCollider2D m_GeiserPlatformCollider;
    
    private void Start()
    {
        m_GeiserStartPosition = m_Geiser.transform.position;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals(GameDefines.m_PlayerTag) && !LevelController.m_Instance.GameOverStatus())
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            m_GeiserPlatformCollider.enabled = true;
            iTween.MoveTo(m_Geiser, iTween.Hash(
                "position", m_GeiserFinalPosition.transform.position,
                "speed", m_AnimationTime,
                "oncompletetarget", gameObject,
                "oncomplete", "ResetGeiser",
                "delay", m_DelayGaiserAnimation));
        }
    }

    private IEnumerator BackToStartPosition()
    {
        yield return new WaitForSeconds(m_DisableGeiserTime);
        iTween.MoveTo(m_Geiser, m_GeiserStartPosition, m_AnimationTime);
        m_GeiserPlatformCollider.enabled = false;
    }

    void ResetGeiser()
    {
        StartCoroutine(BackToStartPosition());
    }
}
