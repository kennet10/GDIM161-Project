using UnityEngine;

public class TableController : MonoBehaviour
{
    [SerializeField] private float maxTiltAngle = 30f;
    [SerializeField] private float tiltSpeed = 10f;
    [SerializeField] private float returnSpeed = 5f;

    private float currentTiltAngleX = 0f;
    private float currentTiltAngleZ = 0f;

    // Add an AudioSource component to the game object and assign an audio clip to it in the inspector
    private AudioSource audioSource;

    // Assign the audio clip to the audio source in the Start() method
    [SerializeField] private AudioClip audioClip;

    private bool isTableTilted = false;

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Assign the audio clip to the audio source
        audioSource.clip = audioClip;
    }

    private void Update()
    {
        // Get input for tilting the table
        float tiltX = Input.GetAxis("Vertical");
        float tiltZ = Input.GetAxis("Horizontal");

        // Calculate the new tilt angles based on input and tilt speed
        currentTiltAngleX += tiltX * tiltSpeed * Time.deltaTime;
        currentTiltAngleX = Mathf.Clamp(currentTiltAngleX, -maxTiltAngle, maxTiltAngle);

        currentTiltAngleZ -= tiltZ * tiltSpeed * Time.deltaTime;
        currentTiltAngleZ = Mathf.Clamp(currentTiltAngleZ, -maxTiltAngle, maxTiltAngle);

        // Return the table to the straight position if no input is detected
        if (tiltX == 0f)
        {
            currentTiltAngleX = Mathf.Lerp(currentTiltAngleX, 0f, returnSpeed * Time.deltaTime);
        }
        if (tiltZ == 0f)
        {
            currentTiltAngleZ = Mathf.Lerp(currentTiltAngleZ, 0f, returnSpeed * Time.deltaTime);
        }

        // Set the rotation of the table based on the tilt angles
        transform.rotation = Quaternion.Euler(currentTiltAngleX, 0f, currentTiltAngleZ);

        // Check if the table is tilted
        if ((tiltX != 0f || tiltZ != 0f) && !isTableTilted)
        {
            // Play the audio clip if it's not already playing
            audioSource.PlayOneShot(audioClip);

            // Set the flag to true so the audio clip doesn't play again until the table is tilted again
            isTableTilted = true;
        }
        else if (tiltX == 0f && tiltZ == 0f)
        {
            // Reset the flag when the table is back to the straight position
            isTableTilted = false;
        }
    }
}
