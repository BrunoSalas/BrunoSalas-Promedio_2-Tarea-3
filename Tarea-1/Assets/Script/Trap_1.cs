using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_1 : MonoBehaviour, Damage
{
    public float speed;
    Vector3 a;
    bool up;

    public int GetDamage()
    {
        return 19;
    }

    // Start is called before the first frame update
    void Start()
    {
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime;

        if (transform.position.y < 14 && up)
        {
            a = new Vector3(transform.position.x, transform.position.y + Time.deltaTime*speed, transform.position.z);
        }
        else
        {
            up = false;
            a = new Vector3(transform.position.x, transform.position.y - Time.deltaTime*speed, transform.position.z);
        }
        if (transform.position.y <= 0)
        {
            up = true;
        }
        transform.position = a;
    }
}
