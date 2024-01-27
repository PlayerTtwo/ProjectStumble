using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : SceneSingleton<Respawn>
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.TryGetComponent(out PlayerRespawn playerRespawn))
        {
            playerRespawn.Respawn();
        } 
    }
}
