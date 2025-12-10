using UnityEngine;
using UnityEngine.Events;

public class KeyInteractor : MonoBehaviour
{
    [Header("Event to run when key touches a door")]
    public UnityEvent OpenDoor;

    // Called when collider enters a trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            Debug.Log("Key touched a Door. Opening door...");
            OpenDoor.Invoke();
        }
    }

    // Called when collider collides (non-trigger)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            Debug.Log("Key touched a Door. Opening door...");
            OpenDoor.Invoke();
        }
    }
}