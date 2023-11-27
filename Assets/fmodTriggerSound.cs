using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEventTrigger : MonoBehaviour
{
    public EventReference fmodEventReference;

    private bool hasEventBeenTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the event has not been triggered yet
        if (!hasEventBeenTriggered && collision.gameObject.CompareTag("Tounge"))
        {
            // Trigger the FMOD event using EventReference
            FMODUnity.RuntimeManager.PlayOneShot(fmodEventReference, transform.position);

            // Set the flag to indicate that the event has been triggered
            hasEventBeenTriggered = true;
        }
    }
}
