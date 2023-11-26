using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamageBOSS : MonoBehaviour
{
    private Rigidbody2D rb;
    public Finish finish;
    public int maxHealth = 100;
    int currentHealth;
    private Animator anim;

    private Transform transform;
    
    public float invunerableTime = 0.5f;
    float nextAttackTime = 0f;
    

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    public void Damage(int damage)
    {
        if (anim.GetBool("isDead") == false)
        {                
            if (Time.time >= nextAttackTime)
            {
                nextAttackTime = Time.time + invunerableTime;
                    
                currentHealth -= damage;

                anim.SetTrigger("damage");

            FMODUnity.RuntimeManager.PlayOneShot("event:/Foley/ToadBoss/ToadBoss_Hurt", GetComponent<Transform>().position);

                if (currentHealth <= 0)
                {
                    BossDie();
                }
            }
        }
    }

    private void BossDie()
    {
        finish.unlocked = true;
        anim.SetBool("isDead", true);
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        transform.position = new Vector2(transform.position.x, 6);   
        GetComponent<Collider2D>().enabled = false;
    }
}
