using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePerTouchHandler : MonoBehaviour
{
    [SerializeField]private float scorePerTouch;

    public float GetScorePerTouch()
    {
        return scorePerTouch;
    }

    public void IncrementScorePerTouch(float valueToIncrementWith)
    {
        scorePerTouch += valueToIncrementWith;
    }

    public void MultiplyScorePerTouch(float valueToMultiplyWith)
    {
        scorePerTouch *= valueToMultiplyWith;
    }

    public void SetScorePerTouch(float valueToSet)
    {
        scorePerTouch = valueToSet;
    }
}
