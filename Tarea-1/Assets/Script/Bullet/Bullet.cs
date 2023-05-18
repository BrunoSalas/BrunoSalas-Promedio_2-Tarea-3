using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class Bullet : MonoBehaviour, Damage
{

    protected Rigidbody rb;
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    [SerializeField] protected float scale;
    [SerializeField] protected Vector3 max;
    private void Awake()
    {
        scale = 1;
        rb = GetComponent<Rigidbody>();
        max = new Vector3(4, 4, 4);
        transform.localScale = new Vector3(scale, scale, scale);
    }

   
    protected virtual void  Update()
    {
        Destroy(gameObject, 4f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    public int GetDamage()
    {
        return damage;
    }
}
