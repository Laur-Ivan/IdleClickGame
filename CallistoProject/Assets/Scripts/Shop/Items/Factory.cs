using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Factory", menuName = "ScriptableObjects/Shop/Factory", order = 1)]

public class Factory : ScriptableObject
{
    public int id;
    
    public float cost;
    public float scorePerUnitOfTime;
    public float unitOfTime;
    
    public Sprite sprite;

    public GameObject factoryPrefab;
}
