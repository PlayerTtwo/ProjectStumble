using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : SceneSingleton<Respawn>
{
    public Vector3 lastCheckPointPosition;
    private Vector3 offset;

    private void Awake()
    {
        offset = new Vector3(0, 1, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SphereCollider playerCollider))
            playerCollider.transform.root.position = lastCheckPointPosition + offset;
    }
}
