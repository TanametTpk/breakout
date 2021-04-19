using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFinish : MonoBehaviour
{
    private ParticleSystem ps;
    public void Start() 
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void Update() 
    {
        if(ps && !ps.IsAlive()) {
            Destroy(gameObject);
        }
    }
}
