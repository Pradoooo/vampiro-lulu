using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoPickup : Interactable
{
    public override void Interact()
    {
        base.Interact();
        Pickup();
    }
    void Pickup()
    {
        Debug.Log("Picking up item.");
        Destroy(gameObject);
    }
}
