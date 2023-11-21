using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    //private AudioSource finishSound;

    public Animator targetAnimator; // Assign in the inspector
    public ReachCage reachCage; // Assign in the inspector

    void Start()
    {
        targetAnimator = GetComponent<Animator>();
        //finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && reachCage.unlockedCage == true)
        {
            //finishSound.Play();
            Invoke("CompleteLevel", 1f);
        }
        
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        if (reachCage.unlockedCage == true)
        {
            targetAnimator.SetBool("unlockedCage", true);
        }
    }

}
