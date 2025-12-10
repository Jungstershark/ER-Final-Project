using UnityEngine;

public class Breakable : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Prefab to spawn when this object breaks. Optional.")]
    public GameObject brokenVersion;

    [Tooltip("If true, the object will be destroyed instead of replaced by a broken prefab.")]
    public bool destroyInstead = false;

    [Header("Optional Effects")]
    [Tooltip("Optional particle effect to spawn when broken.")]
    public GameObject breakEffect;

    [Tooltip("Optional sound to play when broken.")]
    public AudioClip breakSound;

    [Range(0f, 1f)]
    public float soundVolume = 1f;

    public void Break()
    {
        // Spawn broken model
        if (brokenVersion != null)
        {
            GameObject broken = Instantiate(brokenVersion, transform.position, transform.rotation);

            // Optional: match original scale so it looks consistent
            broken.transform.localScale = transform.localScale;
        }

        // Optional particle effect
        if (breakEffect != null)
            Instantiate(breakEffect, transform.position, Quaternion.identity);

        // Optional sound
        if (breakSound != null)
            AudioSource.PlayClipAtPoint(breakSound, transform.position, soundVolume);

        // Destroy original object if required OR if no broken model is provided
        if (destroyInstead || brokenVersion == null)
            Destroy(gameObject);

        Debug.LogFormat("{0} was broken!", gameObject.name);
    }
}
