using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Enemy
{
    private BlockManager blockManager;
    public GameObject explosionEffect;

    private void Start() {
        this.OnDead.AddListener(OnAttacked);
        blockManager = GetComponentInParent<BlockManager>();
    }

    public void OnAttacked() {
        if (this.IsDead()) {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
            blockManager.OnBlockDestroy();
        }   
    }
}
