using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Enemy2 : Enemy, IShoot, iObserver
{
    public GameObject player;
    public int life;
    [SerializeField] private float safeDistance = 5f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform pointShoot;
    [SerializeField] private float timertoShoot;
    public float moveSpeed = 1f;
    float timer;
    public float separationDistance = 2.0f;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameManager.GetInstance().Attach(this);
    }

    void Update()
    {
        agent.speed = moveSpeed;
        timer += Time.deltaTime;
        if (timer >= timertoShoot)
        {
            timer = 0;
            Action<GameObject> bulletPrefab = Shoot;
            bulletPrefab(bullet);
            bulletPrefab.Invoke(bullet);
        }
        Move();
        if (life <= 0)
        {
            GameManager.GetInstance().Remove(this);
            GameManagerUI.GetInstance().UpdateScore();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            transform.LookAt(player.transform, transform.forward);
        }
    }
    public override void Move()
    {
        if (player != null)
        {

            if (Vector3.Distance(transform.position, player.transform.position) < safeDistance)
            {
                Vector3 direction = transform.position - player.transform.position;
                direction = direction.normalized;
                agent.SetDestination(transform.position + direction * 10f);

            }
        }
    }

    public void Shoot(GameObject bullet)
    {
        Instantiate(bullet, pointShoot.position, pointShoot.rotation);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Damage>() != null)
        {
            life -= collision.gameObject.GetComponent<Damage>().GetDamage();
        }
    }

    public void debug()
    {
        Debug.LogError(gameObject.name);
    }
    public void Execute(ISubject subject)
    {
        if (subject is GameManager)
        {
            moveSpeed = ((GameManager)subject).Progession;

        }
    }
}
