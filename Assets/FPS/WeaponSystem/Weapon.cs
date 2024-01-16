using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Func<string, bool> PlayerInputAction;

    public abstract void Attack();

    protected virtual void Start()
    {
    }
}
