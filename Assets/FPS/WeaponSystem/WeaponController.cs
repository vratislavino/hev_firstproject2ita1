using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Weapon CurrentWeapon;

    [SerializeField]
    GameObject ReloadCrosshair;
    [SerializeField]
    UnityEngine.UI.Image reloadImage;

    [SerializeField]
    GameObject NormalCrosshair;

    List<Weapon> weapons;

    private void ChangeWeapon(Weapon newWeapon)
    {
        if(CurrentWeapon != null)
        {
            CurrentWeapon.IsPossibleToAttackChanged -= OnIsPossibleToAttackChanged;
            CurrentWeapon.gameObject.SetActive(false);
        }

        CurrentWeapon = newWeapon;
        CurrentWeapon.gameObject.SetActive(true);
        CurrentWeapon.IsPossibleToAttackChanged += OnIsPossibleToAttackChanged;
        OnIsPossibleToAttackChanged(true);
    }

    private void OnIsPossibleToAttackChanged(bool isPossibleToAttack)
    {
        NormalCrosshair.SetActive(isPossibleToAttack);
        ReloadCrosshair.SetActive(!isPossibleToAttack);
    }

    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>(true).ToList();
        ChangeWeapon(weapons.First());
    }

    void Update()
    {
        if (CurrentWeapon.PlayerInputAction("Fire1"))
        {
            CurrentWeapon.Attack();
        }

        if(!CurrentWeapon.IsPossibleToAttack())
        {
            reloadImage.fillAmount = CurrentWeapon.GetReloadProgress();
        }

        WeaponChanging();
    }

    private void WeaponChanging()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeWeapon(weapons.ElementAt(0));
        if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeWeapon(weapons.ElementAt(1));
        if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeWeapon(weapons.ElementAt(2));
    }
}
