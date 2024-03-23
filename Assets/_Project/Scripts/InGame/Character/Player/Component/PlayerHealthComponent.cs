public class PlayerHealthComponent : CharacterHealthComponent<PlayerStats>
{
    public PlayerHealthComponent(PlayerStats stats) : base(stats) { }

    public override void TakeDamage(float _damage)
    {
        var damage = _damage - stats.Armor;
        base.TakeDamage(damage);
    }
}