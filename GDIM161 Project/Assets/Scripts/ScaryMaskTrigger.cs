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

        // Make the mask invisible at the start
        scaryMask.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball")) // Assuming your player object has a tag "Player"
        {
            StartCoroutine(ShowScaryMask());
        }
    }

    IEnumerator ShowScaryMask()
    {
        maskAnimator.SetTrigger("ShowMask"); // Trigger the animation
        scarySound.Play(); // Play the scary sound

        // Wait for displayTime seconds
        yield return new WaitForSeconds(displayTime);

        scaryMask.SetActive(false); // Make the mask invisible again
    }
}
