using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour, IObserverUI
{
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text killsText;

    public void Execute(ISubjectUI subject)
    {
        if (subject is GameManagerUI)
        {
            lifeText.text = "Life: " + ((GameManagerUI)subject).PlayerLife;
            scoreText.text = "Score: " + ((GameManagerUI)subject).Score;
            killsText.text = "Kills: " + ((GameManagerUI)subject).Kills;
        }
    }

    void Start()
    {
        GameManagerUI.GetInstance().uiController = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
