using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anykey : MonoBehaviour
{
    [SerializeField] private int levelToLoad = 0;
    [SerializeField] private float delayBeforeActivation = 1f; // Time in seconds

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = delayBeforeActivation;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return; // Skip checking for key press if timer hasn't reached zero
        }

        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(levelToLoad);
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI/Start", GetComponent<Transform>().position);
        }
    }
}
