using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalScoreHandler : MonoBehaviour
{
    private float totalScore;

    public float GetTotalScore()
    {
        return totalScore;
    }

    public float SetTotalScore(float valueToSet)
    {
        totalScore = valueToSet;

        return totalScore;
    }

    public float IncreaseTotalScore(float valueToIncrementWith)
    {
        totalScore += valueToIncrementWith;

        return totalScore;
    }

    public void IncreaseScoreWithoutReturn(float value)
    {
        totalScore += value;
    }
    
    public float DecreaseTotalScore(float valueToDecreaseWith)
    {
        totalScore -= valueToDecreaseWith;

        return totalScore;
    }    
}
