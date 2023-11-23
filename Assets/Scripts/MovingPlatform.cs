using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour
{
    public GameObject[] waypoints;
    [SerializeField] private float moveSpeed = 2f;
    private int currentWaypoint = 0;

    void Update()
    {
      if (Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < .1f)
      {
        currentWaypoint++;
        if (currentWaypoint >= waypoints.Length)
        {
          currentWaypoint = 0;
        }
      }
      transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, moveSpeed * Time.deltaTime);
    }
}

