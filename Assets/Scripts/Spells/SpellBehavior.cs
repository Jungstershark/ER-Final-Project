using Meta.XR.Simulator.Editor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SpellBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject SpellSource;
    public float rayLength = 10f;

    public void ShatterSpell()
    {
        Debug.Log("Shatter Spell Cast!");
        // Implement the shatter spell logic here
        Ray spellDirection = new Ray(SpellSource.transform.position, SpellSource.transform.up);



        RaycastHit hit;
        if (Physics.Raycast(spellDirection, out hit, rayLength))
        {
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            // Add shatter effect to the hit object
            if (hit.collider.gameObject.tag == "Shatterable")
            {
                hit.collider.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("The hit object is not shatterable.");
            }
            // For example, you could add a particle effect or break the object into pieces
        }
        else
        {
            Debug.Log("No object hit by the shatter spell.");
        }

    }

    public void MagnetSpell()
    {
        Debug.Log("Magnet Spell Cast!");
        Ray spellDirection = new Ray(SpellSource.transform.position, SpellSource.transform.up);



        RaycastHit[] hits = Physics.RaycastAll(spellDirection, rayLength);
        foreach (var h in hits)
        {
            GameObject go = h.collider.gameObject;
            if (go.CompareTag("Magnetic"))
            {
                Vector3 finalDestination = SpellSource.transform.position;
                StartCoroutine(AttractObject(go, finalDestination));
            }

        }
    }

    public IEnumerator AttractObject(GameObject target, Vector3 to)
    {
        while (Vector3.Distance(to, target.transform.position) > 0.5f)
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, to, Time.deltaTime * 5f);
            yield return null;
        }
    }

    public void ResetSpell() { 
        Debug.Log("Reset Spell Cast!");
        // Implement reset logic here
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
