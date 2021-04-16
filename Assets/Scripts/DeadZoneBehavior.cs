using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadZoneBehavior : MonoBehaviour
{
    public UnityEvent OnHit;

    public BallBehavior ball;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("ball")) {
            ball.Reset();
            OnHit.Invoke();
        }
    }
}
