using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTeleport : MonoBehaviour
{

    public BallController ballController;
    public GameObject otherTeleporter;

    public bool onCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
