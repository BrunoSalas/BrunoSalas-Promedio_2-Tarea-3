using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Bullet
{

    protected override void Update()
    {
        rb.velocity = transform.forward * speed;
    }
}
