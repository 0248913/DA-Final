using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
   
    public virtual void Interact()
    {
     
        Debug.Log("Interacting with " + gameObject.name);
    }
void OnMouseDown()
{
    Interact();
}
}
