using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffectWhenDestroy : MonoBehaviour
{
    public GameObject effect;

    private void OnDestroy() {
        Instantiate(effect, transform.position, transform.rotation);
    }
}
