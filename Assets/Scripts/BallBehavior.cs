using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D other) {
        Reflect(other.GetContact(0).normal);
    }

    private void Reflect(Vector2 reflectVector) {
        Debug.Log("before:" + rb.velocity);
        rb.velocity = Vector2.Reflect(rb.velocity, reflectVector);
        Debug.Log("after:" + Vector2.Reflect(rb.velocity, reflectVector));
    }
}
