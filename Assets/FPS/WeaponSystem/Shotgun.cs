using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : RangedWeapon
{
    [SerializeField]
    protected int BulletCount = 5;

    [SerializeField]
    protected float Spread = 0.2f;

    protected override void Start()
    {
        base.Start();
        PlayerInputAction = Input.GetButtonDown;
    }

    protected override void Shoot()
    {
        for (int i = 0; i < BulletCount; i++)
        {
            var bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
            bullet.transform.Rotate(Random.Range(-Spread,Spread), Random.Range(-Spread, Spread), Random.Range(-Spread, Spread));
            bullet.AddForce(bullet.transform.forward * 100, ForceMode.Impulse);
            Destroy(bullet.gameObject, 4f);
        }
    }
}
