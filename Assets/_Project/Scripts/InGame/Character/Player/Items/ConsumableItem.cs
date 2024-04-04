using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsumableItem", menuName = "ScriptableObjects/ConsumableItem", order = 1)]
public class ConsumableItem : Item
{
    public KeyCode Hotkey;
    public float Cooldown;
    public IEffecable[] Effects;

    public bool ConsumeOverTime;

    [HideLabel]
    [SuffixLabel("seconds ", true), EnableIf("ConsumeOverTime")]
    [LabelWidth(20)]
    public float Duration;

    public void Consume()
    {
        if (ConsumeOverTime)
        {
            ApplyEffects(Vector3.zero, Duration); //TODO: fix this
        }
        else
        {
            ApplyEffects(InGameManager.Instance.GetPlayer().transform.position);
        }
    }

    private void ApplyEffects(Vector3 position)
    {
        foreach (var effect in Effects)
        {
            effect.ApplyEffect(position);
        }
    }

    private void ApplyEffects(Vector3 position, float duration)
    {
        foreach (var effect in Effects)
        {
            UnityTimer.Timer.Register(Duration, 
                onUpdate: f => Debug.Log(f),
                onComplete: () => Debug.Log("Effect finished"));
        }
    }
}

public interface IEffecable
{
    void ApplyEffect(Vector3 position);
}

public class HealthPotion : IEffecable
{
    public int healAmount;
    public ParticleType typeEffect;

    public void ApplyEffect(Vector3 position)
    {
        InGameManager.Instance.GetPlayer().Health.Heal(healAmount);
        ParticleFactory.Create(typeEffect, InGameManager.Instance.GetPlayer().transform);
    }
}

