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
        if ((direction > 0 && !sprite.flipX) || (direction < 0 && sprite.flipX))
        {
            sprite.flipX = !sprite.flipX;
        }
    }

    private void CheckWaypointDistance()
    {
        // Check if the enemy has reached the current waypoint
        if (Vector2.Distance(transformer.position, waypoints[currentWaypointIndex].transform.position) < 0.1f)
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
