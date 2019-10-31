using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FactoryVisualTextAnimator : MonoBehaviour
{
    [SerializeField] private float scaleAnimationDuration;
    
    public void PlayScaleDownAnimation()
    {
        transform.DOScale(0f, scaleAnimationDuration).OnComplete(DestroyObjectOnAnimationCompleted);
    }

    public void DestroyObjectOnAnimationCompleted()
    {
        Destroy(gameObject);
    }
}
