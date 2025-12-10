using UnityEngine;

public class OrbConnector : MonoBehaviour
{
    LineRenderer lineRenderer;
    public void Init(GameObject orbStart)
    {
        this.lineRenderer = orbStart.AddComponent<LineRenderer>();
        // Set the material
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        // Set the color
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;

        // Set the width
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;

        // Set the number of vertices
        lineRenderer.positionCount = 1;

        // Set the positions of the vertices
        lineRenderer.SetPosition(0, orbStart.transform.position);
    }

    public void NewNode(GameObject orbObject)
    {
        lineRenderer.positionCount += 1;
        lineRenderer.SetPosition(lineRenderer.positionCount-1, orbObject.transform.position);
    }
    
}
