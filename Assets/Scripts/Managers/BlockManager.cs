using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlockManager : MonoBehaviour
{
    public UnityEvent OnAllBlocksDestoyed;
    
    public void OnBlockDestroy() {
        if (isAllBlocksDestoyed()) {
            OnAllBlocksDestoyed.Invoke();
        }
    }

    private bool isAllBlocksDestoyed() {
        if (this.gameObject.transform.childCount > 1) return false;
        return true;
    }
}
