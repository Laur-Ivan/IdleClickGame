using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemBuyEvent : MonoBehaviour
{
    public Button buyButton;

    public event Action<GameObject> OnBuyButtonClicked;

    public void BuyButtonClickedHandler(GameObject item)
    {
        OnBuyButtonClicked?.Invoke(item);
    }
}
