using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        // If the splash scene is currently loaded, go to start after 1s
        if (SceneManager.GetActiveScene().name == "_Splash")
        {
            StartCoroutine(LoadSceneWithDelay("_Start", 1f));
        }
    }

    public void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadNextLevelWithDelay(currentIndex + 1));
    }

    private IEnumerator LoadNextLevelWithDelay(int index, float delay = 1f)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(index);
    }

    public void LoadStart()
    {
        SceneManager.LoadScene("_Start");
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevelWithDelay(string sceneName, float delay = 1f)
    {
        StartCoroutine(LoadSceneWithDelay(sceneName, delay));
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
