using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLevel : MonoBehaviour
{
    public float delay = 1f; // Set the delay time in seconds here
    public Animator animator;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Skull")
        {
            StartCoroutine(LoadNextLevelWithDelay());
        }
    }

    IEnumerator LoadNextLevelWithDelay()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f; // Pause the game
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f; // Resume the game
    }
}
