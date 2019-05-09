using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnablePlatforms : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            gameObject.SetActive(false);
        }

        
    }
    private void Update()
    {
        if (gameObject == false)
        {
            Invoke("ChangeColor", 1);
        }
    }

    void ChangeColor()
    {
        gameObject.SetActive(true);
    }
    
} //FAKUBOTCH
    