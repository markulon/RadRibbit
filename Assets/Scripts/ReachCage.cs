using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachCage : MonoBehaviour
{

    public bool unlockedCage = false;

    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            unlockedCage = true;
            //maybe play a sound here
        }
    }
}
