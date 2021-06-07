using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class Interactible : MonoBehaviour
{
    public float radius = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Interact() //This method is meant to be overritten in derrived classes
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact();
    }
}
