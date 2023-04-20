using UnityEngine;
using TMPro;

public class RealTimeDisplay : MonoBehaviour
{
    public TMP_Text realTimeText;

    void Update()
    {
        // Get the current time and format it as a string
        string currentTime = System.DateTime.Now.ToString("hh:mm:ss tt");

        // Update the text on the UI with the current time
        realTimeText.text = "Time: " + currentTime;
    }
}
