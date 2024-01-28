using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIFlash : MonoBehaviour
{
    private FlashPlayerEvent _playerFlash;
    private PlayerPowerup _playerPowerup;
    private float _flashDuration = .4f;
    [SerializeField] private CanvasGroup _canvasFlashWhite;
    [SerializeField] private CanvasGroup _canvasFlashPurple;

    private void Awake()
    {
        _playerFlash = GetComponentInParent<FlashPlayerEvent>();
        _playerPowerup = GetComponentInParent<PlayerPowerup>();
    }

    private void OnEnable()
    {
        _playerFlash.OnPlayerTouchOtherPlayer += PlayerFlashOnOnPlayerFlashTouchOtherPlayerFlash;
        _playerPowerup.OnGainNewPowerup += PlayerPowerupOnOnGainNewPowerup;
    }


    private void OnDisable()
    {
        _playerFlash.OnPlayerTouchOtherPlayer -= PlayerFlashOnOnPlayerFlashTouchOtherPlayerFlash;
        _playerPowerup.OnGainNewPowerup -= PlayerPowerupOnOnGainNewPowerup;

    }


    private void PlayerFlashOnOnPlayerFlashTouchOtherPlayerFlash() => FlashWhite();
    private void PlayerPowerupOnOnGainNewPowerup(PowerupData obj) => FlashPurple();
  

    private void FlashWhite()
    {
        _canvasFlashWhite.DOKill();
        _canvasFlashWhite.alpha = 0.3f;
        _canvasFlashWhite.DOFade(0f, _flashDuration);
    }
    private void FlashPurple()
    {
        _canvasFlashPurple.DOKill();
        _canvasFlashPurple.alpha = 0.3f;
        _canvasFlashPurple.DOFade(0f, _flashDuration);
    }
}
