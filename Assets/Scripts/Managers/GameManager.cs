using UnityEngine;
using UnityEngine.SceneManagement;

public struct EndScreen {
    public string title;
    public string description;
    public bool isVictory;
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public EndScreen config;

    void Awake() {
        if (instance == null){
            instance = this;
            config = new EndScreen();
            config.title = "Game Over";
            config.description = "and you are so noob.";
            config.isVictory = false;
        }
        else if (instance != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void ShowEndScreen(EndScreen config) {
        this.config = config;

        if (config.isVictory) {
            LoadNextScene();
        }else {
            SkipToEndScene();
        }
    }

    private void LoadNextScene() {
        LevelLoader loader = FindObjectOfType<LevelLoader>();
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(loader.LoadLevel(sceneIndex));
    }

    private void SkipToEndScene() {
        LevelLoader loader = FindObjectOfType<LevelLoader>();
        int sceneIndex = SceneManager.sceneCountInBuildSettings - 2;
        StartCoroutine(loader.LoadLevel(sceneIndex));
    }
}
