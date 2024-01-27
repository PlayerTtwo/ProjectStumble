using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffectObserver : MonoBehaviour
{
    private PlayerBallMovementController _player;
    private int _currPlayerIndex;

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

    [SerializeField] private void Awake() => PlayerBallMovementController = GetComponent<PlayerBallMovementController>();

    private void OnEnable()
    {
        //Player Event Subs   
        _player.OnPlayerJump += Player_OnPlayerJump;
        LevelManager.Instance.OnLevelStart += LevelManager_OnLevelStart;
    }


    private void OnDisable()
    {
        //Player Event Unsubs
        _player.OnPlayerJump -= Player_OnPlayerJump;
        LevelManager.Instance.OnLevelStart -= LevelManager_OnLevelStart;
    }

    private void Player_OnPlayerJump()
    {
        PlaySoundEffect(SoundEffectManager.Instance.JumpSFX);
    }

    private void Player_OnPlayerJoin()
    {
        PlaySoundEffect(SoundEffectManager.Instance.PlayerJoinSFX[LevelManager.Instance.PlayersJoined]);
    }

    private void LevelManager_OnLevelStart()
{
        PlaySoundEffect(SoundEffectManager.Instance.LevelStartSFX);
    }

    private void PlaySoundEffect(AudioClip clip) => SoundEffectManager.Instance.PlaySoundEffect(clip);
}