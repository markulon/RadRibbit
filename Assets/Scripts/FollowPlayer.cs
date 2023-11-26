using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWithAcceleration : MonoBehaviour
{
    private Transform player; // Player's transform
    public float stopDistance = 1f; // Minimum distance to maintain from the player
    public float maxSpeed = 5f; // Maximum speed
    public float acceleration = 1f; // Rate of acceleration
    public float startSpeed = 1f; // Starting speed
    public float breakSpeed = 3f; // Rate of deceleration

    private float currentSpeed; // Current speed of the object
    private ReachCage cageScript; // Reference to the Cage script on the parent

    public bool isFacingRight = true;
    private Transform transformer;
    private Animator anim;

    void Start()
    {
        // Get the Cage component from the parent object
        cageScript = GetComponentInParent<ReachCage>();
        currentSpeed = startSpeed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transformer = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the Cage is unlocked
        if (cageScript != null && cageScript.unlockedCage)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Check if the object is farther than the stop distance
            if (distanceToPlayer > stopDistance)
            {
                // Accelerate
                currentSpeed += acceleration * Time.deltaTime;
                currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
                anim.SetBool("running", true);

            }
            else
            {
                // Decelerate
                currentSpeed -= breakSpeed * Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0);
                currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
                anim.SetBool("running", false);
            }
            
            // Move towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * currentSpeed * Time.deltaTime;

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
        } else
        {
            anim.SetBool("running", false);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transformer.localScale;
        scale.x *= -1;
        transformer.localScale = scale;
    }
}
