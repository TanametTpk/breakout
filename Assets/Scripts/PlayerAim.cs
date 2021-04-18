using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rb;
    private Vector2 aimPosition;
    private void FixedUpdate() {
        Aim();
    }

    public void Aim() {
        Vector2 lookDirection = aimPosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void OnMouseReceivePosition(InputAction.CallbackContext value) {
        Vector2 rawPosition = value.ReadValue<Vector2>();
        aimPosition = cam.ScreenToWorldPoint(rawPosition);
    }

    public Vector2 getAimPosition() {
        return aimPosition;
    }
}
