using System.Collections.Generic;
using UnityEngine;

public class GameEvent<T> : ScriptableObject
{
    private readonly List<GameEventListener<T>> eventListeners =
        new List<GameEventListener<T>>();

    /// <summary>
    /// Raises this event and notifies all listeners.
    /// </summary>
    public void Raise(T data)
    {
        var listenersSnapshot = eventListeners.ToArray();

        for (int i = listenersSnapshot.Length - 1; i >= 0; i--)
        {
            listenersSnapshot[i].OnEventRaised(data);
        }
    }

    /// <summary>
    /// Registers a listener to be notified when this event is raised.
    /// </summary>
    public void RegisterListener(GameEventListener<T> listener)
    {
        if (listener == null) return;
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    /// <summary>
    /// Unregisters a listener.
    /// </summary>
    public void UnregisterListener(GameEventListener<T> listener)
    {
        if (listener == null) return;
        eventListeners.Remove(listener);
    }
}
