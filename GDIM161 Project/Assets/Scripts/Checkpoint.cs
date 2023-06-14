using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public GameObject spawnpoint;
    public Light spotlight;

    private void OnTriggerEnter(Collider other)
    {
        spawnpoint.transform.position = transform.position;
        spotlight.gameObject.SetActive(true);
    }
}
