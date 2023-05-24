using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Enemy1 : Enemy,IShoot,Damage, iObserver
{
    public int maxLife;
    public int life;
    public float maxDistance = 5f;
    public float moveSpeed = 20f;
    NavMeshAgent agent;
    public Vector2 randomPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform pointShoot;
    [SerializeField] private float timertoShoot;
    Player player;
    float timer;
    float timeWait;
    Vector3 a;
    private int bulletCount;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
    }
    private void Start()
    {
        GameManager.GetInstance().Attach(this);
        Func<int, int> li = DeleteLife;
        li(maxLife);
    }

    private int DeleteLife(int j)
    {
        return life = j;
    }

    public void debug()
    {
        Debug.LogError(gameObject.name);
    }
    void Update()
    {
        Move();
        timer += Time.deltaTime;
        timeWait += Time.deltaTime;
        if (timer >= timertoShoot)
        {
            timer = 0;
            Action<GameObject> bulletPrefab = Shoot;
            bulletPrefab(bullet);
            bulletPrefab.Invoke(bullet);
        }
        if (life <= 0)
        {
            GameManager.GetInstance().Remove(this);
            GameManagerUI.GetInstance().UpdateScore();
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
       transform.LookAt(player.transform, transform.forward);
    }

    public override void Move()
    {
        if (timeWait < 2 && timeWait < 5)
        {
            Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            //transform.position = targetPosition;
            agent.SetDestination(targetPosition);
        }
        if (timeWait < 5 && timeWait > 2)
        {
            a = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            agent.SetDestination(a);
        }
        if (timeWait > 5)
        {
            timeWait = 0;
        }
    }

    public void Shoot(GameObject bullet)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Instantiate(bullet, pointShoot.position, pointShoot.rotation);
        }
    }
    public int GetDamage(int damage)
    {
        return life - damage;
    }

    public void Execute(ISubject subject)
    {
        life += (int)((GameManager)subject).Progession;
     bulletCount++;
    }
}
