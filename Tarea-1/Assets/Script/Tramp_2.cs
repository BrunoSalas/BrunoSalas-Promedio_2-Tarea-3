using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tramp_2 : MonoBehaviour
{ public LayerMask player;
public float timeShoot;
public float maxTime;
 
[SerializeField] private GameObject bullet;
[SerializeField] private Transform pointShoot;

void Start()
{
}

// Update is called once per frame
void Update()
{
    RaycastHit hit;
    timeShoot += Time.deltaTime;
    if (Physics.Raycast(transform.position, transform.up, out hit, 10f, player))
    {
        float a = timeShoot;
        if (a > maxTime)
        {
            Action<GameObject> bulletPrefab = Shoot;
            bulletPrefab(bullet);
            bulletPrefab.Invoke(bullet);
            a = 0;
        }
    }
}
private void Shoot(GameObject prefab)
{
    Instantiate(prefab, pointShoot.position, pointShoot.rotation);
        maxTime--;
}
}
