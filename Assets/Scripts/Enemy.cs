﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour, Attackable, Damagable
{
    public int hp = 1;
    public float speed = 3;
    public int atk = 1;
    public UnityEvent OnDead;

    public void Init(int hp, float speed, int atk) {
        this.hp = hp;
        this.speed = speed;
        this.atk = atk;
    }

    public void Attack(Damagable other) {
        other.WasAttacked(atk);
    }

    public void WasAttacked(int damage) {
        hp -= damage;
        if (hp < 0) hp = 0;
        if (IsDead()) OnDead.Invoke();
    }

    public bool IsDead() {
        return hp <= 0;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            Damagable player = other.gameObject.GetComponent<Damagable>();
            Dash playerDashSkill = other.gameObject.GetComponent<Dash>();
            Rigidbody2D playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            Knockback knockbackEffect = gameObject.GetComponent<Knockback>();

            Vector2 difference = transform.position - other.transform.position;
            knockbackEffect.perform(difference.normalized, playerRigidbody);
            Attack(player);
        }
    }
}
