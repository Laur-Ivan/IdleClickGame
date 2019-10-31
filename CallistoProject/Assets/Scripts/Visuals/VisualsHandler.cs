using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualsHandler : MonoBehaviour
{
    public ObjectMouseEvents objectMouseEvents;
    public TouchTextHandler touchTextHandler;
    public TouchTextPositioner touchTestPositioner;

    private float scorePerTouch;
    
    void OnEnable()
    {
        objectMouseEvents.OnObjectTouchDown += SpawnVisualObject;
    }

    void OnDisable()
    {
        objectMouseEvents.OnObjectTouchDown -= SpawnVisualObject;    
    }

    public void SetScorePerTouch(float scoreToSet)
    {
        scorePerTouch = scoreToSet;
    }
    
    void SpawnVisualObject()
    {
        GameObject spawnedVisualObject = touchTextHandler.SpawnVisualTouchObject(scorePerTouch, objectMouseEvents.GetTouchDownPosition());

        spawnedVisualObject.transform.position += touchTestPositioner.GetVisualTouchObjectPositon();
        
        spawnedVisualObject.GetComponent<TouchTextAnimation>().PlayScaleDownAnimation();
    }
}
