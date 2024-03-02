using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

public class Player : SerializedMonoBehaviour
{
    [BoxGroup("Enemy Stats"), HideLabel, NonSerialized, OdinSerialize, HideReferenceObjectPicker]
    public PlayerStats Stats = new();
    
    [SerializeField, BoxGroup("Components")] private Rigidbody rb;
    [SerializeField, BoxGroup("Components")] private Animator anim;
    [SerializeField, BoxGroup("Components")] private LayerMask groundMask;
   
    [SerializeField, BoxGroup("Weapon Settings")] private Transform rightHand;
    
    public PlayerAnimationComponent Animation { get; private set; }
    public PlayerMovementComponent Movement { get; private set; }
    public PlayerStateComponent State { get; private set; }
    public PlayerWeaponComponent Weapon { get; private set; }
    public CharacterHealthComponent Health { get; private set; }
    public bool IsDead { get; set; }

    private void Awake()
    {
        Animation = new PlayerAnimationComponent(anim);
        Movement = new PlayerMovementComponent(this);
        Weapon = new PlayerWeaponComponent(this);
        Health = new CharacterHealthComponent(Stats.Health);
        State = new PlayerStateComponent(this);
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