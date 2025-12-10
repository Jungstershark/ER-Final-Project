using UnityEngine;
using UnityEngine.Events;

// If attached to an object that might be disabled, callback will not work.
// Attach it on a parent object that won't be disabled.
public class GameEventListener<T> : MonoBehaviour
{
    [Tooltip("Event asset this listener responds to.")]
    public GameEvent<T> Event;

    [Tooltip("Response invoked when the event is raised.")]
    public UnityEvent<T> Response;

    // Track whether we actually registered, so we don't try to unregister twice
    private bool isRegistered = false;

    private void OnEnable()
    {
        if (Event == null)
        {
            Debug.LogWarning($"[GameEventListener<{typeof(T).Name}>] No Event assigned on {name}.", this);
            return;
        }

        Event.RegisterListener(this);
        isRegistered = true;
    }

    // This is also called when the object is destroyed and can be used for any cleanup code.
    // When scripts are reloaded after compilation has finished, OnDisable will be called,
    // followed by an OnEnable after the script has been loaded.
    private void OnDisable()
    {
        if (!isRegistered || Event == null)
            return;

        Event.UnregisterListener(this);
        isRegistered = false;
    }

    public void OnEventRaised(T data)
    {
        // Safe even if Response is null
        Response?.Invoke(data);
    }
}
