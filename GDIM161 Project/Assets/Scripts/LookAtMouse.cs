using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public float maxRotationSpeed = 15f; // degrees per second, adjust to your liking
    public float maxRotationAngle = 60f; // maximum angle from initial rotation, adjust to your liking

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Create a ray from the camera going in the direction of the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Assuming the mask is at a fixed distance from the camera
        float distance = (transform.position - Camera.main.transform.position).magnitude;

        // Calculate the point where the ray would intersect a sphere at the distance of the mask
        Vector3 worldPosition = Camera.main.transform.position + ray.direction * distance;

        // Make the mask object face towards the world position
        Vector3 directionToLook = worldPosition - transform.position;
        directionToLook.y -= 0.8f; // Offset to adjust "look-at" point to more naturally represent a face

        Quaternion targetRotation = Quaternion.LookRotation(directionToLook);

        // Calculate the rotation relative to the initial rotation
        Quaternion relativeRotation = Quaternion.Inverse(initialRotation) * targetRotation;
        Vector3 relativeEulerAngles = relativeRotation.eulerAngles;
        // Ensure angles are in the range [-180, 180]
        relativeEulerAngles = new Vector3(
            (relativeEulerAngles.x + 180) % 360 - 180,
            (relativeEulerAngles.y + 180) % 360 - 180,
            (relativeEulerAngles.z + 180) % 360 - 180);

        // Limit the rotation angle
        relativeEulerAngles = Vector3.ClampMagnitude(relativeEulerAngles, maxRotationAngle);

        // Convert back to global rotation
        targetRotation = initialRotation * Quaternion.Euler(relativeEulerAngles);

        // Slowly rotate towards the target rotation
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation, targetRotation, maxRotationSpeed * Time.deltaTime);
    }
}
