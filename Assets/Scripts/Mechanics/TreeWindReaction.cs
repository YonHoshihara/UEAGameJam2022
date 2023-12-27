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

    private void Start()
    {
        ResetValues();
        SetWindDirection();
    }

    private void Update()
    {
        UpdateWindEffect();
    }

    private void UpdateWindEffect()
    {
        float currentWindSpeed = Mathf.Abs(m_GameTime.m_Value - 10) / 2;
        float currentWindIntensity = Mathf.Abs(m_GameTime.m_Value - 10) / 20;

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
