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
    

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    public void Damage(int damage)
    {
        if (anim.GetBool("isDead") == false)
        {                
            currentHealth -= damage;

            anim.SetTrigger("damage");

            FMODUnity.RuntimeManager.PlayOneShot("event:/Foley/RadMan/RadMan_Hurt", GetComponent<Transform>().position);

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
        GetComponent<Collider2D>().enabled = false;
    }
}
