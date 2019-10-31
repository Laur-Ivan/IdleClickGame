using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryVisualTextPositioner : MonoBehaviour
{
    [SerializeField] private float minXValue, maxXValue, minYValue, maxYValue;

    private float xPos;
    private float yPos;

    private Vector3 position;
    
    public Vector3 GetFactoryRandomObjectPositon()
    {
        CalculateXYPos();
        
        position = new Vector3(xPos, yPos, 0f);

        return position;
    }

    void CalculateXYPos()
    {
        xPos = Random.Range(minXValue, maxXValue);
        yPos = Random.Range(minYValue, maxYValue);
    }
}
