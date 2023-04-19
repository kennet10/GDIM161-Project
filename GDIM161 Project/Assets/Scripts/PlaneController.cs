using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float tiltSpeed = 30f; // Speed of tilt in degrees per second

    // Update is called once per frame
    void Update()
    {
        // Get input from user
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Tilt the plane based on input
        transform.rotation = Quaternion.Euler(vertical * tiltSpeed, 0f, -horizontal * tiltSpeed);
    }
}
