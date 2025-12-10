using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class SpellTableOrbs : MonoBehaviour
{
    public GameObject orbObject;
    public int row;
    public int col;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OrbSelected()
    {
        Debug.Log(orbObject.name+" selected.");
        orbObject.GetComponent<Renderer>().material.color = Color.red;
        GridSystem.Instance.RegisterOrbClick(this.row, this.col);
    }

    public void OrbDeselected()
    {
        Debug.Log(orbObject.name+" deselected.");
        orbObject.GetComponent<Renderer>().material.color = Color.white;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
