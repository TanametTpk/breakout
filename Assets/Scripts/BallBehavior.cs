using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour, Attackable
{
    public Rigidbody2D rb;
    public int damage = 1;
    private Vector2 _velocity;
    private void Start() {
        _velocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Reflect(rb, other.GetContact(0).normal);

        if (other.gameObject.tag.Equals("Enemy")) {
            Damagable enemy = other.gameObject.GetComponent<Damagable>();
            this.Attack(enemy);
        }
    }

    private void Reflect(Rigidbody2D rb, Vector2 reflectVector) {
        this.rb.velocity = Vector2.Reflect(_velocity * 0.5f, reflectVector);
    }

    public void Attack(Damagable other)
    {
        other.WasAttacked(damage);
    }
}
