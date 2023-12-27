using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeiserPlatform : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals(GameDefines.m_PlayerTag))
        {
            col.gameObject.transform.parent = gameObject.transform;
        }
    }
    
    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals(GameDefines.m_PlayerTag))
        {
            col.gameObject.transform.parent = null;
        }
    }
}
