using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public int life;
    private delegate int Execute(int i);
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Execute heal = new Execute(Heal);
            other.GetComponent<Player>().life += heal(life);
            Destroy(gameObject);
        }
    }

    private int Heal(int i)
    {
        return i;
    }
}
