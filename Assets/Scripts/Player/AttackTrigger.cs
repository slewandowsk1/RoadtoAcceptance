using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 10;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.isTrigger == false && collision.CompareTag("enemy"))
        {
            collision.GetComponent<Boss>().Damage(dmg);
            //collision.SendMessageUpwards("Damage", dmg);
        } 

    }
}
