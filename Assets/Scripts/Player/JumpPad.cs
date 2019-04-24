using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {

    public string Tag;
    public float springForce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag(Tag))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, springForce));
        }

    }
}