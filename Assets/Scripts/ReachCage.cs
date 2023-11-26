using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; // Make sure to include the FMODUnity namespace

public class ReachCage : MonoBehaviour
{

    public bool unlockedCage = false;
    private Animator anim;

    public Finish finish;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tounge"))
        {
            unlockedCage = true;
            anim.SetTrigger("openCage");
            finish.unlocked = true;
            //maybe play a sound here
            //it will

        }
    }
}
