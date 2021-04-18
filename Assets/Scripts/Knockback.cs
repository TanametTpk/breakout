using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Knockback : MonoBehaviour
{
    public PlayerInput playerInput;
    public Rigidbody2D rb;
    public Animator camAnimator;
    public SpriteRenderer sprite;
    public float duration = 0.3f;

    public void perform(Vector2 force) {
        playerInput.actions.Disable();
        
        sprite.color = Color.red;
        rb.AddForce(force, ForceMode2D.Impulse);

        camAnimator.SetTrigger("shake");
        Invoke("ReleaseKnockback", duration);
    }

    private void ReleaseKnockback() {
        playerInput.actions.Enable();
        sprite.color = Color.white;
    }
}
