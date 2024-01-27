using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    [SerializeField] private PowerupData _powerUpData;

    private BallPlayerInput _ballPlayerInput;

    private void Awake() => _ballPlayerInput = GetComponent<BallPlayerInput>();

    private void OnEnable() => _ballPlayerInput.OnUseItemCommand += BallPlayerInput_OnUseItemCommand;
    private void OnDisable() => _ballPlayerInput.OnUseItemCommand -= BallPlayerInput_OnUseItemCommand;

    private void BallPlayerInput_OnUseItemCommand() => ActivatePowerup();

    public void OnAssignPowerup(PowerupData powerupData)
    {
        _powerUpData = powerupData;
    }

    public void ActivatePowerup()
    {
        switch(_powerUpData.PowerupType)
        {
            case PowerupType.Stun:
            break;
            case PowerupType.SpeedBoost:
            break;
            case PowerupType.Enlarge:
            break;
            case PowerupType.Shrink:
            break;
            case PowerupType.Push:
            break;
        }
    }
}
