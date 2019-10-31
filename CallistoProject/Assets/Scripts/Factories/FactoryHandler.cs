using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryHandler : MonoBehaviour
{
    private List<IFactory> factories;

    public void StartFactories()
    {
        foreach (IFactory factory in factories)
        {
            factory.StartFactory();
        }
    }
    
    public void AddFactoryToList(IFactory factory)
    {
        factories.Add(factory);
    }    
}
