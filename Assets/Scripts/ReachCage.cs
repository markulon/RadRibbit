using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; // Make sure to include the FMODUnity namespace

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
            //it will


        }
    }
}
