using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 lastCheckPointPosition;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out SphereCollider playerCollider)) return;
        lastCheckPointPosition  = playerCollider.transform.root.position;
        Respawn.Instance.lastCheckPointPosition = lastCheckPointPosition;
    }

   
}
