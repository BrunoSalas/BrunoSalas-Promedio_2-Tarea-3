using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : Enemy,IShoot,Damage, iObserver
{
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

    void Awake()
    {
        player = FindObjectOfType<Player>();
        agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
    }
    private void Start()
    {
        GameManager.GetInstance().Attach(this);
    }

    public void debug()
    {
        Debug.LogError(gameObject.name);
    }
    void Update()
    {
        Move();
        timer += Time.deltaTime;
        if (timer >= timertoShoot)
        {
            timer = 0;
            Shoot();
        }
        if (life <= 0)
        {
            GameManager.GetInstance().Remove(this);
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
       transform.LookAt(player.transform, transform.forward);
    }

    public override void Move()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z +Time.deltaTime * moveSpeed);
        transform.position = targetPosition;
    }

    public void Shoot()
    {
        Instantiate(bullet, pointShoot.position, pointShoot.rotation);
    }
    public int GetDamage(int damage)
    {
        return life - damage;
    }

    public void Execute(ISubject subject)
    {
        if(subject is GameManager)
        {
            moveSpeed = ((GameManager)subject).Progession;
        }
    }
}
