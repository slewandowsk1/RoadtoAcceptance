using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerBoss : MonoBehaviour
{

    public int health;
    public int maxHealth;
    public int damage = 2;
    public float speed = 300.0f;
    [SerializeField] private float timeToDamage;
    private float timeBtwDamage = 1.5f;
    [SerializeField] private float invincibilityTime;
    [SerializeField] private float timeSinceHit;
    [SerializeField] private GameObject target;
    Rigidbody2D rb;
    private float timeInsideCollider;

    public float magicNumber;


    //public Animator camAnim;
    public Slider healthBar;
    private Animator animator;
    public bool isDead;
    public float chaseDistance = 120;

    private bool facingLeft = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
      
        timeSinceHit = Mathf.Clamp(timeSinceHit + Time.deltaTime, 0, invincibilityTime);

        var scale = health / magicNumber;
        transform.localScale = Vector3.one * scale;

        // give the player some time to recover before taking more damage !
        if (timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }

        healthBar.value = health;
        Vector2 targetDistance = transform.position - target.transform.position;

        if (Vector2.SqrMagnitude(targetDistance) < chaseDistance)
        {
            rb.AddForce(-targetDistance.normalized * speed * Time.deltaTime);
            animator.SetTrigger("Chase");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        // deal the player damage ! 
        if (other.CompareTag("Player") && isDead == false)
        {
            timeInsideCollider = Mathf.Clamp(timeInsideCollider + Time.deltaTime, 0, timeToDamage);
            var healthScript = other.GetComponent<Health>();
            if (timeBtwDamage <= 0 && healthScript.currentHealth > 0)
            {
                animator.SetTrigger("Attack");
                if (timeInsideCollider >= timeToDamage)
                {
                    healthScript.hit(damage);
                }
            }
            if(healthScript.currentHealth == 0)
            {
                chaseDistance = 0;
                animator.SetTrigger("Idle");
            }
 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timeInsideCollider = 0;
        }
    }

    public void GainHealth(int gainHealth)
    {
        if (timeSinceHit >= invincibilityTime)
        {
            health += gainHealth;
            timeSinceHit = 0;

        }
        health = Mathf.Clamp(health, 0, maxHealth);
    }
}