using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : Bullet,iObserver
{


    protected virtual void Start()
    {
        GameManager.GetInstance().Attach(this);
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
    protected override void Update()
    {
        rb.velocity = transform.forward * speed;
    }
   
}
