using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    [SerializeField]
    protected int MaxAmmo;
    protected int currentAmmo;

    [SerializeField]
    protected float ReloadTime;
    protected float currentReloadTime;

    [SerializeField]
    protected Transform BulletSpawn;

    [SerializeField]
    protected Rigidbody BulletPrefab;

    protected override void Start()
    {
        base.Start();
        currentAmmo = MaxAmmo;
    }

    public override void Attack()
    {
        if(currentAmmo > 0 && currentReloadTime <= 0)
        {
            Shoot();
            currentAmmo--;
        }
    }

    protected virtual void Shoot()
    {
        var bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
        bullet.AddForce(bullet.transform.forward * 100, ForceMode.Impulse);
        Destroy(bullet.gameObject, 4f);
    }
}
