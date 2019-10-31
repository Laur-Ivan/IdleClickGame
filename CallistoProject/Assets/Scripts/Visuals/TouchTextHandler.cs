using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchTextHandler : MonoBehaviour
{
    [SerializeField] private GameObject visualTouchObjectPrefab;
    [SerializeField] private Transform visualTouchObjectsHolder;

    private GameObject visualObjectSpawned;

    public GameObject SpawnVisualTouchObject(float touchScoreValue, Vector3 touchPosition)
    {
        visualObjectSpawned = Instantiate(visualTouchObjectPrefab, touchPosition, Quaternion.identity); 
        
        visualObjectSpawned.transform.SetParent(visualTouchObjectsHolder);
        
        SetSpawnedVisualTouchObjectText(touchScoreValue);

        return visualObjectSpawned;
    }

    private void SetSpawnedVisualTouchObjectText(float touchScoreValue)
    {
        TextMeshProUGUI visualObjectText = visualObjectSpawned.GetComponent<TextMeshProUGUI>();

        visualObjectText.text = touchScoreValue.ToString();
    }
}
