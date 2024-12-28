using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToggle : MonoBehaviour
{
    public Animator animator; // Assign the Animator in the Inspector
    public string animationName = "Sun"; // The name of the animation state

    private bool isPlaying = true; // Tracks whether the animation is playing
    private float currentTime = 0f; // Tracks the current animation time

    void Update()
    {
        // Check for key press (e.g., spacebar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPlaying)
            {
                // Pause the animation
                currentTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime; // Get current progress (0 to 1)
                animator.speed = 0f; // Pause the animation
                isPlaying = false;
            }
            else
            {
                // Resume the animation
                animator.Play(animationName, 0, currentTime % 1); // Resume from the saved progress
                animator.speed = 1f; // Resume playback speed
                isPlaying = true;
            }
        }
    }
}


