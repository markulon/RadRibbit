using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;
    private Transform transformer;
    private bool climbable = false;

    private enum MovementPlayerState
    {
        idle,
        running,
        jumping,
        falling,
        climbing
    }

    private float dirX = 0f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private LayerMask jumpableGround;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        transformer = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetAxis("Vertical") > 0 && climbable)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
        }


        if (Input.GetButtonDown("Vertical") && IsGrounded() && Input.GetAxis("Vertical") > 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Foley/Froggy/Froggy_Jump", GetComponent<Transform>().position);

        }

        if (Input.GetAxis("Vertical") > 0 && IsGrounded() && !climbable)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //hopper her
        }

        UpdateAnimationState();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            climbable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            climbable = false;
        }
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
        if (rb.velocity.y > 0.1 && !IsGrounded())
        {
            state = MovementPlayerState.jumping;
        }
        else if (rb.velocity.y < -0.1 && !IsGrounded())
        {
            state = MovementPlayerState.falling;
        }

        if (climbable && Input.GetAxis("Vertical") > 0)
        {
            state = MovementPlayerState.climbing;
        }

        anim.SetInteger("movementPlayerState", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .4f, jumpableGround);
    }

    private void flipCharacter()
    {
        Vector3 scale = transformer.localScale;
        if (dirX > 0 && scale.x < 0 || dirX < 0 && scale.x > 0)
        {
            scale.x *= -1;
            transformer.localScale = scale;
        }
    }
}
