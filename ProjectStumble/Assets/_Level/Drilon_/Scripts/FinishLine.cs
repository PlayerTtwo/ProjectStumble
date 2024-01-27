using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.TryGetComponent(out PlayerFinish playerFinish))
        {
            playerFinish.PlayFinishVFX();
        } 
    }
}
