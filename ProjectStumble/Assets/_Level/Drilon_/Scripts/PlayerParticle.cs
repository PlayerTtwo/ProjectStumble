using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using NaughtyAttributes;

public class PlayerParticle : MonoBehaviour
{
    [SerializeField] private GameObject _speedBoostVfx;
    [SerializeField] private GameObject _sleepVfx;
    [SerializeField] private GameObject _slideVfx;
    [SerializeField] private GameObject _wetterVfx;
    [SerializeField] private GameObject _shrinkVfx;
    [SerializeField] private GameObject _inverseControlsVfx;

    private Tween _speedBoostTween;
    private Tween _sleepTween;
    private Tween _slideTween;
    private Tween _wetterTween;
    private Tween _shrinkTween;
    private Tween _inverseControlsTween;

    public void ActivateSpeedBoost(float duration)
    {
        _speedBoostVfx.SetActive(true);
        if (_speedBoostTween != null) _speedBoostTween.Kill();
        _speedBoostTween = DOVirtual.DelayedCall(duration, () => {
            _speedBoostVfx.SetActive(false);
        });
    }

    public void ActivateSleep(float duration)
    {
        _sleepVfx.SetActive(true);
        if (_sleepTween != null) _sleepTween.Kill();
        _sleepTween = DOVirtual.DelayedCall(duration, () => {
            _sleepVfx.SetActive(false);
        });
    }

    public void ActivateSlide(float duration)
    {
        _slideVfx.SetActive(true);
        if (_slideTween != null) _slideTween.Kill();
        _slideTween = DOVirtual.DelayedCall(duration, () => {
            _slideVfx.SetActive(false);
        });
    }

    public void ActivateWetter(float duration)
    {
        _wetterVfx.SetActive(true);
        if (_wetterTween != null) _wetterTween.Kill();
        _wetterTween = DOVirtual.DelayedCall(duration, () => {
            _wetterVfx.SetActive(false);
        });
    }

    public void ActivateShrink(float duration)
    {
        _shrinkVfx.SetActive(true);
        if (_shrinkTween != null) _shrinkTween.Kill();
        _shrinkTween = DOVirtual.DelayedCall(duration, () => {
            _shrinkVfx.SetActive(false);
        });
    }

    public void ActivateInverseControls(float duration)
    {
        _inverseControlsVfx.SetActive(true);
        if (_inverseControlsTween != null) _inverseControlsTween.Kill();
        _inverseControlsTween = DOVirtual.DelayedCall(duration, () => {
            _inverseControlsVfx.SetActive(false);
        });
    }

    [Button("Speed Boost")]
    public void TestSpeed()
    {
        ActivateSpeedBoost(3f);
    }

    [Button("Sleep")]
    public void TestSleep()
    {
        ActivateSleep(3f);
    }

    [Button("Slide")]
    public void TestSlide()
    {
        ActivateSlide(3f);
    }

    [Button("Wetter")]
    public void TestWetter()
    {
        ActivateWetter(3f);
    }

    [Button("Shrink")]
    public void TestShrink()
    {
        ActivateShrink(3f);
    }

    [Button("Invert Controls")]
    public void TestInvertControls()
    {
        ActivateInverseControls(3f);
    }
}
