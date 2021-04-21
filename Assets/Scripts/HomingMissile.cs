using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float rotageSpeed = 200f;
    public GameObject explosionEffect;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        float rotageAmount = Vector3.Cross(direction.normalized, transform.up).z;
        rb.angularVelocity = -rotageAmount * rotageSpeed;

        rb.velocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D other) {
        string tag = other.gameObject.tag;

        if (tag.Equals("Player")) {
            Player player = other.gameObject.GetComponent<Player>();
            Dash dash = other.gameObject.GetComponent<Dash>();
            if (player && dash && !dash.isDash) {
                player.WasAttacked(1);
            }
            FindObjectOfType<AudioManager>().Play("MissleHit");
        }

        if (!tag.Equals("Enemy") && !tag.Equals("Missile")) {
            CreateExplosionEffect(rb.velocity.x, rb.velocity.y);
            Destroy(gameObject);
        }
    }

    private void CreateExplosionEffect(float velocityX, float velocityY) {
        ParticleSystem effect = explosionEffect.GetComponent<ParticleSystem>();
        ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = effect.velocityOverLifetime;

        ParticleSystem.MinMaxCurve xVelocity = new ParticleSystem.MinMaxCurve(velocityX);
        ParticleSystem.MinMaxCurve yVelocity = new ParticleSystem.MinMaxCurve(velocityY);

        velocityOverLifetime.x = xVelocity;
        velocityOverLifetime.y = yVelocity;

        Instantiate(explosionEffect, transform.position, transform.rotation);
    }
}
