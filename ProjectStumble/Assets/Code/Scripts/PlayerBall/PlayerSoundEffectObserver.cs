using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffectObserver : MonoBehaviour
{
    private PlayerBallMovementController _player;
    private PlayerPowerup _playerPowerup;

    public PlayerBallMovementController PlayerBallMovementController 
    { 
        get
        {
            return _player;
        }

        set
        {
            _player = value;
            Player_OnPlayerJoin();
        }
    }

    [SerializeField]
    private void Awake()
    {
        PlayerBallMovementController = GetComponent<PlayerBallMovementController>();
        _playerPowerup = GetComponent<PlayerPowerup>();
    }

    private void OnEnable()
    {
        //Player Event Subs   
        PlayerBallMovementController.OnPlayerJump += Player_OnPlayerJump;
        LevelManager.Instance.OnLevelStart += LevelManager_OnLevelStart;

        _playerPowerup.OnGainNewPowerup += PlayerPowerup_OnGainNewPowerup;

        _playerPowerup.OnPowerupStun += PlayerPowerup_OnPowerupStun;
        _playerPowerup.OnPowerupSpeedBoost += PlayerPowerup_OnPowerupSpeedBoost;
        _playerPowerup.OnPowerupWetter += PlayerPowerup_OnPowerupWetter;
        _playerPowerup.OnPowerupShrink += PlayerPowerup_OnPowerupShrink;
        _playerPowerup.OnPowerupPush += PlayerPowerup_OnPowerupPush;
    }


    private void OnDisable()
    {
        //Player Event Unsubs
        PlayerBallMovementController.OnPlayerJump -= Player_OnPlayerJump;
        LevelManager.Instance.OnLevelStart -= LevelManager_OnLevelStart;

        _playerPowerup.OnPowerupStun -= PlayerPowerup_OnPowerupStun;
        _playerPowerup.OnPowerupSpeedBoost -= PlayerPowerup_OnPowerupSpeedBoost;
        _playerPowerup.OnPowerupWetter -= PlayerPowerup_OnPowerupWetter;
        _playerPowerup.OnPowerupShrink -= PlayerPowerup_OnPowerupShrink;
        _playerPowerup.OnPowerupPush -= PlayerPowerup_OnPowerupPush;
    }

    private void Player_OnPlayerJump()
    {
        if(SoundEffectManager.Instance == null) return;
        PlaySoundEffect(SoundEffectManager.Instance.JumpSFX);
    }

    private void Player_OnPlayerJoin()
    {
        if(SoundEffectManager.Instance == null) return;
        PlaySoundEffect(SoundEffectManager.Instance.PlayerJoinSFX[LevelManager.Instance.PlayersJoined]);
    }

    private void PlayerPowerup_OnGainNewPowerup(PowerupData obj)
    {
        if (SoundEffectManager.Instance == null) return;
        PlaySoundEffect(SoundEffectManager.Instance.GainPoweupSFX);
    }

    private void LevelManager_OnLevelStart()
{
        if(SoundEffectManager.Instance == null) return;
        PlaySoundEffect(SoundEffectManager.Instance.LevelStartSFX);
    }
    private void PlayerPowerup_OnPowerupPush()
    {
        if (SoundEffectManager.Instance == null) return;
        PlaySoundEffect(SoundEffectManager.Instance.InvertControlsSFX);
    }

    private void PlayerPowerup_OnPowerupShrink()
    {
        if (SoundEffectManager.Instance == null) return;
        PlaySoundEffect(SoundEffectManager.Instance.ShrinkSFX);
    }

    private void PlayerPowerup_OnPowerupWetter()
    {
        if (SoundEffectManager.Instance == null) return;
        PlaySoundEffect(SoundEffectManager.Instance.WetterSFX);
    }

    private void PlayerPowerup_OnPowerupSpeedBoost()
    {
        if (SoundEffectManager.Instance == null) return;
        PlaySoundEffect(SoundEffectManager.Instance.SpeedBoostSFX);
    }

    private void PlayerPowerup_OnPowerupStun()
    {
        if (SoundEffectManager.Instance == null) return;
        PlaySoundEffect(SoundEffectManager.Instance.StunSFX);
    }

    private void PlaySoundEffect(AudioClip clip) => SoundEffectManager.Instance.PlaySoundEffect(clip);
}