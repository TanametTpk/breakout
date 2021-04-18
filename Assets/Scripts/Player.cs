using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, Damagable
{
    public Knockback knockback;
    public int hp;
    public float speed;
    public int energy;
    public float knockbackForce = 10;
    public UnityEvent OnDead;

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

    public void useEnegy(int usageEnegy)
    {
        energy = energy - usageEnegy;
        if (energy < 0) energy = 0;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Enemy")) {
            Vector2 difference = other.transform.position - transform.position;
            knockback.perform(difference.normalized * -knockbackForce);
            
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.Attack(this);
        }
        else if (other.gameObject.tag.Equals("ball")) {
            Destroy(other.gameObject);
            this.energy += 1;
        }
    }
}
