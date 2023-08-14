using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    
    public Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        Debug.Log("Interacting with"+ transform.name);
    }
    void Update()
    {
        if (hasInteracted == false)
        {
            if (Input.GetKeyDown(KeyCode.Q)) { 
                float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Interact();
                Debug.Log("Interact");
                hasInteracted = true;


            }
            }
        }

    }
    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null) 
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
