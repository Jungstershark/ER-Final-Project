using UnityEngine;

public class OrbConnector : MonoBehaviour
{
    public static OrbConnector Instance;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        lineRenderer = gameObject.AddComponent<LineRenderer>();

        // Setup appearance
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;

        lineRenderer.positionCount = 0;
    }

    public void NewNode(GameObject orb)
    {
        int index = lineRenderer.positionCount;
        lineRenderer.positionCount++;

        lineRenderer.SetPosition(index, orb.transform.position);
    }

    public void ResetLine()
    {
        lineRenderer.positionCount = 0;
    }
}
