using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamagable
{
    protected PlayerController player;
    [SerializeField]
    protected int MaxHp;
    public int Hp { get; set; }

    private bool isDying = false;

    public void Die()
    {
        if (isDying) return;
        isDying = true;

        FindObjectOfType<ScoreChanger>().AddScore();
        Destroy(gameObject);
    }

    public void TakeDamage(int dmg)
    {
        Hp -= dmg;
        if (Hp <= 0) Die();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Hp = MaxHp;
        player = FindObjectOfType<PlayerController>();
    }

}
