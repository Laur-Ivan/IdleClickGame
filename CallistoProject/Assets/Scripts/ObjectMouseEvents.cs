using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectMouseEvents : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{
    public event Action OnObjectTouchDown;
    public event Action OnObjectTouchUp;

    private Vector3 touchDownPosition;
    
    //private Vector3 touchUpPosition;

    public void OnPointerDown(PointerEventData eventData)
    {        
        touchDownPosition = eventData.position;

        OnObjectTouchDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnObjectTouchUp?.Invoke();
    }

    public Vector3 GetTouchDownPosition()
    {
        return touchDownPosition;
    }
   
}
