using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetSelectedButton : MonoBehaviour
{

    [SerializeField] 
    private GameObject m_SelectedButton;
    // Start is called before the first frame update
    void OnEnable()
    {
       EventSystem.current.SetSelectedGameObject(m_SelectedButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
