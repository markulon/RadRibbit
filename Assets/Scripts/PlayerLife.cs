using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Animator anim;
    
    public float invunerableTime = 1f;
    float nextAttackTime = 0f;

    public Health health;

    private Vector3 initialPosition;
    private float triggerCooldownTime = 0f;
    private float triggerCooldownDuration = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        initialPosition = transform.position;
    }
    
    public void Damage(int damage)
    {
        if (Time.time >= nextAttackTime)
        {
            health.ChangeHearts(-damage);

            nextAttackTime = Time.time + invunerableTime;

            anim.SetTrigger("damage");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time > triggerCooldownTime && collision.gameObject.CompareTag("OutOfBounds"))
        {
            RestartLevel();
             //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/TMP_Death", GetComponent<Transform>().position);
             
            triggerCooldownTime = Time.time + triggerCooldownDuration;
        }
    }

    public void PlayerDie()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        transform.position = initialPosition;
        health.ChangeHearts(-1);
    }

}
