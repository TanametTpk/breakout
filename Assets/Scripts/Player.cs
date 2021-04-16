using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, Damagable
{
    public PlayerController controller;
    public int hp;
    public float speed;
    public int energy;
    public float knockbackForce = 10;
    public float knockbackDuration = 0.3f;
    public UnityEvent OnDead;
    public bool isKnockBack = false;

    public bool IshaveEnergy() {
        return energy > 0;
    }

    public bool IsDead() {
        return hp < 1;
    }

    public void WasAttacked(int damage) {
        hp -= damage;
        if (hp < 0) hp = 0;
        if (IsDead()) OnDead.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Enemy")) {
            Vector2 difference = other.transform.position - transform.position;
            controller.Knockback(difference.normalized * -knockbackForce, knockbackDuration);
        }
    }
}
