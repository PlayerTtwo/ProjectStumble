using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private Transform _collectVfx;

    [SerializeField] private List<PowerupData> _powerUpList = new List<PowerupData>();

    public void Collect(PlayerBallMovementController player)
    {
        int randomPowerupIndex = Random.Range(0, _powerUpList.Count);
        PowerupData powerupData = _powerUpList[randomPowerupIndex];
        player.GetComponent<PlayerPowerup>().OnAssignPowerup(powerupData);
    }

    private void OnTriggerEnter(Collider other) 
    {
        PlayerBallMovementController player = other.GetComponentInParent<PlayerBallMovementController>();
        if (player != null)
        {
            LeanPool.Spawn(_collectVfx, transform.position, _collectVfx.rotation);
            Collect(player);
            gameObject.SetActive(false);
        }
    }
}
