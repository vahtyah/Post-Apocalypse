using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

public class Player : SerializedSingleton<Player>
{
    [BoxGroup("Enemy Stats"), HideLabel, NonSerialized, OdinSerialize, HideReferenceObjectPicker]
    public PlayerStats Stats = new();
    
    [SerializeField, BoxGroup("Components")] private Rigidbody rb;
    [SerializeField, BoxGroup("Components")] private Animator anim;
    [SerializeField, BoxGroup("Components")] private LayerMask groundMask;
   
    [SerializeField, BoxGroup("Weapon Settings")] private Transform rightHand;
    
    [SerializeField, BoxGroup("Debugs")] private float currentHealth;
    [SerializeField, BoxGroup("Debugs")] private string currentState;

    #region Components

    public PlayerAnimationComponent Animation { get; private set; }
    public PlayerMovementComponent Movement { get; private set; }
    public PlayerStateComponent State { get; private set; }
    public PlayerWeaponComponent Weapon { get; private set; }
    public PlayerHealthComponent Health { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();
        Animation = new PlayerAnimationComponent(anim);
        Movement = new PlayerMovementComponent(this);
        Weapon = new PlayerWeaponComponent(this);
        Health = new PlayerHealthComponent(Stats);
        State = new PlayerStateComponent(this);
    }

    // private void Start()
    // {
    //     Weapon.SetWeapon(WeaponType.ScarL);
    // }

    private void Update()
    {
        State.Update();
        currentHealth = Health.CurrentHealth;
        currentState = State.GetState().GetType().ToString();
    }
    
    private void FixedUpdate()
    {
        State.FixedUpdate();
    }

    public Rigidbody GetRb() => rb;
    public LayerMask GetGroundMask() => groundMask;
    public Transform GetRightHand() => rightHand;
}