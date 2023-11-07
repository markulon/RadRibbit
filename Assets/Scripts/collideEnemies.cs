using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideEnemies : MonoBehaviour
{
    public int damage = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<takeDamage>().damage(damage);
        }
    }

    void Start(){
    }
}
