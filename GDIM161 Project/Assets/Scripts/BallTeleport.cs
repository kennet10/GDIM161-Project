using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallTeleport : MonoBehaviour
{

    public BallController ballController;
    public BallTeleport otherTeleporter;
    public Animator animator;

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
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        ballController.gameObject.transform.position = otherTeleporter.transform.position;
        yield return new WaitForSeconds(1f);

        animator.SetTrigger("End");
        ballController.disabled = false;
        ballController.ResumeMovement();
    }

    
}
