using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    private bool interacted;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Maak interaction
    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        if (!interacted)
        {
            transform.position += new Vector3(1, 0, 0);
            interacted = true;
        }
        else if (interacted) 
        {
            transform.position += new Vector3(-1, 0, 0);
            interacted = false;
        }

        
    }
}
