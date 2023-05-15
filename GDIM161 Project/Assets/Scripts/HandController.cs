using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public AudioSource fallSound; // assign this in the Inspector

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall") // replace with your table's GameObject name
        {
            fallSound.Play();
        }
    }
}
