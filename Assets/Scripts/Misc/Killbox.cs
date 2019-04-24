using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Health>().currentHealth -=10;
            other.GetComponent<PlayerController>().enabled = false;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
        }

    }
}