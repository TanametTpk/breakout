using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlockManager : MonoBehaviour
{
    
    public void OnBlockDestroy() {
        if (isAllBlocksDestoyed()) {
            EndScreen config = new EndScreen();

            config.title = "Victory!";
            config.description = "Nice try man!";
            config.isVictory = true;

            FindObjectOfType<GameManager>().ShowEndScreen(config);
        }
    }

    private bool isAllBlocksDestoyed() {
        if (this.gameObject.transform.childCount > 1) return false;
        return true;
    }
}
