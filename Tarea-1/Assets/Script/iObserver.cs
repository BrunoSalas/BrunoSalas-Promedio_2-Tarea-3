using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iObserver
{
    public abstract void Execute(ISubject subject);

}
