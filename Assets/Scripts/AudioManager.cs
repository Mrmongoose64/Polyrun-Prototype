using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSound : MonoBehaviour
{
    // Calls the AudioSource component that will play the sounds
    public AudioSource audioSource;
    // The array that holds the 5 sound effects
    public AudioClip[] soundEffects;
    private Vector3 lastPosition;

    // Update is called once per frame
    void Update()
    {
        // Checks if the player is moving based on what their last position was
        if ((transform.position - lastPosition).magnitude > 0.01f)
        {
            // Calls the PlayRandomSound function if no sound effect is playing
            if (audioSource.isPlaying == false)
            {
                PlayRandomSound();
            }
        }
        // If the player stops moving, the final sound finishes playing and the AudioSource stops
        else
        {
            if (audioSource.isPlaying == false)
            {
                audioSource.Stop();
            }
        }

        // The player's last position is updated every frame
        lastPosition = transform.position;
    }

    private void PlayRandomSound()
    {
        // When run, a random sound effect is picked from the AudioClip array and played
        audioSource.clip = soundEffects[Random.Range(0, soundEffects.Length)];
        audioSource.Play();
    }
}
