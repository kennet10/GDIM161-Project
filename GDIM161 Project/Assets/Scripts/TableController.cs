using UnityEngine;

public class TableController : MonoBehaviour
{
    [SerializeField] private float maxTiltAngle = 30f;
    [SerializeField] private float tiltSpeed = 10f;
    [SerializeField] private float returnSpeed = 5f;

    private float currentTiltAngleX = 0f;
    private float currentTiltAngleZ = 0f;

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
    }
}
