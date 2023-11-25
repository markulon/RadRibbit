using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackBoss : MonoBehaviour
{
    public int damage = 0;
    public float jumpWait = 1f;
    public float jumpForce = 3f;
    public float jumpHeight = 3f;
    private Rigidbody2D enemyRigidbody;
    private bool isFacingRight = false;
    private Transform transformer;
    private GameObject player;
    private Animator anim;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    private bool isPlayerInSight = false;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        transformer = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInSight = true;
            StartCoroutine(JumpTowardsPlayer(jumpWait)); // Start jumping towards player
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInSight = false;
            StopAllCoroutines(); // Stop all coroutines when the player leaves
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerLife>().Damage(damage);
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Check if the player is on the left side and the boss is facing right or vice versa
            if ((player.transform.position.x < transform.position.x && isFacingRight) ||
                (player.transform.position.x > transform.position.x && !isFacingRight))
            {
                // Flip the boss
                Flip();
            }
        }

        if (IsGrounded())
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transformer.localScale;
        scale.x *= -1;
        transformer.localScale = scale;
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private IEnumerator JumpTowardsPlayer(float delay)
    {
        while(isPlayerInSight)
        {
            yield return new WaitForSeconds(delay);
            if (IsGrounded() && player != null)
            {
                Vector2 jumpDirection = isFacingRight ? new Vector2(jumpForce, jumpHeight) : new Vector2(-jumpForce, jumpHeight);
                enemyRigidbody.AddForce(jumpDirection, ForceMode2D.Impulse);
            }
        }
    }
}
