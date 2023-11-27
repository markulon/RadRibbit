using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealDamage : MonoBehaviour
{
    public int damage = 50;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<takeDamage>().Damage(damage);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            if (!collision.isTrigger) // Skip if the collider is a trigger collider
            {
                collision.gameObject.GetComponent<takeDamageBOSS>().Damage(damage);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
