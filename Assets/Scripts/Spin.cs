using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    private void FixedUpdate() {
        rb.angularVelocity = speed;
    }
}
