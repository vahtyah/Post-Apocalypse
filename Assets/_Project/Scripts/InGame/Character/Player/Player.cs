using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class Player : SerializedMonoBehaviour
{
    [BoxGroup("Components")]
    [SerializeField] private Rigidbody rb;
    [BoxGroup("Components")]
    [SerializeField] private Animator anim;
    [BoxGroup("Components")]
    [SerializeField] private LayerMask groundMask;
   
    [BoxGroup("Weapon Settings")]
    [SerializeField] private Transform rightHand;
    
    public PlayerAnimationComponent Animation { get; private set; }
    public PlayerMovementComponent Movement { get; private set; }
    public PlayerStateComponent State { get; private set; }
    public PlayerWeaponComponent Weapon { get; private set; }
    public bool IsDead { get; set; }

    private void Awake()
    {
        Animation = new PlayerAnimationComponent(anim);
        Movement = new PlayerMovementComponent(this);
        State = new PlayerStateComponent(this);
        Weapon = new PlayerWeaponComponent(this);
        Weapon.SetWeapon(WeaponType.ScarL);
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
    public Transform GetRightHand() => rightHand;
}