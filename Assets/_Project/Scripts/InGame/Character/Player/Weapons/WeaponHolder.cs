using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class WeaponHolder : SerializedSingleton<WeaponHolder>
 {
     [SerializeField] private Dictionary<WeaponType, WeaponData> weaponDatas;
     
     public WeaponData GetWeapon(WeaponType type)
     {
         return weaponDatas[type];
     }
 }
 
 public enum WeaponType
 {
     Ak74,
     ScarL,
     Bazooka
 }