using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallBehavior : MonoBehaviour
{
    public float initial_speed = 1;
    public Rigidbody2D rigidbody;
    private Vector2 velocity;
    private Vector2 startPosition;
    private bool isStart = false;

    private void Start() {
        startPosition = new Vector2(transform.position.x, transform.position.y);
        velocity = new Vector2(0, 0);
    }
    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        rigidbody.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Reflect(rigidbody, other.GetContact(0).normal);
    }

    private void Reflect(Rigidbody2D rigidbody, Vector2 reflectVector) {
        velocity = Vector2.Reflect(velocity, reflectVector);
    }

    public void Reset() {
        transform.position = new Vector2(startPosition.x, startPosition.y);
        velocity = new Vector2(0, 0);
        isStart = false;
    }

    public void OnStart(InputAction.CallbackContext value) {
        if (!isStart)
            velocity = new Vector2(0, initial_speed);
        isStart = true;
    }
}
