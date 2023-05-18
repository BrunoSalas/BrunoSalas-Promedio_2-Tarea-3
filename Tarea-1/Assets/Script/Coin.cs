using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public int amount;
    private delegate int Execute(int i);
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Execute score = new Execute(Score);
            GameManagerUI.GetInstance().Coin(score(amount));
            Destroy(gameObject);
        }
    }

    private int Score(int i)
    {
        return i;
    }
}
