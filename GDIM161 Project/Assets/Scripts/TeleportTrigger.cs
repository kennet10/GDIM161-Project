using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public GameObject[] teleportPoints; // Assign the teleport points in the Unity editor
    public float teleportDelay = 1.0f; // The delay before teleporting (in seconds)
    public AudioClip teleportSound; // Assign the teleport sound in the Unity editor
    public ParticleSystem teleportVFX; // Assign the teleport VFX particle system in the Unity editor

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball") && gameObject.CompareTag("Teleporter"))
        {
            StartCoroutine(TeleportWithDelay(other.gameObject, teleportDelay));
        }
    }

    IEnumerator TeleportWithDelay(GameObject ball, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (teleportPoints.Length == 0)
        {
            Debug.LogWarning("No teleport points assigned.");
            yield break;
        }

        int randomIndex = Random.Range(0, teleportPoints.Length);
        Vector3 newPosition = teleportPoints[randomIndex].transform.position;

        // Set the Y-coordinate to place the ball on the surface of the point.
        newPosition.y += ball.GetComponent<SphereCollider>().radius;

        // Play teleport VFX, if one is assigned.
        if (teleportVFX != null)
        {
            teleportVFX.Play();
        }

        ball.transform.position = newPosition;

        // Play teleport sound, if one is assigned.
        if (teleportSound != null)
        {
            audioSource.PlayOneShot(teleportSound);
        }
        else
        {
            Debug.LogWarning("No teleport sound assigned.");
        }
    }
}
