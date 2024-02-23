using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private float speed = 2;
    Rigidbody rb;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position + Vector3.up);

        var fw = transform.forward;
        fw.y = 0;
        rb.velocity = fw * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player.gameObject)
        {
            player.TakeDamage(1);
        }
    }
}
