using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerUI : MonoBehaviour, ISubjectUI
{
    private static GameManagerUI instance;
    private Player player;

    public static GameManagerUI GetInstance()
    {
        return instance;
    }

    public void Attach(IObserverUI observerUI)
    {
        throw new System.NotImplementedException();
    }
    public void Remove(IObserverUI observerUI)
    {
        throw new System.NotImplementedException();
    }
}
