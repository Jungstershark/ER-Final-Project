using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    [Tooltip("Optional: Should the fireball destroy itself after hitting something?")]
    public bool destroyOnImpact = true;

    [Tooltip("Optional: Tag to ignore (e.g., Player, other fireballs). Leave empty if unused.")]
    public string ignoreTag = "";

    private void OnCollisionEnter(Collision collision)
    {
        // Optional ignore logic
        if (!string.IsNullOrEmpty(ignoreTag) && collision.collider.CompareTag(ignoreTag))
            return;

        // Try to find Breakable on collider or its parents
        if (collision.collider.TryGetComponent(out Breakable breakable) ||
            collision.collider.GetComponentInParent<Breakable>() is Breakable parentBreakable)
        {
            // Prefer direct hit, fallback to parent
            // (breakable != null ? breakable : parentBreakable).Break();
        }

        // Optional: destroy the fireball
        if (destroyOnImpact)
            Destroy(gameObject);
    }
}
