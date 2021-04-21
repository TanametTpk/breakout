using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckPointManager manager;
    void Start()
    {
        manager = FindObjectOfType<CheckPointManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        manager.SetCheckpoint(this.transform);
    }
}
