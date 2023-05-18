using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubjectUI
{
    public void Attach(IObserverUI observerUI);

    public void Remove(IObserverUI observerUI);
}
