using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneMessage : MonoBehaviour
{
    public Text title;
    public Text description;

    private void Start() {
        GameManager manager = FindObjectOfType<GameManager>();
        title.text = manager.config.title;
        description.text = manager.config.description;
    }
}
