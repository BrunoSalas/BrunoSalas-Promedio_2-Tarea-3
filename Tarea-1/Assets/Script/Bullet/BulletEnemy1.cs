using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy1 : MonoBehaviour, iObserver
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

    protected virtual void Start()
    {
        GameManager.GetInstance().Attach(this);
    }
    protected virtual void Update()
    {
        //Destroy(gameObject, 4f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
    }
    public int GetDamage()
    {
        return damage;
    }
    private void OnDestroy()
    {
        GameManager.GetInstance().Remove(this);
    }
    public virtual void Execute(ISubject subject)
    {
        if (subject is GameManager)
        {
            scale += 0.01f;
            if (transform.localScale.magnitude < max.magnitude)
                transform.localScale = new Vector3(scale, scale, scale);
        }
    }
    public void debug()
    {
        Debug.LogError(gameObject.name);
    }
}
