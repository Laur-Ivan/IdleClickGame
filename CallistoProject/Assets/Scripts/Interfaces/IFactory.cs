using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory
{
    event Action<float> OnUnitOfTimePassed;

    void StartFactory();

    void SetTotalScoreHandler(TotalScoreHandler totalScoreHandler);

    void SetTotalScoreVisual(TotalScoreVisual totalScoreVisual);
}
