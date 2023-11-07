using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D coll;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask collidableObjects;

    public float speed = 1f;
    private int dirX = -1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (dirX < 0f)
        {
            sprite.flipX = false;
        }
        else if (dirX > 0f)
        {
            sprite.flipX = true;
        }
        onCollisionChangeDirection();
    }

    private void onCollisionChangeDirection()
    {
        if(Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.left, .1f, collidableObjects))
        {
            dirX = 1;
        }
        else if (Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.right, .1f, collidableObjects))
        {
            dirX = -1;
        }
    }
}