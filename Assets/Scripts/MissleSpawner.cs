using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleSpawner : MonoBehaviour
{
    public int maxMissle = 10;
    public float timeStart = 1f;
    public float repeatSecond = 2f;
    public GameObject misslePrefab;
    private void Start() {
        InvokeRepeating("SpawnMissle", timeStart, repeatSecond);
    }

    public void SpawnMissle() {
        if (!IsCanCreateMissle()) return;
        GameObject missle = Instantiate(misslePrefab, transform.position, Quaternion.identity);
        missle.transform.parent = this.transform;
    }

    public bool IsCanCreateMissle() {
        return this.gameObject.transform.childCount < maxMissle;
    }
}
