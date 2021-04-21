using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Home() {
        LoadScene(0);
    }

    public void BonusLevel() {
        LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void PlayGame() {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        LoadScene(sceneIndex);
    }

    private void LoadScene(int index) {
        LevelLoader loader = FindObjectOfType<LevelLoader>();
        StartCoroutine(loader.LoadLevel(index));
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
