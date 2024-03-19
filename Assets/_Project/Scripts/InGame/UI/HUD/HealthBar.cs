﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Gradient color;
    [SerializeField] private Image imageFill;

    [SerializeField] private Enemy enemy;

    private Camera camera;
    private CharacterHealthComponent healthComponent;

    private void Awake()
    {
        camera = Camera.main;
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
        if (camera != null) transform.LookAt(transform.position + camera.transform.forward);
    }

    private void SetColorByFillValue() { imageFill.color = color.Evaluate(imageFill.fillAmount); }

    private void UpdateHealthBar(float currentHealth)
    {
        imageFill.fillAmount = healthComponent.GetHealthAmountNormalized();
        SetColorByFillValue();
        gameObject.SetActive(imageFill.fillAmount < 1);
    }
}