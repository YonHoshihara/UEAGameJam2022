using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeWindReaction : MonoBehaviour
{
    enum WindDirection
    {
        LEFT,RIGHT
    }
    
    [SerializeField]
    private FloatVariable m_GameTime;

    [SerializeField]
    private Material m_WindMaterial;

    [SerializeField]
    private WindDirection m_WindDirection;

    [SerializeField]
    private float m_DelayToStartEffect;
    
    private bool m_CanApplyEffect;


    private void Start()
    {
        ResetValues();
        SetWindDirection();
        m_CanApplyEffect = false;
        StartCoroutine(UpdateCanApplyEffect());
    }

    private void Update()
    {

        if (!m_CanApplyEffect)
        {
            return;
        }
        
        UpdateWindEffect();
        
        
    }

    private IEnumerator UpdateCanApplyEffect()
    {
        yield return new WaitForSeconds(m_DelayToStartEffect);
        m_CanApplyEffect = true;
    }
    private void UpdateWindEffect()
    {

        //float currentWindSpeed = Mathf.Abs(m_GameTime.m_Value - (10 - m_DelayToStartEffect)) / 2;
        float currentWindIntensity = Mathf.Abs(m_GameTime.m_Value - (10 - m_DelayToStartEffect)) /( 3*(10 - m_DelayToStartEffect));
        // m_WindMaterial.SetFloat("_WindSpeed", currentWindSpeed);
        m_WindMaterial.SetFloat("_WindIntensity", currentWindIntensity);
    }

    private void SetWindDirection()
    {
        switch (m_WindDirection)
        {
            case WindDirection.LEFT:
                m_WindMaterial.SetFloat("_WindDirection", 2);
                break;
            case WindDirection.RIGHT:
                m_WindMaterial.SetFloat("_WindDirection", 0);
                break;
        }
    }

    private void ResetValues()
    {
        m_WindMaterial.SetFloat("_WindDirection", 1);
        //m_WindMaterial.SetFloat("_WindSpeed", 0);
        m_WindMaterial.SetFloat("_WindIntensity", 0);
    }
    
    private void OnDestroy()
    {
        ResetValues();
    }


}
