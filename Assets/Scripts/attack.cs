using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public Animator animator;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");
    }
}
