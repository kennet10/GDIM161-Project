using System.Collections;
using UnityEngine;

public class ScaryMaskTrigger : MonoBehaviour
{
    public GameObject scaryMask; // Attach your ScaryMask object here in the inspector
    public float displayTime = 1f; // Duration for which the mask stays visible
    public Animator maskAnimator; // Reference to the Animator component of the mask object
    private AudioSource scarySound; // To play sound effect

    private void Start()
    {
        // Assuming the AudioSource component is attached to the same GameObject
        scarySound = scaryMask.GetComponent<AudioSource>();

        // Make sure the audio source is enabled
        scarySound.enabled = true;

        // Make the mask invisible at the start
        scaryMask.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball")) // Assuming your ball object has a tag "Ball"
        {
            ShowScaryMask();
        }
    }

    private void ShowScaryMask()
    {
        maskAnimator.SetTrigger("ShowMask"); // Trigger the animation

        // Make sure the audio source is enabled
        scarySound.enabled = true;

        // Play the scary sound
        scarySound.Play();

        // Make the mask visible
        scaryMask.SetActive(true);

        // Start a coroutine to hide the mask after the displayTime
        StartCoroutine(HideScaryMask());
    }

    IEnumerator HideScaryMask()
    {
        // Wait for displayTime seconds
        yield return new WaitForSeconds(displayTime);

        // Make the mask invisible again
        scaryMask.SetActive(false);

        // Disable the audio source
        scarySound.enabled = false;
    }
}
