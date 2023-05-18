using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet4 : Bullet
{
    public float distanceMax = 10f;
    private Vector3 direction;
    private float distanceTraveled;
    private bool back;



    private void Start()
    {
        direction = transform.forward;
    }
    private void FixedUpdate()
    {
        if (!back)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, distanceMax))
            {
                direction = Vector3.Reflect(direction, hit.normal);
            }
            else
            {
                rb.velocity = direction * speed;
                distanceTraveled += speed * Time.deltaTime;

                if (distanceTraveled >= distanceMax)
                {
                    back = true;
                }
            }
        }
        else
        {
            rb.velocity = -direction * speed;
        }
    }
}
