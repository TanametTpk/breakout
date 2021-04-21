using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public Transform currentCheckpoint;
    
    public void SetCheckpoint(Transform checkpoint) {
        currentCheckpoint = checkpoint;
    }

    public void MoveToCheckPoint(Transform target) {
        target.position = currentCheckpoint.position;
    }
}
