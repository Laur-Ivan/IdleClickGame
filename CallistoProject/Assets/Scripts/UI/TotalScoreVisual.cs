using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalScoreVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalScoreText;

    public void SetTotalScoreText(float valueToSet)
    {
        totalScoreText.text = valueToSet.ToString();
    }

    public void IncreaseTotalScoreText(float value)
    {
        string totalScore = this.totalScoreText.text;

        totalScoreText.text = (float.Parse(totalScore) + value).ToString();
    }
}
