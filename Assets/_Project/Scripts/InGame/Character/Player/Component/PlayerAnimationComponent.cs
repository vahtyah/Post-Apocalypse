using UnityEngine;

public class PlayerAnimationComponent
{
    private Animator anim;

    public PlayerAnimationComponent(Animator anim) { this.anim = anim; }

    public void BlendMove(float horizontal, float vertical)
    {
        anim.SetFloat("MoveX", horizontal);
        anim.SetFloat("MoveY", vertical);
    }

    public void Play(string animName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(animName)) return;
        anim.Play(animName);
    }
}