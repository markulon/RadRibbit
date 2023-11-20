using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; // Make sure to include the FMODUnity namespace



public class FMOD_onlyOne : MonoBehaviour
{
    [EventRef(MigrateTo = "eventReference")] // Updated attribute
    public EventReference eventReference; // Added declaration for eventReference

    private bool hasEventBeenTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the event has not been triggered yet
        if (!hasEventBeenTriggered)
        {
            // Trigger the FMOD event using EventReference
            FMODUnity.RuntimeManager.PlayOneShot(eventReference, transform.position);

            // Set the flag to indicate that the event has been triggered
            hasEventBeenTriggered = true;
        }
    }
}