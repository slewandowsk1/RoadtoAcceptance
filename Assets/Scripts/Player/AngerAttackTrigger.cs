using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerAttackTrigger : MonoBehaviour
{

    public int gainHealth = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false && collision.CompareTag("enemy"))
        {
            collision.GetComponent<AngerBoss>().GainHealth(gainHealth);
            //collision.SendMessageUpwards("Damage", dmg);
        }

    }
}
