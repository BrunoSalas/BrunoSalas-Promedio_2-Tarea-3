using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour,Damage
{
    [SerializeField] protected int damage;
    public int GetDamage()
    {
        return damage;
    }

    public abstract void Move();
}
