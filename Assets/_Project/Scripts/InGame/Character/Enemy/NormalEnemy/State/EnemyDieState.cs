
using System.Collections;
using UnityEngine;

public class EnemyDieState : EnemyState
{
    public EnemyDieState(Enemy enemy) : base(enemy) { }

    protected override EnemyAnimationState AnimationState => EnemyAnimationState.Die;

    public override void OnEnter()
    {
        base.OnEnter();
        enemy.Action.SetEnableCollider(false);
        enemy.StartCoroutine(IEInvisible());
    }

    public override void OnExit()
    {
        base.OnExit();
        enemy.Action.SetEnableCollider(true);
    }

    private IEnumerator IEInvisible()
    {
        yield return new WaitForSeconds(2f);
        enemy.Action.DropItems();
        EnemyFactory.Destroy(enemy);
    }
}