using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Enemy
{
    private BlockManager blockManager;

    private void Start() {
        this.OnDead.AddListener(OnAttacked);
        blockManager = GetComponentInParent<BlockManager>();
    }

    public void OnAttacked() {
        if (this.IsDead()) {
            Destroy(this.gameObject);
            blockManager.OnBlockDestroy();
        }   
    }
}
