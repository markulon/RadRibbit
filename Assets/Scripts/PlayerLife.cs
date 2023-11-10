using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Animator anim;
    
    public float invunerableTime = 1f;
    public int maxHealth = 100;
    int currentHealth;
    float nextAttackTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    
    public void Damage(int damage)
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + invunerableTime;
                
            currentHealth -= damage;

            anim.SetTrigger("damage");

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OutOfBounds"))
        {
            RestartLevel();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
