using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IShoot,Damage
{
    [SerializeField] private int life;
    private Rigidbody rb;
    public int damage;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform pointShoot;
    [SerializeField] private float timertoShoot;
    float timer;
    [Range(1,100)]
    public float velocity = 5;

    void Start () 
    {
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer>= timertoShoot)
        {
            timer = 0;
            Shoot();
        }
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate () 
    {

        float movementH = Input.GetAxis("Horizontal");
        float movementV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movementH * velocity, 0.0f, movementV * velocity);

        rb.AddForce(movement);

    }
    public void Shoot()
    {
        Instantiate(bullet, pointShoot.position, Quaternion.identity);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Damage>() != null)
        {
           life -= collision.gameObject.GetComponent<Damage>().GetDamage();
        }
    }

    public int GetDamage()
    {
        return damage;
    }
    /*private void OnCollisionEnter( collision collesion)
{

}*/
}
