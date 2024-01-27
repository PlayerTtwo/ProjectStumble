using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class UIPlayerPowerup : MonoBehaviour
{
    private PlayerPowerup _playerPowerup;
    
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Image _powerupIconImage;

    private Tween _tween;

    private void Awake()
    {
        _playerPowerup = GetComponentInParent<PlayerPowerup>();
    }

    private void OnEnable()
    {
        _playerPowerup.OnGainNewPowerup += PlayerPowerup_OnGainNewPowerup;
        _playerPowerup.OnUseCurrentPowerup += PlayerPowerup_OnUseCurrentPowerup;
    }

    private void OnDisable()
    {
        _playerPowerup.OnGainNewPowerup -= PlayerPowerup_OnGainNewPowerup;
        _playerPowerup.OnUseCurrentPowerup -= PlayerPowerup_OnUseCurrentPowerup;
    }

    private void PlayerPowerup_OnGainNewPowerup(PowerupData powerupData)
    {
        KillTween();
        _powerupIconImage.sprite = powerupData.IconSprite;
        _tween = _canvasGroup.DOFade(1f, .5f);
    }

    private void PlayerPowerup_OnUseCurrentPowerup()
    {
        KillTween();
        _tween = _canvasGroup.DOFade(0f, .5f).OnComplete(() => _powerupIconImage.sprite = null);
    }

    private void KillTween()
    {
        if (_tween != null) _tween.Kill();
    }
}
