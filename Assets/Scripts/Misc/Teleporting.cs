using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{

    public Transform teleportTarget;
    public GameObject thePlayer;


    void OnTriggerEnter2D(Collider2D other)  
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }
}