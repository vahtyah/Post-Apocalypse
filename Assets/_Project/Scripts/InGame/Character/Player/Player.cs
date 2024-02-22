using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class Player : MonoBehaviour
{
    [BoxGroup("Components")]
    [SerializeField] private Rigidbody rb;
    [BoxGroup("Components")]
    [SerializeField] private Animator anim;
    [BoxGroup("Components")]
    [SerializeField] private LayerMask groundMask;
    
    
    public PlayerAnimationComponent Animation { get; private set; }
    public PlayerMovementComponent Movement { get; private set; }
    public PlayerStateComponent State { get; private set; }
    public bool IsDead { get; set; }

    private void Awake()
    {
        Animation = new PlayerAnimationComponent(anim);
        Movement = new PlayerMovementComponent(this);
        State = new PlayerStateComponent(this);
    }

    private void Update()
    {
        State.Update();
    }
    
    private void FixedUpdate()
    {
        State.FixedUpdate();
    }

    public Rigidbody GetRb() => rb;
    public LayerMask GetGroundMask() => groundMask;
}