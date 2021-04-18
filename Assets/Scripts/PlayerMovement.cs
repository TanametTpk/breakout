using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Player playerInfo;
    public Rigidbody2D rb;
    private Vector2 movingDirection;
    
    private void FixedUpdate() {
        Move();
    }

    public void OnMove(InputAction.CallbackContext value) {
        movingDirection = value.ReadValue<Vector2>();
    }
    public void Move() {
        rb.AddForce(movingDirection * playerInfo.speed, ForceMode2D.Force);
    }

}
