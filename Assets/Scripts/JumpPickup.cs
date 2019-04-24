using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPickup : MonoBehaviour {



    PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Jump(1);
            Destroy(gameObject);

        }

    }
}