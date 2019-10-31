using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FactoryVisualTextSpawner : MonoBehaviour
{
    [SerializeField] private GameObject visualFactoryObjectPrefab;
    private Transform visualFactoryObjectsHolder;

    private GameObject visualObjectSpawned;

    public GameObject SpawnVisualFactoryObject(float touchScoreValue, Vector3 touchPosition)
    {
        visualObjectSpawned = Instantiate(visualFactoryObjectPrefab, touchPosition, Quaternion.identity);

        visualObjectSpawned.transform.SetParent(visualFactoryObjectsHolder);

        SetSpawnedVisualFactoryObjectText(touchScoreValue);

        return visualObjectSpawned;
    }

    private void SetSpawnedVisualFactoryObjectText(float touchScoreValue)
    {
        TextMeshProUGUI visualObjectText = visualObjectSpawned.GetComponent<TextMeshProUGUI>();

        visualObjectText.text = touchScoreValue.ToString();
    }

    public void SetVisualFactoryObjectsHolder(Transform holder)
    {
        visualFactoryObjectsHolder = holder;
    }
}
