using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private CircleCollider2D coll;
    private Transform transformer;

    private enum MovementPlayerState
    {
        idle,
        running,
        jumping,
        falling
    }

    private float dirX = 0f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpingAnimThreshold = .1f;
    [SerializeField] private LayerMask jumpableGround;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();
        transformer = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetAxis("Vertical") > 0 && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        MovementPlayerState state;
        //changing the direction of the sprite and whether its running
        if (dirX > .1f)
        {
            state = MovementPlayerState.running;
            flipCharacter();
        }
        else if (dirX < -.1f)
        {
            state = MovementPlayerState.running;
            flipCharacter();
        }
        else
        {
            state = MovementPlayerState.idle;
        }

        //changing the jumping animation
        if (rb.velocity.y > jumpingAnimThreshold)
        {
            state = MovementPlayerState.jumping;
        }
        else if (rb.velocity.y < (jumpingAnimThreshold*(-1)))
        {
            state = MovementPlayerState.falling;
        }

        anim.SetInteger("movementPlayerState", (int)state);
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void flipCharacter(){
        Vector3 scale = transformer.localScale;
        if (dirX > 0 && scale.x < 0 || dirX < 0 && scale.x > 0) {
            scale.x *= -1;
            transformer.localScale = scale;
        }
    }
}
