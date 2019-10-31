using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandler : MonoBehaviour
{
    public ShopItemsSpawner shopItemsSpawner;
    public ShopItemBuyer shopItemBuyer;
    public TotalScoreHandler totalScoreHandler;
    public TotalScoreVisual totalScoreVisual;
    public BoughtItemSpawner boughtItemSpawner;
    public PlayerProgressHandler playerProgressHandler;
    
    public List<Factory> shopFactoryList;

    private List<GameObject> spawnedFactories;

    [SerializeField] private Transform factoryVisualTextsHolder;

    void Awake()
    {
        shopItemsSpawner.SetFactoryList(shopFactoryList);
        
        shopItemsSpawner.SpawnItems();
                
        spawnedFactories = shopItemsSpawner.GetSpawnedFactories();
        
        shopItemBuyer.SetTotalScoreHandler(totalScoreHandler);
    }

    void Start()
    {
        
    }

    private void OnEnable()
    {        
        foreach (GameObject factory in spawnedFactories)
        {
            factory.GetComponent<ShopItemBuyEvent>().OnBuyButtonClicked += HandleItemBought;
        }
    }

    private void OnDisable()
    {
        foreach (GameObject factory in spawnedFactories)
        {
            if (factory != null)
            {
                factory.GetComponent<ShopItemBuyEvent>().OnBuyButtonClicked -= HandleItemBought;
            }
        }
    }

    private void HandleItemBought(GameObject item)
    {
        FactoryShopApplier factoryShopApplier = item.GetComponent<FactoryShopApplier>();

        if (shopItemBuyer.PlayerHasEnoughScore(factoryShopApplier.cost))
        {
            float totalScore = totalScoreHandler.DecreaseTotalScore(factoryShopApplier.cost);

            totalScoreVisual.SetTotalScoreText(totalScore);
            
            playerProgressHandler.SaveTotalScore(totalScore);
            
            BasicFactory basicFactory = boughtItemSpawner.SpawnFactory(factoryShopApplier.gameObject).GetComponent<BasicFactory>();
            
            basicFactory.GetComponent<FactoryVisualTextSpawner>().SetVisualFactoryObjectsHolder(factoryVisualTextsHolder);
            
            basicFactory.SetTotalScoreHandler(totalScoreHandler);
            
            basicFactory.SetTotalScoreVisual(totalScoreVisual);
            
            basicFactory.SetProductionValues(factoryShopApplier.scorePerUnitOfTime, factoryShopApplier.unitOfTime);
            
            basicFactory.SetOnUnitOfTimePassedEventHandlers();
            
            basicFactory.StartFactory();
        }
    }
}
