using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public float maxSpeed = 10f;
    public float acceleration = 1f;
    public float deceleration = 1f;

    private Rigidbody rb;

    // Event that other scripts can subscribe to in order to get the ball's speed
    public delegate void SpeedChanged(float speed);
    public static event SpeedChanged OnSpeedChanged;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        rb.AddForce(movement * acceleration);

        // Limit the speed of the ball
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        // Slow down the ball if there is no input
        if (horizontal == 0 && vertical == 0)
        {
            rb.velocity = Vector3.MoveTowards(rb.velocity, Vector3.zero, deceleration);
        }

        // Broadcast the current speed of the ball
        if (OnSpeedChanged != null)
        {
            OnSpeedChanged(rb.velocity.magnitude);
        }
    }
}
