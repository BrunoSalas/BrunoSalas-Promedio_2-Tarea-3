using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3 : Enemy, IShoot, iObserver
{
    public GameObject player;
    public int life;
    public float moveSpeed;
    NavMeshAgent agent;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform pointShoot;
    [SerializeField] private float timertoShoot;
    float timer;
    bool back = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameManager.GetInstance().Attach(this);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timertoShoot)
        {
            timer = 0;
            Shoot();
        }
        Move();

        if (life <= 0)
        {
            GameManager.GetInstance().Remove(this);
            GameManagerUI.GetInstance().UpdateScore();
            Destroy(gameObject);
        }
    }

    public void debug()
    {
        Debug.LogError(gameObject.name);
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
        if (!back)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * moveSpeed);
            if (transform.position.z > 27)
            {
                back = true;
            }

        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * moveSpeed);
            if (transform.position.z < -9)
            {
                back = false;
            }
                
        }
    }

    public void Shoot()
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

    public void Execute(ISubject subject)
    {
        moveSpeed = ((GameManager)subject).Progession;
        life += (int)((GameManager)subject).Progession;
    }
}
