using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float force = 10f;
    public float duration = 0.3f;

    public void perform(Vector2 direction, Rigidbody2D target) {
        target.AddForce(direction * -force, ForceMode2D.Impulse);
    }
}
