using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float invincibilityTime;
    public int maxHealth;                            // The amount of health the player starts the game with.
    public int currentHealth;
    public Animator animator;

    public List<Image> hearts;
    public Transform HeartPanel;
    public GameObject heartPrefab;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public PlayerController controller;

    public bool isDead = false;

    private float _currentInvincibility;

    private void Start()
    {
        SetupHearts();
    }

    private void SetupHearts()
    {
        // Destroy any existing hearts.
        hearts.Clear();
        foreach (Transform child in HeartPanel.transform)
        {
            Destroy(child.gameObject);
        }
        // Spawn the hearts.
        for (var i = 0; i < maxHealth; i++)
        {
            var heart = Instantiate(heartPrefab, HeartPanel);
            hearts.Add(heart.GetComponent<Image>());
        }
    }

    private void Update()
    {
        _currentInvincibility = Mathf.Clamp(_currentInvincibility - Time.deltaTime, 0, invincibilityTime);

        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
        if (currentHealth <= 0 && isDead == false)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth += amount, 0, maxHealth);
    }

    void Die()
    {
        controller.enabled = false;
        animator.SetTrigger("Die");
        isDead = true;
    }  
    public void hit(int damage)
    {
        if (_currentInvincibility > 0) return;
        currentHealth -= damage;
        _currentInvincibility = invincibilityTime;
    }

}
    


