﻿using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    Transform player;

    bool hasInteracted = false;

    public Transform interactionTransform;

    public virtual void Interact()
    {
        //this method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        if(Vector3.Distance(player.position, interactionTransform.position) <= radius && !hasInteracted)
        {
          Interact();
          hasInteracted = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
