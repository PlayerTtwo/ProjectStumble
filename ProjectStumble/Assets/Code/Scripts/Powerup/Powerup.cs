using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private Transform _collectVfx;

    private void Awake()
    {
        AssignRandomPowerupType();
    }

    private void AssignRandomPowerupType()
    {

    }

    public void Collect()
    {
        Debug.Log("Collected powerup");
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.GetComponentInParent<PlayerBallMovementController>() != null)
        {
            LeanPool.Spawn(_collectVfx, transform.position, _collectVfx.rotation);
            gameObject.SetActive(false);
        }
    }
}
