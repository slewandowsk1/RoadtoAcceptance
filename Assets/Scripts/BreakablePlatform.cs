using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{


    public int TimeToDestroy;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject, TimeToDestroy);
        }
    }
}

