using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 10f; // Speed of the ball
    public float maxTiltAngle = 30f; // Maximum tilt angle of the table
    public Transform tableTransform; // Reference to the table transform
    private Rigidbody rb; // Reference to the ball rigidbody

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called at fixed intervals
    void FixedUpdate()
    {
        // Calculate the tilt angle of the table
        float tiltX = Mathf.Clamp(tableTransform.rotation.eulerAngles.x, -maxTiltAngle, maxTiltAngle);
        float tiltZ = Mathf.Clamp(tableTransform.rotation.eulerAngles.z, -maxTiltAngle, maxTiltAngle);

        // Calculate the tilt vector based on the table tilt angle
        Vector3 tilt = new Vector3(-tiltX, 0f, tiltZ);

        // Apply the tilt force to the ball
        rb.AddForce(tilt * speed);
    }
}
