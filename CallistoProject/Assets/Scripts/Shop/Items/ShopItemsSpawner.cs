using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemsSpawner : MonoBehaviour
{
    public GameObject shopFactoryPrefab;
    
    private List<Factory> shopFactoryList;

    [SerializeField] private Transform shopFactoriesHolder;

    private List<GameObject> spawnedFactories;
    
    private GameObject spawnedFactory;

    void Awake()
    {
        spawnedFactories = new List<GameObject>();
    }
    
    public void SetFactoryList(List<Factory> list)
    {
        shopFactoryList = list;
    }
    
    public void SpawnItems()
    {
        SpawnFactories();    
    }
    
    void SpawnFactories()
    {
        foreach (Factory factory in shopFactoryList)
        {
            spawnedFactory = Instantiate(shopFactoryPrefab, shopFactoriesHolder);
            
            spawnedFactory.GetComponent<FactoryShopApplier>().ApplyFactoryData(factory);
            
            spawnedFactories.Add(spawnedFactory);
        }
    }

    public List<GameObject> GetSpawnedFactories()
    {
        return spawnedFactories;
    }
}
