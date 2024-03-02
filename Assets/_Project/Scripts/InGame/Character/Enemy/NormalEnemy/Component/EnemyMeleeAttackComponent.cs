public class EnemyMeleeAttackComponent : IAttackComponent
{
    public bool CanAttack() { throw new System.NotImplementedException(); }

    public void Attack() { throw new System.NotImplementedException(); }
}

public interface IAttackComponent
{
    bool CanAttack();
    void Attack();
}
