using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Gradient color;
    [SerializeField] private Image imageFill;

    [SerializeField] private Enemy enemy;

    private Camera mainCamera;
    private CharacterHealthComponent<EnemyStats> healthComponent;

    private void Start()
    {
        mainCamera = Camera.main;
        healthComponent = enemy.Health;
        healthComponent.AddOnChangeHealthListener(UpdateHealthBar);
        healthComponent.AddOnDieListener(() =>
        {
            gameObject.SetActive(false);
        });
        UpdateHealthBar(1);
    }
    private void Update()
    {
        if (mainCamera != null) transform.LookAt(transform.position + mainCamera.transform.forward);
    }

    private void UpdateHealthBar(float currentHealth)
    {
        imageFill.fillAmount = healthComponent.GetHealthAmountNormalized();
        SetColorByFillValue();
        gameObject.SetActive(imageFill.fillAmount < 1);
    }

    private void SetColorByFillValue() { imageFill.color = color.Evaluate(imageFill.fillAmount); }
}