using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class SelectieModInteractiune : MonoBehaviour
{
    public EventSystem eventSystemActiv;
    public GameObject obiectSelectat;
    private bool butonSelectat;

    
    void Update()
    {
        if (Input.GetAxisRaw("Vertical")!=0 && butonSelectat == false)
        {
            eventSystemActiv.SetSelectedGameObject(obiectSelectat);
            butonSelectat = true;
        }
        
    }

    private void OnDisable()
    {
        butonSelectat=false;
    }
}
