using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float rotageSpeed = 200f;
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
        if (tag.Equals("Player") || tag.Equals("ball") || tag.Equals("Wall")) {
            Player player = other.gameObject.GetComponent<Player>();
            if (player) player.WasAttacked(1);
            // create effect
            Destroy(gameObject);
        }
    }
}
