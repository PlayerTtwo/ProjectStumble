using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffectObserver : MonoBehaviour
{
    private PlayerBallMovementController _player;

    private void Awake() => _player = GetComponent<PlayerBallMovementController>();

    private void OnEnable()
    {
        //Player Event Subs   
        _player.OnPlayerJump += Player_OnPlayerJump;
    }

    private void OnDisable()
    {
        //Event Unsubs
        _player.OnPlayerJump -= Player_OnPlayerJump;
    }

    private void Player_OnPlayerJump()
    {
        PlaySoundEffect(SoundEffectManager.Instance.JumpSFX);
    }

    private void PlaySoundEffect(AudioClip clip) => SoundEffectManager.Instance.PlaySoundEffect(clip);
}
