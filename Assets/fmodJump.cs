using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


public class FMODKeyTrigger : MonoBehaviour

private enum MovementPlayerState
{
    FMOD.Studio.EventInstance myEvent;
    bool IsGrounded = true; // You might need to set this based on your actual grounded detection logic

    void Start()
    {
        myEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Foley/Froggy/Froggy_Jump"); // Replace with your actual FMOD event path
    }

    void Update()
    {
        // Replace KeyCode.W with the key you want to use
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded)
        {
            PlayFMODEvent();
        }
    }

    void PlayFMODEvent()
    {
        myEvent.start();
    }
}