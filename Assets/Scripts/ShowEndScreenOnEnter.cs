using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEndScreenOnEnter : MonoBehaviour
{
    public GameObject obj;

    private void OnTriggerEnter2D(Collider2D other) {
        obj.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Scream");
    }
}
