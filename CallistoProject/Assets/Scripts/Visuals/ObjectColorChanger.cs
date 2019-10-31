using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectColorChanger : MonoBehaviour
{
    private Color defaultColor;
    private Color materialColor;

    private Renderer renderer;
    
    void Awake()
    {
        renderer = GetComponent<Renderer>();
        
        defaultColor = materialColor;
    }
    public void ChangeColor()
    {
        renderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    public async void SetToDefaultColor()
    {
        await Task.Delay(TimeSpan.FromSeconds(0.1f));
        
        renderer.material.color = defaultColor;
    }
}
