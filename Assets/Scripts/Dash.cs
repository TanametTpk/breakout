using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody2D rb;
    public TrailRenderer trail;
    public float speed = 20;
    public float duration = 0.1f;
    private Vector2 originalVelocity;
    public bool isDash = false;

    void Start()
    {
        trail.forceRenderingOff = true;
    }

    public void Perform(InputAction.CallbackContext context) {
        if (context.started) StartDash();
    }

    private void StartDash() {
        isDash = true;
        trail.forceRenderingOff = false;
        Vector2 velocity = movement.GetMovingDirection();
        originalVelocity = velocity;
        rb.AddForce(velocity.normalized * speed, ForceMode2D.Impulse);
        Invoke("StopDash", duration);
        FindObjectOfType<AudioManager>().Play("Dash");
    }

    private void StopDash() {
        isDash = false;
        trail.forceRenderingOff = true;
        rb.velocity = originalVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Damagable damagedObj = other.gameObject.GetComponent<Damagable>();
        if (isDash && damagedObj != null) {
            damagedObj.WasAttacked(2);
        }
    }
}
