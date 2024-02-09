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
            RaiseIsPossibleToAttackChanged(false);
        }

        if(currentReloadTime > 0)
        {
            currentReloadTime -= Time.deltaTime;
            if(currentReloadTime <= 0) {
                currentAmmo = MaxAmmo;
                RaiseIsPossibleToAttackChanged(true);
            }
        }

        if(shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public override void ResetReloadProgess()
    {
        currentReloadTime = ReloadTime;
    }

    public override float GetReloadProgress()
    {
        return currentReloadTime / ReloadTime;
    }

    public override bool IsPossibleToAttack()
    {
        return currentReloadTime <= 0;
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
