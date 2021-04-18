using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 _velocity;
    private void Start() {
        _velocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Reflect(rb, other.GetContact(0).normal);
    }

    private void Reflect(Rigidbody2D rb, Vector2 reflectVector) {
        this.rb.velocity = Vector2.Reflect(_velocity * 0.5f, reflectVector);
    }
}
