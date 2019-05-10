using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCd = 0.5f;

    public Collider2D attackCollider;

    private Animator animator;

    

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            attackCollider.enabled = true;

            FindObjectOfType<AudioManager>().Play("attack");
        }

        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackCollider.enabled = false;
            }

        }
        animator.SetBool("Attacking", attacking);
    }
}

