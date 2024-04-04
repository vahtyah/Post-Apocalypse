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

    private CountdownTimer timer;
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
        timer = new CountdownTimer(item.Cooldown, true);
        timer.OnTimerStart += () => cooldownImage.fillAmount = 0;
        timer.OnTimerUpdate += f => cooldownImage.fillAmount = f;

        Debug.Log(InGameManager.Instance.GetPlayer().Trigger);
        InGameManager.Instance.GetPlayer().Trigger.OnHitBottleHealth += () => Amount++;
    }

    private void Update()
    {
        timer.Tick(Time.deltaTime);
        if (InputManager.UseConsumable(item.Hotkey) && timer.IsFinished && amount > 0)
        {
            item.Consume();
            timer.Reset();
            Amount--;
        }
    }
    
    public void Save()
    {
        PlayerPrefs.SetInt(saveKey, Amount);
    }
}