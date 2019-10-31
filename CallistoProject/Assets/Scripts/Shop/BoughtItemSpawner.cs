using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoughtItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject factoryPrefab;

    [SerializeField] private Transform factoriesHolder;
    
    private GameObject spawnedFactory;
    
    public GameObject SpawnFactory(GameObject factoryToSpawn)
    {
        spawnedFactory = Instantiate(factoryPrefab, factoriesHolder);

        return spawnedFactory;
    }
}
