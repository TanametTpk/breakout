using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Player playerInfo;
    public Rigidbody2D rigidbody;
    public Camera camera;
    public Animator camAnimator;
    public SpriteRenderer sprite;
    private Vector2 movingDirection;
    private Vector2 aimPosition;
    private bool isKnockback = false;

    private void FixedUpdate() {
        Move();
        Aim();
    }

    public void OnMove(InputAction.CallbackContext value) {
        movingDirection = value.ReadValue<Vector2>();
    }
    public void Move() {
        if (isKnockback) return;
        rigidbody.velocity = movingDirection * playerInfo.speed;
    }

    public void Aim() {
        Vector2 lookDirection = aimPosition - rigidbody.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = angle;
    }

    public void OnMousePositionChange(InputAction.CallbackContext value) {
        Vector2 rawPosition = value.ReadValue<Vector2>();
        aimPosition = camera.ScreenToWorldPoint(rawPosition);
    }

    public void Knockback(Vector2 force, float duration) {
        isKnockback = true;
        sprite.color = Color.red;
        rigidbody.AddForce(force, ForceMode2D.Impulse);
        camAnimator.SetTrigger("shake");
        Invoke("ReleaseKnockback", duration);
    }

    private void ReleaseKnockback() {
        isKnockback = false;
        sprite.color = Color.white;
    }
}
