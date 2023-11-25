using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Animator anim;
    
    public float invunerableTime = 1f;
    public int maxHealth = 3;
    int currentHealth;
    float nextAttackTime = 0f;

    public Health health;

    private Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        initialPosition = transform.position;
    }
    
    public void Damage(int damage)
    {
        if (Time.time >= nextAttackTime)
        {
            health.ChangeHearts(-damage);

            nextAttackTime = Time.time + invunerableTime;
                
            //currentHealth -= damage;

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
             //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/TMP_Death", GetComponent<Transform>().position);

        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        health.ChangeHearts(-1);
        transform.position = initialPosition;
    }

}
