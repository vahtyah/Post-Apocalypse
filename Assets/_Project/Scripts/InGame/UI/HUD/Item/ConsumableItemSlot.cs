using System;
using Sirenix.OdinInspector;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ConsumableItemSlot : MonoBehaviour
{
    [SerializeField] private ConsumableItem item;
    [SerializeField, Required] private Image iconImage;
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField, Required] private Image cooldownImage;

    private Timer timer;
    private int amount;
    private string saveKey = "ConsumableHealth";

    public int Amount
    {
        get => amount;
        set
        {
            amount = Mathf.Max(0, value);
            amountText.text = amount.ToString();
        }
    }

    private void Start()
    {
        Amount = PlayerPrefs.GetInt(saveKey, 0); 
        iconImage.sprite = item.Icon;
        
        timer = Timer.Register(item.Cooldown)
            .OnStart(() => cooldownImage.fillAmount = 0)
            .OnProgress(f => cooldownImage.fillAmount = f)
            .StartWithFinish();
        
        InGameManager.Instance.GetPlayer().Trigger.OnHitBottleHealth += () => Amount++;
    }

    private void Update()
    {
        if (InputManager.UseConsumable(item.Hotkey) && timer.IsCompleted && amount > 0)
        {
            item.Consume();
            Amount--;
            timer.Restart();
        }
    }
    
    public void Save()
    {
        PlayerPrefs.SetInt(saveKey, Amount);
    }
}