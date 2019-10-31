using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BasicFactory : MonoBehaviour, IFactory
{
    [SerializeField] private FactoryVisualTextHandler factoryVisualTextHandler;
    
    [SerializeField] private TotalScoreHandler totalScoreHandler;
    [SerializeField] private TotalScoreVisual totalScoreVisual;
    
    [SerializeField] private float scorePerUnitOfTime;
    [SerializeField] private float unitOfTime;

    private float tempTimer;
    
    public event Action<float> OnUnitOfTimePassed;

    [SerializeField]private bool startFactory;

    void OnEnable()
    {
        /*OnUnitOfTimePassed += factoryVisualTextHandler.SpawnVisualObject;

        OnUnitOfTimePassed += totalScoreHandler.IncreaseScoreWithoutReturn;

        OnUnitOfTimePassed += totalScoreVisual.IncreaseTotalScoreText;*/
    }

    void OnDisable()
    {
        OnUnitOfTimePassed -= factoryVisualTextHandler.SpawnVisualObject;
        
        OnUnitOfTimePassed -= totalScoreHandler.IncreaseScoreWithoutReturn;
        
        OnUnitOfTimePassed -= totalScoreVisual.IncreaseTotalScoreText;
    }

    public void SetOnUnitOfTimePassedEventHandlers()
    {
        OnUnitOfTimePassed += factoryVisualTextHandler.SpawnVisualObject;

        OnUnitOfTimePassed += totalScoreHandler.IncreaseScoreWithoutReturn;

        OnUnitOfTimePassed += totalScoreVisual.IncreaseTotalScoreText;
    }
    
    public void StartFactory()
    {
        tempTimer = unitOfTime;
        
        startFactory = true;
    }

    public void SetTotalScoreHandler(TotalScoreHandler totalScoreHandler)
    {
        this.totalScoreHandler = totalScoreHandler;
    }

    public void SetTotalScoreVisual(TotalScoreVisual totalScoreVisual)
    {
        this.totalScoreVisual = totalScoreVisual;
    }

    public void SetProductionValues(float scorePerUnitOfTime, float unitOfTime)
    {
        this.scorePerUnitOfTime = scorePerUnitOfTime;

        this.unitOfTime = unitOfTime;
    }


    public void StopFactory()
    {
        startFactory = false;
    }
    
    void Update()
    {
        if (startFactory)
        {
            tempTimer -= Time.deltaTime;

            if (tempTimer <= 0)
            {
                OnUnitOfTimePassed?.Invoke(scorePerUnitOfTime);

                tempTimer = unitOfTime;
            }
        }
    }

}
