using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTeleport : MonoBehaviour
{

    public BallController ballController;
    public BallTeleport otherTeleporter;
    public GameObject VFX;

    public bool onCooldown = false;


    private void OnTriggerEnter(Collider other)
    {
        if (!onCooldown)
        {
            StartCoroutine("Teleport");
            otherTeleporter.GetComponent<BallTeleport>().onCooldown = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onCooldown = false;
    }

    IEnumerator Teleport()
    {
        ballController.disabled = true;
        ballController.PauseMovement();

        yield return new WaitForSeconds(0.5f);
        ballController.gameObject.transform.position = otherTeleporter.transform.position;
        yield return new WaitForSeconds(0.5f);

        ballController.disabled = false;
        ballController.ResumeMovement();
    }

    
}
