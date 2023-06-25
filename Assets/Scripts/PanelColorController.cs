using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelColorController : MonoBehaviour
{
   [SerializeField] 
   private Image m_Image;
   
   [SerializeField] 
   private Color m_FinalColor;
   
   [SerializeField] 
   private float m_Time;
   private void Awake()
   {
      EventManager.startMeteorMovement += ChangeColor;
   }

   private void OnDestroy()
   {
      EventManager.startMeteorMovement -= ChangeColor;
   }

   private void ChangeColor()
   {
      LeanTween.color(m_Image.rectTransform, m_FinalColor, m_Time);
   }
}
