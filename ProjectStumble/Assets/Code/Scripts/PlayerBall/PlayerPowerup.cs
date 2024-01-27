using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    public event Action<PowerupData> OnGainNewPowerup;
    public event Action OnUseCurrentPowerup;

    [SerializeField] private PowerupData _powerUpData;

    private BallPlayerInput _ballPlayerInput;
    private PhysicMaterial _ballPhysicMaterial;

    private float _speedBoostTorque;

    public float SpeedBoostTorque { get => _speedBoostTorque; set => _speedBoostTorque = value; }

    private void Awake() 
    {
        _ballPlayerInput = GetComponent<BallPlayerInput>();
    }

    private void OnEnable() => _ballPlayerInput.OnUseItemCommand += BallPlayerInput_OnUseItemCommand;
    private void OnDisable() => _ballPlayerInput.OnUseItemCommand -= BallPlayerInput_OnUseItemCommand;

    private void BallPlayerInput_OnUseItemCommand() => ActivatePowerup();

    public void OnAssignPowerup(PowerupData powerupData)
    {
        _powerUpData = powerupData;
        OnGainNewPowerup?.Invoke(_powerUpData);
    }

    public void ActivatePowerup()
    {
        switch(_powerUpData.PowerupType)
        {
            case PowerupType.Stun:
            break;
            case PowerupType.SpeedBoost:
                ActivateSpeedBoost();
                break;
            case PowerupType.Wetter:
                break;
            case PowerupType.Shrink:
                break;
            case PowerupType.Push:
                break;
        }

        OnUseCurrentPowerup?.Invoke();
        _powerUpData = null;
    }

    private void ActivateSpeedBoost()
    {
        DOTween.To(() => _speedBoostTorque, x => _speedBoostTorque = x, 5f, 0f);
        DOTween.To(() => _speedBoostTorque, x => _speedBoostTorque = x, 0f, 0f).SetDelay(3f);
    }
}
