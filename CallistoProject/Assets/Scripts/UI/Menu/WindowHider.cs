using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WindowHider : MonoBehaviour
{
    private bool hasFocus = false;
    private CanvasGroup cv;
    private bool scheduleShow = false;
    
    public void Awake() 
    {
        cv = GetComponent<CanvasGroup>();
    }
     
    public void Update() 
    {
        if (!scheduleShow && !hasFocus) 
        {
            if (Input.GetMouseButtonUp(0) && !ButtonIsUnderGameobject())
            {
                cv.alpha = 0;
                cv.blocksRaycasts = false;                
            }
        } 
        else if (scheduleShow) 
        {
            cv.alpha = 1;
            cv.blocksRaycasts = true;
            scheduleShow = false;
        }
    }
 
    public void Show() 
    {
        scheduleShow = true;            
    }
  
    public void OnPointerExit(PointerEventData eventData)
    {
        hasFocus = false;   
    }
 
    public void OnPointerEnter(PointerEventData eventData) 
    {      
        hasFocus = true;               
    }
    
    public bool ButtonIsUnderGameobject()
    {
        PointerEventData pointerData = new PointerEventData (EventSystem.current)
        {
            pointerId = -1,
        };
         
        pointerData.position = Input.mousePosition;
 
        List<RaycastResult> results = new List<RaycastResult>();
        
        EventSystem.current.RaycastAll(pointerData, results);
         
        foreach(RaycastResult raycastResult in results)
        {            
            if (raycastResult.gameObject.GetComponent<Button>() != null)
            {
                return true;
            }
        }
         
        return false;
    }
}
