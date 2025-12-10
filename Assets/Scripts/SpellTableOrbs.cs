using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class SpellTableOrbs : MonoBehaviour
{
    public GameObject orbObject;
    public int row;
    public int col;


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
        Debug.Log(orbObject.name+" selected.");
        //orbObject.GetComponent<Renderer>().material.color = Color.red;
        GridSystem.Instance.RegisterOrbClick(this.row, this.col);
        SetColor(Color.red, orbObject);


    }

    public void OrbDeselected()
    {
        Debug.Log(orbObject.name+" deselected.");
        //orbObject.GetComponent<Renderer>().material.color = Color.white;
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
