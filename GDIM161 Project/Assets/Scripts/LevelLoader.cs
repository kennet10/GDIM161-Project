using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    void Update()
    {
        // Load Level 1 with the '1' key
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadLevel("Level1Version2");
        }

        // Load Level 2 with the '2' key
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadLevel("Level2");
        }

        // Load Level 3 with the '3' key
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LoadLevel("Level3");
        }

        // Load Level 4 with the '4' key
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            LoadLevel("Level4 (Kenneth)");
        }

        // Load Level 5 with the '5' key
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            LoadLevel("Level5 (Cam)");
        }

        // Quit the game with the 'L' key
        if (Input.GetKeyDown(KeyCode.L))
        {
            QuitGame();
        }
    }

    void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
