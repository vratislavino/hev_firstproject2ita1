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
    protected float FireRate;
    protected float shootCooldown;

    [SerializeField]
    protected Transform BulletSpawn;

    [SerializeField]
    protected Rigidbody BulletPrefab;

    protected override void Start()
    {
        base.Start();
        currentAmmo = MaxAmmo;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Reload"))
        {
            currentReloadTime = ReloadTime;
        }

        if(currentReloadTime > 0)
        {
            currentReloadTime -= Time.deltaTime;
            if(currentReloadTime <= 0) {
                currentAmmo = MaxAmmo;
            }
        }

        if(shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public override void Attack()
    {
        if(currentAmmo > 0 && currentReloadTime <= 0 && shootCooldown <= 0)
        {
            Shoot();
            shootCooldown = FireRate;
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
