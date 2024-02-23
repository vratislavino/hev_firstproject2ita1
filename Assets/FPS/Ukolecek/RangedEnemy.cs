using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootInterval = 2;
    private float shootCooldown;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        shootCooldown = shootInterval;
    }

    void Update()
    {
        transform.LookAt(player.transform.position + Vector3.up);

        if(shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
            if(shootCooldown <= 0)
            {
                Shoot();
                shootCooldown = shootInterval;
            }
        }
    }

    private void Shoot()
    {
        var b = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        var rb = b.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(b.transform.forward * 15, ForceMode.Impulse);
    }
}
