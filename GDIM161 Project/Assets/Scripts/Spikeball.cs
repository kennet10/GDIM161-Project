using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikeball : MonoBehaviour
{
    private GameObject spawnPoint;
    private bool onCD;
    public AudioClip audioClip;

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<AudioSource>().clip = audioClip;
            collision.gameObject.GetComponent<AudioSource>().Play();

            StartCoroutine("Respawn", collision);
        }
    }

    private IEnumerator Respawn(Collision collision)
    {
        if (!onCD)
        {
            onCD = true;
            collision.gameObject.transform.position = spawnPoint.transform.position;
            yield return new WaitForSeconds(1f);
            onCD = false;
        }
    }
}
