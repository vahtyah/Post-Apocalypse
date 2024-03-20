using System;
using DG.Tweening;
using UnityEngine;

public class HealthBarPlayer : MonoBehaviour
{
    [SerializeField] private Transform underHealthBar, overHealthBar;
    [SerializeField] private float smothTime = .5f;
    private Player player;

    private void Start()
    {
        player = InGameManager.Instance.GetPlayer();
        player.Health.AddOnChangeHealthListener(UpDateHealthBar);
    }

    private void UpDateHealthBar(float obj)
    {
        var healthAmountNormalized = player.Health.GetHealthAmountNormalized();
        overHealthBar.localScale = new Vector3(healthAmountNormalized, 1f, 1f);
        underHealthBar.DOScaleX(healthAmountNormalized, smothTime);
    }
}
