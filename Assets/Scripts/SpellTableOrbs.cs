using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class SpellTableOrbs : MonoBehaviour
{
    public GameObject orbObject;
    // public RightHandInteractor rightHandInteractor;
    public int row;
    public int col;
    public GridSystem gridSystem;

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
        
        gridSystem.RegisterOrbClick(this.row, this.col);
        SetColor(Color.red, orbObject);


    }

    public void OrbDeselected()
    {
        Debug.Log(orbObject.name+" deselected.");
        SetColor(Color.white, orbObject);
    }

    void Start()
    {
        // gridSystem = rightHandInteractor.gridSystem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
