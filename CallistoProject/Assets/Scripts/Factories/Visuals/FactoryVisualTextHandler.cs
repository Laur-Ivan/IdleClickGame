using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryVisualTextHandler : MonoBehaviour
{
    public FactoryVisualTextSpawner factoryVisualTextSpawner;
    public FactoryVisualTextPositioner factoryVisualTextPositioner;
    
    public void SpawnVisualObject(float scorePerUnitOfTime)
    {
        GameObject spawnedVisualObject = factoryVisualTextSpawner.SpawnVisualFactoryObject(scorePerUnitOfTime, transform.position);

        spawnedVisualObject.transform.position += factoryVisualTextPositioner.GetFactoryRandomObjectPositon();
        
        spawnedVisualObject.GetComponent<FactoryVisualTextAnimator>().PlayScaleDownAnimation();
    }
}
