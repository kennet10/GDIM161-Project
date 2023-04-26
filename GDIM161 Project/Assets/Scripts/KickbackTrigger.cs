using UnityEngine;

public class KickbackTrigger : MonoBehaviour
{
    public float kickbackForce = 1000f; // Adjust this value to control the strength of the kickback

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody ballRB = other.GetComponent<Rigidbody>();
            ballRB.AddForce(-ballRB.velocity.normalized * kickbackForce);
        }
    }
}
