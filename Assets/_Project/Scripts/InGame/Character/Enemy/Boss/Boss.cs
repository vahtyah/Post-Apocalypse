using System;
using System.Collections;
using BehaviorDesigner.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField, BoxGroup("Components")] private BehaviorTree behaviorTree;

    private void Start()
    {
        Attack = new EnemyMeleeAttackComponent(this);
        Health.AddOnDieListener(() =>
        {
            behaviorTree.enabled = false;
            Action.SetEnableCollider(false);
            Action.Stop();
            Animation.Play(EnemyAnimationState.Die.ToString());
            StartCoroutine(IEInvisible());
        });
    }

    public override void Reset()
    {
        base.Reset();
        behaviorTree.enabled = true;
        Action.SetEnableCollider(true);
    }

    private IEnumerator IEInvisible()
    {
        yield return new WaitForSeconds(2f);
        EnemyFactory.Destroy(this);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10);
        Gizmos.DrawWireSphere(transform.position, 20);
    }
}
