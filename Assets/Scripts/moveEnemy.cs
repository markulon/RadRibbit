using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Transform transformer;

    public GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    public float speed = 1f;

    public bool facingRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        transformer = GetComponent<Transform>();
    }

    void Update()
    {
        if (waypoints.Length == 0) return; // Check if waypoints are assigned

        MoveTowardsWaypoint();
        CheckWaypointDistance();
    }

    private void MoveTowardsWaypoint()
    {
        // Determine the direction to the current waypoint
        float direction = (waypoints[currentWaypointIndex].transform.position.x > transformer.position.x) ? 1 : -1;

        // Move the enemy
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        // Flip the sprite if needed
        if ((direction > 0 && facingRight) || (direction < 0 && !facingRight))
        {
            facingRight = !facingRight;
            Vector3 scale = transformer.localScale;
            scale.x *= -1;
            transformer.localScale = scale;
        }
    }

    private void CheckWaypointDistance()
    {
        // Check if the enemy has reached the x-coordinate of the current waypoint
        if (Mathf.Abs(transformer.position.x - waypoints[currentWaypointIndex].transform.position.x) < 0.1f)
        {
            // Switch to the next waypoint
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // Reset to the first waypoint
            }
        }
    }
}