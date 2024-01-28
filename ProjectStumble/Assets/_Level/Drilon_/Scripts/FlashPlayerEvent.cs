using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashPlayerEvent : MonoBehaviour
{
    public event Action OnPlayerTouchOtherPlayer;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.root.TryGetComponent(out PlayerBallMovementController player))
        {
            OnPlayerTouchOtherPlayer?.Invoke();
        }
    }
}
