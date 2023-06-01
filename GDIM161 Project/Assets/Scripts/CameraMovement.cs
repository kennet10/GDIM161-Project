using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;        // Speed of the camera movement
    public float amplitude = 0.5f;        // Maximum distance the camera can move
    public float frequency = 1.0f;        // Speed of the camera oscillation
    public float maxOffset = 0.1f;        // Maximum random offset for camera movement
    public float offsetChangeInterval = 1.0f;    // Interval at which to change the random offset
    private Vector3 initialPosition;      // Initial position of the camera
    private Vector3 targetPosition;       // Target position for camera movement
    private float randomOffsetX = 0f;     // Random offset in the X-axis direction
    private float randomOffsetY = 0f;     // Random offset in the Y-axis direction
    private float offsetChangeTimer = 0f; // Timer for changing the random offset

    void Start()
    {
        initialPosition = transform.position;
        ChangeRandomOffsets();
    }

    void Update()
    {
        offsetChangeTimer += Time.deltaTime;

        if (offsetChangeTimer >= offsetChangeInterval)
        {
            ChangeRandomOffsets();
            offsetChangeTimer = 0f;
        }

        float xOffset = Mathf.Sin(Time.time * frequency) * amplitude + randomOffsetX;
        float yOffset = Mathf.Cos(Time.time * frequency) * amplitude + randomOffsetY;
        targetPosition = initialPosition + new Vector3(xOffset, yOffset, 0);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }

    void ChangeRandomOffsets()
    {
        randomOffsetX = Random.Range(-maxOffset, maxOffset);
        randomOffsetY = Random.Range(-maxOffset, maxOffset);
    }
}
