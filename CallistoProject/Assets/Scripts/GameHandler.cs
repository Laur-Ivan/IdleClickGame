using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public ScorePerTouchHandler scorePerTouchHandler;
    public TotalScoreHandler totalScoreHandler;
    public TotalScoreVisual totalScoreVisual;
    public PlayerProgressHandler playerProgressHandler;
    public ObjectMouseEvents objectMouseEvents;
    public VisualsHandler visualsHandler;

    private void Awake()
    {
        playerProgressHandler.CheckForData();
        
        Dictionary<string, float> playerData = playerProgressHandler.GetPlayerData();

        totalScoreHandler.SetTotalScore(playerData["TotalScore"]);
        scorePerTouchHandler.SetScorePerTouch(playerData["ScorePerTouch"]);
        totalScoreVisual.SetTotalScoreText(playerData["TotalScore"]);
        
        SetVisualTouchObjectScoreTextValue();
    }

    void OnEnable()
    {
        objectMouseEvents.OnObjectTouchDown += HandleObjectTouchedScore;
    }

    void OnDisable()
    {
        objectMouseEvents.OnObjectTouchDown -= HandleObjectTouchedScore;    
    }

    void HandleObjectTouchedScore()
    {
        float totalScore = totalScoreHandler.IncreaseTotalScore(scorePerTouchHandler.GetScorePerTouch());
        
        //to do: update the score visual text every X seconds
        totalScoreVisual.SetTotalScoreText(totalScore);
        
        playerProgressHandler.SaveTotalScore(totalScore);
    }

    void SetVisualTouchObjectScoreTextValue()
    {
        visualsHandler.SetScorePerTouch(scorePerTouchHandler.GetScorePerTouch());
    }
}
