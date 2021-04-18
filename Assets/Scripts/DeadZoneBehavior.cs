using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadZoneBehavior : MonoBehaviour
{
    public UnityEvent OnHit;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("ball")) {
            Destroy(other.gameObject);
            OnHit.Invoke();
        }
    }
}
