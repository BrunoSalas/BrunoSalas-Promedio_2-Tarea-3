using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : Bullet
{
    
    public Transform jugador;
    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void Update()
    {
        Vector3 direccion = (jugador.position - transform.position).normalized;
        rb.velocity = direccion * speed;

    }
}
