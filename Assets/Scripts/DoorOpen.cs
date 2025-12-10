using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject doorObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void open()
    {
        this.doorObj.transform.position += new Vector3(1.5f, 0, 0);
    }
}
