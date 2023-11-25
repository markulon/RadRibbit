using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask collidableObjects;
    private Transform transformer;

    public float speed = 1f;
    private int dirX = -1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        transformer = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        checkCollision();
    }

    private void checkCollision()
    {
        if(Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.left, .1f, collidableObjects) || Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.right, .1f, collidableObjects))
        {
            flipCharacter();
        }
    }

    
    private void flipCharacter(){
        speed = -speed;
        Vector3 scale = transformer.localScale;
        scale.x *= -1;
        transformer.localScale = scale;
    }
}