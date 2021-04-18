﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    public Player playerInfo;
    public PlayerMovement movement;
    public Rigidbody2D rb;
    public TrailRenderer trail;
    public float speed = 20;
    public float duration = 0.1f;
    private Vector2 originalVelocity;

    void Start()
    {
        trail.forceRenderingOff = true;
    }

    public void Perform(InputAction.CallbackContext context) {
        if (context.started) StartDash();
    }

    private void StartDash() {
        playerInfo.isInvulnerable = true;
        trail.forceRenderingOff = false;
        Vector2 velocity = movement.GetMovingDirection();
        originalVelocity = velocity;
        rb.AddForce(velocity.normalized * speed, ForceMode2D.Impulse);
        Invoke("StopDash", duration);
    }

    private void StopDash() {
        playerInfo.isInvulnerable = false;
        trail.forceRenderingOff = true;
        rb.velocity = originalVelocity;
    }
}
