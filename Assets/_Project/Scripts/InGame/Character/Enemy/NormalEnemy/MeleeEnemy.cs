public class MeleeEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        Attack = new EnemyMeleeAttackComponent(this);
    }
}