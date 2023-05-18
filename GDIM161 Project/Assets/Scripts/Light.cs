using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    void Update()
    {
        if (Random.value > 0.9) //a random chance
        {
            if (GetComponent<UnityEngine.Light>().enabled == true) //if the light is on...
            {
                GetComponent<UnityEngine.Light>().enabled = false; //turn it off
            }
            else
            {
                GetComponent<UnityEngine.Light>().enabled = true; //turn it on
            }
        }
    }
}
