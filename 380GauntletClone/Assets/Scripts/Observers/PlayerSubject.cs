using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSubject : MonoBehaviour
{
    private List<IObserver> _observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObserver(PlayerActions action)
    {
        _observers.ForEach((_observer) =>
        {
            _observer.OnNotify(action);
        });
    }
}
