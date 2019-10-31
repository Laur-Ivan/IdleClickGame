using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FactoryShopApplier : MonoBehaviour
{
    public Image factoryImage;

    [HideInInspector]public float id, cost, scorePerUnitOfTime, unitOfTime;
    
    public TextMeshProUGUI costText, scorePerUnitOfTimeText, unitOfTimeText;

    public Factory factoryToSpawn;
    public void ApplyFactoryData(Factory factory)
    {
        factoryImage.sprite = factory.sprite;

        id = factory.id;
        
        cost = factory.cost;

        scorePerUnitOfTime = factory.scorePerUnitOfTime;

        unitOfTime = factory.unitOfTime;
        
        costText.text = "Cost: " + cost;
        
        scorePerUnitOfTimeText.text = "Score per unit of time: " + scorePerUnitOfTime;

        unitOfTimeText.text = "Unit of time: " + unitOfTime;

        factoryToSpawn = factory;
    }
}
