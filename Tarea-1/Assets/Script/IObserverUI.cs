using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserverUI
{
    public void Execute(ISubjectUI subject);
}
