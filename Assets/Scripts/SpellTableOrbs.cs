using Unity.VisualScripting;
using UnityEngine;

public class SpellTableOrbs : MonoBehaviour
{
    public GameObject orbObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void SetColor(Color color, GameObject target)
    {
        Renderer renderer = target.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }
    public void OrbSelected()
    {
        SetColor(Color.red, orbObject);


    }

    public void OrbDeselected()
    {
        SetColor(Color.white, orbObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
