using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EndScreen {
    public string title;
    public string description;
    public bool isVictory;
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    
    void Awake() {
        if (instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void ShowEndScreen(EndScreen config) {
        // TODO - show end screen logic here.
        Debug.Log("title:" + config.title);
        Debug.Log("description:" + config.description);
        Debug.Log("isVictory:" + config.isVictory.ToString());
    }
}
