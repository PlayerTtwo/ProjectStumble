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

    private PlayerBallMovementController _playerBallMovementController;
    private BallPlayerInput _ballPlayerInput;

    private float _speedBoostTorque;
    public float SpeedBoostTorque => _speedBoostTorque;

    private void Awake() 
    {
        _playerBallMovementController = GetComponent<PlayerBallMovementController>();
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
                ActivateWetter();
                break;
            case PowerupType.Shrink:
                ActivateShrink();
                break;
            case PowerupType.Push:
                break;
        }

        OnUseCurrentPowerup?.Invoke();
        _powerUpData = null;
    }

    private void ActivateSpeedBoost()
    {
        //Set Values
        _speedBoostTorque = 5f;

        //Delayed Set Value
        DOTween.To(() => _speedBoostTorque, x => _speedBoostTorque = x, 0f, 0f).SetDelay(3f);
    }

    private void ActivateWetter()
    {
        //Get Components
        PlayerBallMovementController opponent = LevelManager.Instance.GetOpponent(_playerBallMovementController);
        SphereCollider _ballSphereCollider = opponent.GetComponentInChildren<SphereCollider>();

        //Set Values
        _ballSphereCollider.material.dynamicFriction = 0f;

        //Delayed Set Value
        DOTween.To(() => _ballSphereCollider.material.dynamicFriction, x => _ballSphereCollider.material.dynamicFriction = x, 7f, 0f).SetDelay(3f);
    }

    private void ActivateShrink()
    {
        //Get Components
        PlayerBallMovementController opponent = LevelManager.Instance.GetOpponent(_playerBallMovementController);

        //Set Values
        opponent.GetComponent<Rigidbody>().mass = 6;
        opponent.transform.DOScale(Vector3.one * .5f, 0f);

        //Delayed Set Value
        DOTween.To(() => opponent.GetComponent<Rigidbody>().mass, x => opponent.GetComponent<Rigidbody>().mass = x, 3f, 0f).SetDelay(3f);
        opponent.transform.DOScale(Vector3.one * 1f, 3f);
    }
}
