
using System.Collections;
using UnityEngine;

public class EnemyDieState : EnemyState
{
    public EnemyDieState(Enemy enemy) : base(enemy) { }

    protected override EnemyAnimationState AnimationState => EnemyAnimationState.Die;

    public override void OnEnter()
    {
        base.OnEnter();
        enemy.StartCoroutine(IEInvisible());
    }

    private IEnumerator IEInvisible()
    {
        yield return new WaitForSeconds(2f);
        EnemyFactory.Destroy(enemy);
    }
}