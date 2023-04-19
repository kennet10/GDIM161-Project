using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ball;
    public float smoothTime = 0.3f;
    public float maxDistance = 10.0f;
    public float minDistance = 1.0f;

    private float currentSpeed;
    private float targetDistance;
    private float currentDistance;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // Get the current speed of the ball
        currentSpeed = ball.GetComponent<Rigidbody>().velocity.magnitude;

        // Calculate the target distance based on the current speed
        targetDistance = Mathf.Lerp(minDistance, maxDistance, currentSpeed / 10.0f);

        // Smoothly move the camera towards the target distance
        currentDistance = Mathf.SmoothDamp(currentDistance, targetDistance, ref velocity.x, smoothTime);

        // Update the camera position based on the ball position and the current distance
        transform.position = ball.transform.position - transform.forward * currentDistance;
    }
}
