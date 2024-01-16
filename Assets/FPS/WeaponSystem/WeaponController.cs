using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    Weapon CurrentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentWeapon.PlayerInputAction("Fire1"))
        {
            CurrentWeapon.Attack();
        }
    }
}
