using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgressHandler : MonoBehaviour
{
    //!For now we use PlayerPrefs and save data to a dictionary
    //TO DO: serialize the data to a JSON(?) and send it to a database(Playfab?) and then retrieve it
    private Dictionary<string, float> playerData = new Dictionary<string, float>();
    
    [SerializeField] private float defaultScorePerTouch;

    [SerializeField]
    private float timeBetweenSaving;

    [SerializeField] private TotalScoreHandler totalScoreHandler;
    
    private float tempTime;
    
    private bool startSaving;

    void Awake()
    {
        tempTime = timeBetweenSaving;
    }

    private void Start()
    {
        StartPeriodicalSaving();
    }

    private void Update()
    {
        if (startSaving)
        {
            tempTime -= Time.deltaTime;

            if (tempTime <= 0)
            {
                SaveTotalScore(totalScoreHandler.GetTotalScore());

                tempTime = timeBetweenSaving;
            }
        }
    }

    public void StartPeriodicalSaving()
    {
        startSaving = true;
    }

    public void CheckForData()
    {
        if (PlayerPrefs.HasKey("ScorePerTouch"))
        {
            playerData.Add("ScorePerTouch", PlayerPrefs.GetFloat("ScorePerTouch"));
        }

        else
        {
            playerData.Add("ScorePerTouch", defaultScorePerTouch);
        }
        
        if (PlayerPrefs.HasKey("TotalScore"))
        {
            playerData.Add("TotalScore", PlayerPrefs.GetFloat("TotalScore"));
        }

        else
        {
            playerData.Add("TotalScore", 0);
        }
    }

    public Dictionary<string, float> GetPlayerData()
    {
        return playerData;
    }

    public void SaveScorePerTouch(float valueToSet)
    {
        PlayerPrefs.SetFloat("ScorePerTouch", valueToSet);
        PlayerPrefs.Save();
    }

    public void SaveTotalScore(float totalScore)
    {
        PlayerPrefs.SetFloat("TotalScore", totalScore);
        PlayerPrefs.Save();
    }
}
