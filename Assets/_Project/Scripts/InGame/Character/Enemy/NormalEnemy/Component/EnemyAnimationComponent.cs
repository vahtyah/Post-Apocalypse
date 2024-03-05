using UnityEngine;

public class EnemyAnimationComponent
{
    private readonly Animator animator;

    public EnemyAnimationComponent(Animator animator)
    {
        this.animator = animator;
    }

    // public void Play(string animName)
    // {
    //     if (animator.GetCurrentAnimatorStateInfo(0).IsName(animName)) return;
    //     animator.Play(animName);
    // }
    
    public void Play(string animName)
    {
        animator.Play(animName, -1, 0f);
        animator.Update(0f); // Cập nhật trạng thái animator ngay lập tức
    }
}