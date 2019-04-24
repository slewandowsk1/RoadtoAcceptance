using UnityEngine;

public class LiftPlayer : MonoBehaviour
{

    public string Tag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
           GetComponent<Rigidbody2D>().gravityScale = -1;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
           GetComponent<Rigidbody2D>().gravityScale = 1;
        }

    }
}

