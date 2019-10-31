using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemBuyer : MonoBehaviour
{
    private TotalScoreHandler totalScoreHandler;

    public void SetTotalScoreHandler(TotalScoreHandler totalScore)
    {
        totalScoreHandler = totalScore;
    }

    public bool PlayerHasEnoughScore(float itemCost)
    {
        if (totalScoreHandler.GetTotalScore() >= itemCost)
        {
            return true;
        }

        return false;
    }
}
