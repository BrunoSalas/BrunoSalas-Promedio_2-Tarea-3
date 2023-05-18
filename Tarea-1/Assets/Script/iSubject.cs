using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    public void Attach(iObserver observer);
    public void Remove(iObserver observer);



}
