using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : Bullet, iObserver
{
    protected virtual void Start()
    {
        GameManager.GetInstance().Attach(this);
    }

    private void OnDestroy()
    {
        GameManager.GetInstance().Remove(this);
    }

    public void Execute(ISubject subject)
    {
        speed = ((GameManager)subject).Progession;
    }


    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
    }
}
