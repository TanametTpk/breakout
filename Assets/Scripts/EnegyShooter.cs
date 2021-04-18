using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnegyShooter : MonoBehaviour
{
    public Player playerInfo;
    public GameObject enegyPrefab;
    public Transform spawnPosition;
    public PlayerAim aim;
    public Rigidbody2D rb;
    public float speed = 10f;

    public void OnShoot(InputAction.CallbackContext context) {
        if (context.started) Shoot();
    }

    public void Shoot() {
        if (!playerInfo.IshaveEnergy()) return;
        playerInfo.useEnegy(1);

        Vector2 aimPosition = aim.getAimPosition();
        Vector2 bodyPosition = rb.position;
        Vector2 targetDirection = aimPosition - bodyPosition;
        
        CreateEnegy(targetDirection.normalized);
    }

    private void CreateEnegy(Vector2 direction){
        GameObject enegy = Instantiate(enegyPrefab, spawnPosition.position, Quaternion.identity);
        Rigidbody2D rb = enegy.GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
    }
}
