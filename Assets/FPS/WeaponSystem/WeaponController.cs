using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    Weapon CurrentWeapon;

    [SerializeField]
    GameObject ReloadCrosshair;
    [SerializeField]
    UnityEngine.UI.Image reloadImage;

    [SerializeField]
    GameObject NormalCrosshair;

    void Start()
    {
        
    }

    void Update()
    {
        if (CurrentWeapon.PlayerInputAction("Fire1"))
        {
            CurrentWeapon.Attack();
        }

        if(CurrentWeapon.IsPossibleToAttack())
        {

        }
    }
}
