using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackTrigger : MonoBehaviour
{

    public int dmg = 10;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false && collision.CompareTag("enemy"))
        {
            collision.GetComponent<StageBoss>().Damage(dmg);
            //collision.SendMessageUpwards("Damage", dmg);
        }

    }
}
