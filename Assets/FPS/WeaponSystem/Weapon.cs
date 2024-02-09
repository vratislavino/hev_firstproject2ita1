using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Func<string, bool> PlayerInputAction;

    public event Action<bool> IsPossibleToAttackChanged;

    protected void RaiseIsPossibleToAttackChanged(bool isPossibleToAttack) {
        IsPossibleToAttackChanged?.Invoke(isPossibleToAttack);
    }

    public abstract void Attack();

    protected virtual void Start()
    {
    }

    public virtual bool IsPossibleToAttack()
    {
        return true;
    }

    public virtual float GetReloadProgress()
    {
        return 1;
    }

    public virtual void ResetReloadProgess() { }
}
