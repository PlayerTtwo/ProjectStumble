using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 _respawnPosition;

    public void UpdateRespawnPosition()
    {
        _respawnPosition = transform.root.position;
    }
    
    public void Respawn()
    {
        transform.position = _respawnPosition;
    }
}
