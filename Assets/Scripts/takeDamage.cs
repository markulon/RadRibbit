using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    private Rigidbody2D rb;
    public int maxHealth = 100;
    int currentHealth;
    private Animator anim;
    // Start is called before the first frame update
    
    public float invunerableTime = 1f;
    float nextAttackTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

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

    void Die()
    {
        anim.SetBool("isDead", true);
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        GetComponent<moveEnemy>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
